using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountryHolidaysWrapperAPI.Models
{
    public class Holiday
    {
        public DateTime date { get; set; }
        public string countryCode { get; set; }


    }
}
