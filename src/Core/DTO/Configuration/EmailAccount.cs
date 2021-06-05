﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Configuration
{
   public class EmailAccount
    {
        public string Email { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
    }
}
