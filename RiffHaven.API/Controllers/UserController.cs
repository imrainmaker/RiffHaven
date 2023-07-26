using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RiffHaven.BLL.Interfaces;
using RiffHaven.Domain.Dtos.UserDTO;
using RiffHaven.Domain.Entities;

namespace RiffHaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]

        public ActionResult<bool> AddUser(NewUserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            bool result = _service.AddUser(userDTO);
            return result ? Ok() : BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetUsers()
        {
            List<Users> users = _service.GetUsers().ToList();
            return users is not null ? Ok(users) : BadRequest();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Users?> GetById(int id)
        {
            if (ModelState.IsValid)
            {
                Users? user = _service.GetById(id);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }



        [HttpGet("{Email}")]
        public ActionResult<Users?> GetByEmail(string Email)
        {
            if (ModelState.IsValid)
            {
                Users? user = _service.GetByEmail(Email);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }



        [HttpPost("Login")]
        public ActionResult<string> Login(LoginDTO loginDTO)
        {

            if (ModelState.IsValid)
            {
                string? user = _service.Login(loginDTO);
                return user is not null ? Ok(user) : BadRequest();
            }

            return BadRequest();
        }



        [HttpPut("Address/{id}")]
        public ActionResult<bool> UpdateAdress(int id, UpdateAdressDTO updateAdressDTO)
        {

            if (ModelState.IsValid)
            {
                bool result = _service.UpdateAdress(id, updateAdressDTO);
                return result ? Ok() : BadRequest();
            }

            return BadRequest();
        }


        [HttpPatch("Password/{id}")]
        public ActionResult<bool> UpdatePwd(int id, UpdatePwdDTO updatePwdDTO)
        {

            if (ModelState.IsValid)
            {
                bool result = _service.UpdatePwd(id, updatePwdDTO);
                return result ? Ok() : BadRequest();
            }

            return BadRequest();
        }

        [HttpPatch("Phone/{id}")]
        public ActionResult<bool> UpdatePhone(int id, UpdatePhoneDTO updatePhoneDTO)
        {

            if (ModelState.IsValid)
            {
                bool result = _service.UpdatePhone(id, updatePhoneDTO);
                return result ? Ok() : BadRequest();
            }

            return BadRequest();
        }

        [HttpPatch("Role/{id}")]
        public ActionResult<bool> UpdateRole(int id, UpdateRoleDTO updateRoleDTO)
        {

            if (ModelState.IsValid)
            {
                bool result = _service.UpdateRole(id, updateRoleDTO);
                return result ? Ok() : BadRequest();
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteUser(int id)
        {
            if (ModelState.IsValid)
            {
                bool result = _service.DeleteUser(id);
                return result ? Ok() : BadRequest();
            }

            return BadRequest();
        }
    }
}
