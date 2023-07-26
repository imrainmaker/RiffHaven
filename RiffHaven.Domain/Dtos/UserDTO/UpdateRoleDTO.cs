using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Dtos.UserDTO
{
    public class UpdateRoleDTO
    {
        [Required]
        public bool Role { get; set; }
    }
}
