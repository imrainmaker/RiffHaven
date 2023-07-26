﻿using Dapper;
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
                return result == 1 ? true : false;
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
                return result == 1 ? true : false;
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
            throw new NotImplementedException();
        }

        public bool UpdateAdress(int id, UpdateAdressDTO updateAdressDTO)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePhone(int id, UpdatePhoneDTO updatePhoneDTO)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePwd(int id, UpdatePwdDTO updatePwdDTO)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(int id, UpdateRoleDTO updateRoleDTO)
        {
            throw new NotImplementedException();
        }
    }
}
