
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
                emailMessage.To.Add(new MailboxAddress(user.Id.ToString(), "rahimzyanova98@mail.ru"));
            }
            
            emailMessage.From.Add(new MailboxAddress(mailSettings.DisplayName, mailSettings.Mail));          
            emailMessage.Subject = "New arrival";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<META charset=windows-1251><table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:Arial'><tr><th style='background-color: #B8DBFD;border: 1px solid #ccc'>Название</th><th style='background-color: #B8DBFD;border: 1px solid #ccc'>Описание</th><th style='background-color: #B8DBFD;border: 1px solid #ccc'>Владелец продукта</th><th style='background-color: #B8DBFD;border: 1px solid #ccc'>Телефон владельца продукта</th><th style='background-color: #B8DBFD;border: 1px solid #ccc'>E-mail  владельца продукта</th><th style='background-color: #B8DBFD;border: 1px solid #ccc'>Рынок предоставления</th><th style='background-color: #B8DBFD;border: 1px solid #ccc'>Ссылка на услугу в Service Portfolio</th></tr><tr><td style='width:100px;border: 1px solid #ccc'>IndOf.Портфель услуг для страхования</td><td style='width:100px;border: 1px solid #ccc'>Решения для страховой отрасли</td><td style='width:100px;border: 1px solid #ccc'>Guzel Rakhimzyanova</td><td style='width:100px;border: 1px solid #ccc'>+79991698956</td><td style='width:100px;border: 1px solid #ccc'>Guzel.Rakhimzyanova@icl-services.com</td><td style='width:100px;border: 1px solid #ccc'>ICL Services for RSB,</td><td style='width:100px;border: 1px solid #ccc'></td></tr></table>"
            };

            using (var client = new SmtpClient())
            {            
                 client.Connect(mailSettings.Host, mailSettings.Port, false);
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
