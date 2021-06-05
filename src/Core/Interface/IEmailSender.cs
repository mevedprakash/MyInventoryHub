using DTO;
using DTO.Configuration;
using DTO.CustomModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public partial interface IEmailSender
    {
        void SendEmail(EmailAccount emailAccount,
            string subject, string body,
            string fromAddress,
            string fromName,
            string toAddress,
            string toName,
            IList<string> bcc = null,
            IList<string> cc = null);
    }
}
