using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.BLL.Interfaces
{
    public interface IJwtService
    {
        public string GenerateToken(Users user);
    }
}
