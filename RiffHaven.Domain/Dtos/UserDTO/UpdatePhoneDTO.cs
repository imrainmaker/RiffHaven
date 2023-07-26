using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Dtos.UserDTO
{
    public class UpdatePhoneDTO
    {
        [Required]
        public string Phone { get; set; }
    }
}
