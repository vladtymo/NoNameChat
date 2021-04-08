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
using BLL.ToHash;
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

        public Tuple<UserDTO, LoginStatus> Login(UserDTO user, bool needHash = false)
        {
            if (!needHash)
                return Login(repositories.UserRepos, user);
            else
            {
                user.Password = Hasher.ComputeSha256Hash(user.Password);
                return Login(repositories.UserRepos, user);
            }
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
