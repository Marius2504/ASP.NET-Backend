using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities.Auth
{
    public class User : IdentityUser<int>
    {
        public User() { }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool isTrainer { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
