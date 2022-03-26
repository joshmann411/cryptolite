using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.IO;

namespace cryptolte.JoBambi.Emailer
{
    public class Service
    {
        private readonly IConfiguration _configuration;

        public Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// Actions sent builds email subject 
        /// New Business registation > "Welcome to ylem marketplace" 
        /// Password reset > 
        /// Notification:TYPE(new order) > 
        /// etc
        /// </summary>
        /// <param name="toEmailAddress"></param>
        /// <param name="mailAction"></param>
        /// <param name="sBody"></param>
        /// <param name="host"></param>
        /// <param name=""></param>
        public void Send_Email(List<string> ToEmailAddress, string mailAction, string redirectLink)
        {
            //get config info
            //IConfiguration configuration = new ConfigurationBuilder()
            //            .SetBasePath(Directory.GetCurrentDirectory())
            //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //            .Build();

            //get config data
            string smtpHost = _configuration.GetSection("EmailDetails:smtp_host").Value;
            string smtp_port = _configuration.GetSection("EmailDetails:smtp_port").Value;
            //int smtp_port2 = Convert.ToInt32(configuration.GetSection("EmailDetails:smtp_port").Value);
            string senderEmail = _configuration.GetSection("EmailDetails:senderEmail").Value;
            string senderPassword = _configuration.GetSection("EmailDetails:senderPassword").Value;


            //ensure the host information is intact
            if (!string.IsNullOrEmpty(smtpHost))
            {
                try
                {
                    //compile addresses
                    foreach (string addr in ToEmailAddress)
                    {
                        // create message
                        var email = new MimeMessage();

                        //append sender details
                        email.From.Add(MailboxAddress.Parse(senderEmail));

                        //append recipient's details
                        email.To.Add(MailboxAddress.Parse(addr));

                        //add subject
                        email.Subject = "Welcome to Dynamo Crypto";

                        //add email body
                        email.Body = new TextPart(TextFormat.Html)
                        {
                            Text = CreateBody(addr, mailAction, redirectLink)
                        };

                        //prep smtp server and send
                        string SmtpServer = smtpHost;
                        int SmtpPortNumber = Convert.ToInt32(smtp_port);
                        using var smtp = new MailKit.Net.Smtp.SmtpClient();
                        smtp.Connect(SmtpServer, SmtpPortNumber, SecureSocketOptions.StartTls);
                        smtp.Authenticate(senderEmail, senderPassword);
                        smtp.Send(email);
                        smtp.Disconnect(true);
                    }
                }
                catch (Exception ex) { }
            }
        }

        public string CreateBody(string ToEmailAddress, string mailAction, string redirectLink)
        {
            if (mailAction == "1") //New Business registation
            {
                string welcomeCeremonyTemplate = Directory.GetCurrentDirectory() + @"\Templates\_WelcomeTemplate.html";

                string body = string.Empty;

                using (StreamReader reader = new StreamReader(welcomeCeremonyTemplate))
                {
                    body = reader.ReadToEnd();
                }

                //replacing params
                string welHead = "Welcome to Dynamo Crypto";

                string welBody = "Your registration has been received and will be processed. Follow the instructions below to get started";

                string hd = "https://i.ibb.co/prxXjS3/welcome-Pic.png";

                body = body.Replace("{Image Head}", hd).
                            Replace("{welcome head}", welHead).
                            Replace("{welcome body}", welBody).
                            Replace("{verify link}", "www.google.com");

                return body;
            }
            else
            {
                return "Registration unsuccessful. Please contact admin to reprocess your registration.";
            }

        }


    }
}
