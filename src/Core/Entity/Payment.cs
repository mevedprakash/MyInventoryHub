using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Payment:BaseEntity
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
