using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Dtos.UserDTO
{
    public class UpdatePwdDTO
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=!]).{8,25}$")]
        public string NewPassword { get; set; }

        [Compare("NewPassword")]
        public string CheckPassword { get; set; }
    }
}
