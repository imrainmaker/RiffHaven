using RiffHaven.Domain.Dtos.UserDTO;
using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.BLL.Interfaces
{
    public interface IUserService
    {
        public bool AddUser(NewUserDTO userDTO);
        public IEnumerable<Users> GetUsers();
        public Users? GetById(int id);
        public Users? GetByEmail(string email);
        public string Login(LoginDTO loginDTO);
        public bool UpdateAdress(int id, UpdateAdressDTO updateAdressDTO);
        public bool UpdatePwd(int id, UpdatePwdDTO updatePwdDTO);
        public bool UpdatePhone(int id, UpdatePhoneDTO updatePhoneDTO);
        public bool UpdateRole(int id, UpdateRoleDTO updateRoleDTO);
        public bool DeleteUser(int id);
    }
}
