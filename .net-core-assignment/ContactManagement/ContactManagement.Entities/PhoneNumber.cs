using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactManagement.Entities
{
    public class PhoneNumber: Base.BaseEntity
    {
        public string Type { get; set; }

        public string CountryCode { get; set; }

        public string Number { get; set; }

        [ForeignKey("ContactId")]
        public int ContactId { get; set; }
    }
}
