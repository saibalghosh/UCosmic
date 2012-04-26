﻿//using System.Threading;
//using UCosmic.Domain;
//using UCosmic.Domain.Email;
//using UCosmic.Orm;

//namespace UCosmic
//{
//    public class SendAsyncEmailMessageHandler : IHandleCommands<SendEmailMessageCommand>
//    {
//        private readonly ISendMail _mailSender;
//        private readonly ILogExceptions _exceptionLogger;

//        public SendAsyncEmailMessageHandler(ISendMail mailSender
//            , ILogExceptions exceptionLogger
//        )
//        {
//            _mailSender = mailSender;
//            _exceptionLogger = exceptionLogger;
//        }

//        public void Handle(SendEmailMessageCommand command)
//        {
//            var program = new SendAsyncEmailMessageProgram(command, _mailSender, _exceptionLogger);
//            var thread = new Thread(program.Launch);
//            thread.Start();
//        }

//        private class SendAsyncEmailMessageProgram
//        {
//            private readonly SendEmailMessageCommand _command;
//            private readonly ISendMail _mailSender;
//            private readonly ILogExceptions _exceptionLogger;

//            internal SendAsyncEmailMessageProgram(SendEmailMessageCommand command
//                , ISendMail mailSender
//                , ILogExceptions exceptionLogger
//            )
//            {
//                _command = command;
//                _mailSender = mailSender;
//                _exceptionLogger = exceptionLogger;
//            }

//            internal void Launch()
//            {
//                // get per-thread instance of DbContext and query processor
//                var dbContext = DependencyInjector.Current.GetService<UCosmicContext>();
//                var queryProcessor = DependencyInjector.Current.GetService<IProcessQueries>();
//                var handler = new SendEmailMessageHandler(queryProcessor,
//                    dbContext, dbContext, _mailSender, _exceptionLogger);
//                handler.Handle(_command);
//                SimpleHttpContextLifestyleExtensions.DisposeInstance<UCosmicContext>();
//            }
//        }
//    }
//}
