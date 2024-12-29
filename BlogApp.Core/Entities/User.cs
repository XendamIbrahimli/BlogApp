using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Entities
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsFeMale { get; set; }
        public DateOnly BirthDate { get; set; }
        public int Role { get; set; }
        public bool IsBanned { get; set; }
        public DateTime? UnlockTime { get; set; }
    }
}
