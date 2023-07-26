using Dapper;
using RiffHaven.DAL.Repositories;
using RiffHaven.Domain.Dtos.UserDTO;
using RiffHaven.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.DAL.Services
{
    public class UserService : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserService(IDbConnection connection)
        {
            _connection = connection;
        }

        public bool AddUser(NewUserDTO userDTO)
        {
            try
            {
                var parameters = new {Mail = userDTO.Email, Nom = userDTO.LastName, Prenom = userDTO.FirstName, Passwd = userDTO.Password};
                string sql = "EXEC  NewUser @Mail, @Nom, @Prenom, @Passwd";
                int result = _connection.Execute(sql, parameters);
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public IEnumerable<Users> GetUsers()
        {
            try
            {
                string sql = "SELECT * FROM UsersView";
                List<Users> users = _connection.Query<Users>(sql).ToList();
                return users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var parameters = new { Id = id };
                string sql = "DELETE FROM Users WHERE Id_Users = @Id";
                int result = _connection.Execute(sql, parameters);
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Users? GetByEmail(string email)
        {
            try
            {
                var parameters = new { Mail = email };
                string sql = "Select * FROM UsersView WHERE email = @Mail";
                return _connection.QueryFirst<Users>(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Users? GetById(int id)
        {
            try
            {
                var parameters = new { Id = id };
                string sql = "Select * FROM UsersView WHERE Id_Users = @Id";
                return _connection.QueryFirst<Users>(sql, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public Users? Login(LoginDTO loginDTO)
        {
            try
            {
                var parameters = new { Mail = loginDTO.Email, Passwd = loginDTO.Password };
                string sql = "EXEC Connexion @Mail @Passwd";
                return _connection.QueryFirst<Users>(sql, parameters);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool UpdateAdress(int id, UpdateAdressDTO updateAdressDTO)
        {
            var parameters = new {Id = id, Street = updateAdressDTO.Street, Number = updateAdressDTO.Number, Box = updateAdressDTO.Box, Zip = updateAdressDTO.Zip, City = updateAdressDTO.City};
            int result = _connection.Execute("UpdateAddress", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;

        }

        public bool UpdatePhone(int id, UpdateProfileDTO updateProfileDTO)
        {
            var parameters = new { Id = id, LastName = updateProfileDTO.LastName, FirstName = updateProfileDTO.FirstName, Email = updateProfileDTO.Email, Phone = updateProfileDTO.Phone };
            string sql = "UPDATE Users SET LastName = @LastName, FirstName = @FirstName, Email = @Email, Phone = @Phone WHERE Id_Users = @Id";
            int result = _connection.Execute(sql, parameters);
            return result > 0;
        }

        public bool UpdatePwd(int id, UpdatePwdDTO updatePwdDTO)
        {
            var parameters = new { Id = id, ActualPasswd = updatePwdDTO.Password, NewPasswd = updatePwdDTO.NewPassword};
            int result = _connection.Execute("UpdatePasswd", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool UpdateRole(int id, UpdateRoleDTO updateRoleDTO)
        {
            var parameters = new { Id = id, Role = updateRoleDTO.Role };
            string sql = "UPDATE Users SET Role = @Role WHERE Id_Users = @Id";
            int result = _connection.Execute(sql, parameters);
            return result > 0;
        }
    }
}
