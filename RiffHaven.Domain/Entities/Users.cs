using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Entities
{
    public class Users
    {
        public int Id_Users { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public int? Number { get; set; }
        public string? Box { get; set; }
        public int? Zip { get; set; }
        public string? City { get; set; }
        public bool Role { get; set; } = false;
        
    }
}
