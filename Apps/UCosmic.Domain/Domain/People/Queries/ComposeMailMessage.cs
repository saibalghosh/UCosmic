﻿using System;
using System.Net.Mail;

namespace UCosmic.Domain.People
{
    public class ComposeMailMessageQuery : IDefineQuery<MailMessage>
    {
        public ComposeMailMessageQuery(EmailMessage emailMessage)
        {
            if (emailMessage == null) throw new ArgumentNullException("emailMessage");
            EmailMessage = emailMessage;
        }

        public EmailMessage EmailMessage { get; private set; }
    }

    public class ComposeMailMessageHandler : IHandleQueries<ComposeMailMessageQuery, MailMessage>
    {
        public MailMessage Handle(ComposeMailMessageQuery query)
        {
            if (query == null) throw new ArgumentNullException("query");

            // initialize message
            var email = query.EmailMessage;
            var mail = new MailMessage
            {
                From = new MailAddress(email.FromAddress, email.FromDisplayName),
                Subject = email.Subject,
                Body = email.Body,
            };
            mail.To.Add(new MailAddress(email.ToAddress, email.ToPerson.DisplayName));

            // reply-to address
            if (!string.IsNullOrWhiteSpace(email.ReplyToAddress))
                mail.ReplyToList.Add(new MailAddress(email.ReplyToAddress, email.FromAddress));

            return mail;
        }
    }
}
