﻿using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BET.Data.Model
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public ICollection<Order> Orders { get; set; }
       
        public User()
        {
            Orders = new Collection<Order>();
           
        }
    }
}