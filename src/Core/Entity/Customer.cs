
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class Customer : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
    }

}
