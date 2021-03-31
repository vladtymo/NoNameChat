using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using BLL.DTOs;
using DAL;

namespace BLL
{
    class LoginService
    {
        public enum LoginStatus
        {
            SuccessLogin,
            NotExist,
        }

        private IUnitOfWork repositories;
        private IMapper mapper;
        public LoginService()
        {
            this.repositories = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<UserDTO, User>();
                });

            mapper = new Mapper(config);
        }

        // With hash password
        public Tuple<UserDTO, LoginStatus> Login(UserDTO user)
        {
            return Login(repositories.UserRepos, user);
        }
        // Without hash password
        public Tuple<UserDTO, LoginStatus> Login(string email, string password)
        {
            string _password = ToHash.Hasher.ComputeSha256Hash(password);
            return Login(repositories.UserRepos, new UserDTO() { Email = email, Password = _password });
        }

        private Tuple<UserDTO, LoginStatus> Login(IRepository<User> users, UserDTO user)
        {
            if (users.Get(u => u.Email == user.Email).FirstOrDefault(u => u.Password == user.Password) is User user1 && user1 != null)
                return new Tuple<UserDTO, LoginStatus>(mapper.Map<UserDTO>(user1), LoginStatus.SuccessLogin);

            else
                return new Tuple<UserDTO, LoginStatus>(null, LoginStatus.NotExist);

        }

    }
}
