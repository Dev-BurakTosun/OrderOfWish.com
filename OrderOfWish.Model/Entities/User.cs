using OrderOfWish.Core.Entity;
using OrderOfWish.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderOfWish.Model.Entities
{
    public class User:BaseEntity
    {
        public User()
        {
            IsActive = false;
            ActivationCode = Guid.NewGuid();
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRole Role { get; set; }
        public Gender Gender { get; set; }
        public Guid ActivationCode { get; set; }
        public ICollection<Order> Orders { get; set; }       
        
    }
}
