using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagerStandard.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public int TitleID { get; set; }
        public virtual Title Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
    }

    public enum Gender 
    { 
        Female,
        Male
    }
}