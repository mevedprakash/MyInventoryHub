
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class EmailQueue
    {
        [Required]
        public int Id { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string ToName { get; set; }
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SentOn { get; set; }
        public int TryCount {get;set;}
        public bool IsSent { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
