using System.Threading;
using UCosmic.Domain;
using UCosmic.Domain.People;

namespace UCosmic.Impl
{
    // ReSharper disable ClassNeverInstantiated.Global
    public class MvcEmailSender : ISendEmails
    // ReSharper restore ClassNeverInstantiated.Global
    {
        private readonly ICommandObjects _objectCommander;
        private readonly IManageConfigurations _config;

        public MvcEmailSender(ICommandObjects objectCommander, IManageConfigurations config)
        {
            _objectCommander = objectCommander;
            _config = config;
        }

        public void Send(EmailMessage message)
        {
            var sender = new SmtpEmailSender(_objectCommander, message, _config);
            var thread = new Thread(sender.Send);
            thread.Start();
        }
    }
}