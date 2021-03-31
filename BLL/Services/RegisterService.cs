using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class RegisterService
    {
        public enum RegisterStatus
        {
            SuccessRegister,
            ExistUser,
        }

        private IUnitOfWork repositories;
        private IMapper mapper;
        public RegisterService()
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

        public RegisterStatus Register(UserDTO user, bool needHash = false)
        {
            return Register(repositories.UserRepos, user, needHash);
        }
        public RegisterStatus Register(User user, bool needHash = false)
        {
            return Register(repositories.UserRepos, user, needHash);
        }

        private RegisterStatus Register(IRepository<User> users, UserDTO user, bool needHash = false)
        {
            if (needHash)
                user.Password = ToHash.Hasher.ComputeSha256Hash(user.Password);
            if (users.Get().FirstOrDefault(u => u.Email == user.Email) == null)
                users.Insert(mapper.Map<User>(user));
            return RegisterStatus.ExistUser;
        }

        private RegisterStatus Register(IRepository<User> users, User user, bool needHash = false)
        {
            if (needHash)
                user.Password = ToHash.Hasher.ComputeSha256Hash(user.Password);
            if (users.Get().FirstOrDefault(u => u.Email == user.Email) == null)
                users.Insert(user);
            return RegisterStatus.ExistUser;
        }
    }
}
