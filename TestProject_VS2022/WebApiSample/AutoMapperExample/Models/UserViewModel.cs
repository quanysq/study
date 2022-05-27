﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMapperExample.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }

        public string UserName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}