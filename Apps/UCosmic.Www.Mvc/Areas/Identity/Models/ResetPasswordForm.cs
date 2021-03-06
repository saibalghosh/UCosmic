﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
using FluentValidation;
using UCosmic.Domain.Identity;
using UCosmic.Domain.People;

namespace UCosmic.Www.Mvc.Areas.Identity.Models
{
    public class ResetPasswordForm : IModelConfirmAndRedeem
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Token { get; set; }

        [UIHint(PasswordUiHint)]
        [DataType(DataType.Password)]
        [Display(Name = PasswordDisplayName, Prompt = PasswordDisplayPrompt)]
        public string Password { get; set; }
        public const string PasswordUiHint = "StrengthMeteredPassword";
        public const string PasswordDisplayName = "Password";
        public const string PasswordDisplayPrompt = "Enter your new password";

        [DataType(DataType.Password)]
        [Display(Name = PasswordConfirmationDisplayName, Prompt = PasswordConfirmationDisplayPrompt)]
        [Remote("ValidatePasswordConfirmation", "ResetPassword", "Identity", HttpMethod = "POST", AdditionalFields = "Password")]
        public string PasswordConfirmation { get; set; }
        public const string PasswordConfirmationDisplayName = "Confirmation";
        public const string PasswordConfirmationDisplayPrompt = "Enter the same password again to confirm";
        public const string PasswordConfirmationPropertyName = "PasswordConfirmation";
    }

    public class ResetPasswordValidator : AbstractValidator<ResetPasswordForm>
    {
        public const string FailedBecausePasswordWasEmpty = "Password is required.";
        public const string FailedBecausePasswordWasTooShort = "Your password must be at least {0} characters long.";
        public const string FailedBecausePasswordConfirmationWasEmpty = "Password confirmation is required.";
        public const string FailedBecausePasswordConfirmationDidNotEqualPassword = "The password and confirmation password do not match.";

        public ResetPasswordValidator(IQueryEntities entities, IStorePasswords passwords)
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(p => p.Token)
                // cannot be empty guid
                .NotEmpty()
                    .WithMessage(ValidateEmailConfirmation.FailedBecauseTokenWasEmpty,
                        p => p.Token)
                // matches email confirmation entity
                .Must(p => ValidateEmailConfirmation.TokenMatchesEntity(p, entities))
                    .WithMessage(ValidateEmailConfirmation.FailedBecauseTokenMatchedNoEntity,
                        p => p.Token)
            ;

            RuleFor(p => p.Password)
                // cannot be empty
                .NotEmpty()
                    .WithMessage(FailedBecausePasswordWasEmpty)
                // at least 6 characters long
                .Length(passwords.MinimumPasswordLength, int.MaxValue)
                    .WithMessage(FailedBecausePasswordWasTooShort,
                        p => passwords.MinimumPasswordLength)
            ;

            RuleFor(p => p.PasswordConfirmation)
                // can never be empty
                .NotEmpty()
                    .WithMessage(FailedBecausePasswordConfirmationWasEmpty)
            ;

            RuleFor(p => p.PasswordConfirmation)
                // equals password unless empty or password failed validation
                .Equal(p => p.Password)
                    .Unless(p =>
                        string.IsNullOrWhiteSpace(p.PasswordConfirmation) ||
                        string.IsNullOrWhiteSpace(p.Password) ||
                        p.Password.Length < passwords.MinimumPasswordLength)
                    .WithMessage(FailedBecausePasswordConfirmationDidNotEqualPassword)
            ;
        }
    }

    public static class ResetPasswordProfiler
    {
        public class EntityToModelProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<EmailConfirmation, ResetPasswordForm>()
                    .ForMember(d => d.Password, o => o.Ignore())
                    .ForMember(d => d.PasswordConfirmation, o => o.Ignore())
                ;
            }
        }

        public class ModelToCommandProfile : Profile
        {
            protected override void Configure()
            {
                CreateMap<ResetPasswordForm, ResetPasswordCommand>()
                    .ForMember(d => d.Ticket, o => o.Ignore())
                ;
            }
        }
    }
}