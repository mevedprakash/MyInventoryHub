
using Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Interface
{
    public interface IEmailQueueService
    {
        void AddEmailQueue(EmailQueue email);
    }
}
