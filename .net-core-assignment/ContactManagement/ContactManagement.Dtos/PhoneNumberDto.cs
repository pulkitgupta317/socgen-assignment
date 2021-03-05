using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.Dtos
{
    public class PhoneNumberDto: Base.BaseDto
    {
        public string Type { get; set; }

        public string CountryCode { get; set; }

        public string Number { get; set; }
    }
}
