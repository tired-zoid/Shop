
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using Shop.DAL;
using Shop.Entities;    
using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Services
{
    public class EmailService : IEmailService, IDisposable
    {
        private readonly DataContext _data;
        private readonly IConfiguration Configuration;

        public EmailService(DataContext data, IConfiguration сonfiguration)    
        {         
            _data = data;
            Configuration = сonfiguration;
        }

        public void Dispose()
        {    
            _data.Dispose();
        }

        public void Send(Product product)
        {
            var mailSettings = new MailSettings();  
            Configuration.GetSection("MailSettings").Bind(mailSettings);   

            var emailMessage = new MimeMessage();
            List<User> users = _data.Set<User>().ToList();
            foreach (User user in users)
            {
                emailMessage.To.Add(new MailboxAddress(user.Id.ToString(), user.Email));
            }
            
            emailMessage.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));          
            emailMessage.Subject = "New arrival";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "NEW!!!"
            };

            using (var client = new SmtpClient())
            {            
                 client.Connect(mailSettings.Host, mailSettings.Port, true);
                 client.Authenticate(mailSettings.Mail, mailSettings.Password);
                try
                    {
                        client.Send(emailMessage);
                    }

                catch (Exception e)
                    {   
                    
                    }               
                 client.Disconnect(true);
            }
        }
    }
}
