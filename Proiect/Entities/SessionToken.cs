using Proiect.Entities.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Entities
{
    public class SessionToken
    {
        public SessionToken() { }
        public SessionToken(string jti, int userId, DateTime expirationDate)
        {
            this.Jti = Jti;
            this.UserId = userId;
            this.ExpirationDate = expirationDate;
        }
        [Key]
        public string Jti { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
