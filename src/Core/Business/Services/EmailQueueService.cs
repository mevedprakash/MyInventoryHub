
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interface;
using DTO;
using DTO.CustomModel;
using Entity;
using Microsoft.Extensions.Options;
using Entity.Enum;
using DTO.Configuration;

namespace Business.DataServices
{
   
    public class EmailQueueService : IEmailQueueService
    {
        private readonly IEmailSender emailSender;

        public EmailAccount emailAccount { get; }
        private IUnitOfWork unitOfWork { get; }

        public EmailQueueService(IOptions<EmailAccount> emailAccount,
            IUnitOfWork unitOfWork,
            IEmailSender emailSender
            )
        {
            //this.emailAccount = emailAccount?.Value;
            this.unitOfWork = unitOfWork;
            this.emailSender = emailSender;
        }

        

        public void AddEmailQueue(EmailQueue email)
        {
            email.FromEmail = emailAccount.Email;
            
            unitOfWork.EmailQueueRespository.Add(email);
            unitOfWork.SaveChanges();
            emailSender.SendEmail(emailAccount, email.Subject, email.Body,
                email.FromEmail, email.FromName, email.ToEmail, email.ToName);

        }
    }
}
