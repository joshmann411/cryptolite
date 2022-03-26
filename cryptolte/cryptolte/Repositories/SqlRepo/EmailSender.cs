using cryptolte.Interfaces;
using cryptolte.JoBambi.Emailer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Repositories.SqlRepo
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(List<string> toAddress, string mailAction = "1", string redirectLink = "www.google.com")
        {
            Service _emailService = new Service(_config);

            _emailService.Send_Email(toAddress, mailAction, redirectLink);
        }

        public Task SendEmailAsync(List<string> toAddress, string mailAction, string redirectLink)
        {
            throw new NotImplementedException();
        }
    }
}
