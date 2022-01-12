﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NVAPI.Models
{
    public class Customer
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }
    }
}