﻿using PeopleAndOrders.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Model
{
    public class People 
    {
        public int Id { get; set; }     
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string City { get; set; }          
    }
}
