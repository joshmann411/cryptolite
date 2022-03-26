using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(List<string> toAddress, string mailAction, string redirectLink);
        Task SendEmailAsync(List<string> toAddress, string mailAction, string redirectLink);
    }
}
