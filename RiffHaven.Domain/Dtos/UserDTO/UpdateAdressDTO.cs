using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Dtos.UserDTO
{
    public class UpdateAdressDTO
    {


        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        public int Number { get; set; }

        public string? Box { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

    }
}
