using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{

    public class Store : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        [ForeignKey("Image")]
        public int? ImageId { get; set; }
        public FileStore Image { get; set; }

        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public bool IsTaxableInvoice { get; set; }
        public bool AllowOrderEdit { get; set; }
        public bool AllowOrderDelete { get; set; }
    }


    
}
