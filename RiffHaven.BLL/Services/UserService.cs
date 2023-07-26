using RiffHaven.BLL.Interfaces;
using RiffHaven.DAL.Repositories;
using RiffHaven.Domain.Dtos.UserDTO;
using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RiffHaven.Domain.Dtos.UserDTO.LoginDTO;

namespace RiffHaven.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _service;
        private readonly IJwtService _jwtService;

        public UserService(IUserRepository service, IJwtService jwtService)
        {
            _service = service;
            _jwtService = jwtService;
        }

        public bool AddUser(NewUserDTO userDTO)
        {
            return _service.AddUser(userDTO);
        }

        public IEnumerable<Users> GetUsers()
        {
            return _service.GetUsers();
        }

        public Users? GetById(int id)
        {

            Users? user = _service.GetById(id);
            return user is not null ? user : null;
        }

        public Users? GetByEmail(string email)
        {
            Users? user = _service.GetByEmail(email);
            return user is not null ? user : null;
        }

        public string Login(LoginDTO loginDTO)
        {
            
            Users? user = _service.Login(loginDTO);
            if (user is not null)
            {
                return _jwtService.GenerateToken(user);
            }

            return null;
        }

        public bool UpdateAdress(int id, UpdateAdressDTO updateAdressDTO)
        {
            return _service.UpdateAdress(id, updateAdressDTO);
        }

        public bool UpdatePwd(int id, UpdatePwdDTO updatePwdDTO)
        {
            return _service.UpdatePwd(id, updatePwdDTO);
        }

        public bool UpdatePhone(int id, UpdateProfileDTO updateProfileDTO)
        {
            return _service.UpdatePhone(id, updateProfileDTO);
        }

        public bool UpdateRole(int id, UpdateRoleDTO updateRoleDTO)
        {
            return _service.UpdateRole(id, updateRoleDTO);
        }

        public bool DeleteUser(int id)
        {
            return _service.DeleteUser(id);
        }
    }
}
