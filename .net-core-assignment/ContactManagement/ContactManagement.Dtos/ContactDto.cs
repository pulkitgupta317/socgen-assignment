using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.Dtos
{
    public class ContactDto : Base.BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
