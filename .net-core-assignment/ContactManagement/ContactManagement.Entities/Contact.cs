using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ContactManagement.Entities
{
    public class Contact: Base.BaseEntity
    {
        public Contact()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
        }

        [MaxLength(50)]
        public string FirstName { get; set; }
        
        [MaxLength(50)]
        public string LastName { get; set; }

        [ForeignKey("ContactId")]
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
