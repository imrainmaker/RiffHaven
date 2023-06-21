using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Entities
{
    public class Orders
    {
        public int Id_Orders { get; set; }
        public DateTime DateOrder { get; set; }
        public decimal PriceExclVAT { get; set; }
        public string PriceVAT { get; set; }
        public int NbrProducts { get; set; }
        public int VAT { get; set; }
        public int Id_Users { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Box { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public int Id_Products { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
