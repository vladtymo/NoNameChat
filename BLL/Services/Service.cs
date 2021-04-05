using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Service : IService
    {
        private IUnitOfWork repositroties;
        private IMapper mapper;

        public Service()
        {
            repositroties = new UnitOfWork();

            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                // From Entity to DTO
                cfg.CreateMap<File, FileDTO>();
                cfg.CreateMap<Group,  GroupDTO >();
                cfg.CreateMap<Message, MessageDTO>();
                cfg.CreateMap<User, UserDTO>();

                // From DTO to Entity
                cfg.CreateMap<FileDTO, File>();
                cfg.CreateMap<GroupDTO, Group>();
                cfg.CreateMap<MessageDTO, Message>();
                cfg.CreateMap<UserDTO, User>();
            });

            mapper = new Mapper(config);
        }

        #region Creates
        public void CreateNewFile(FileDTO newFile)
        {
            repositroties.FileRepos.Insert(mapper.Map<File>(newFile));
            repositroties.Save();
        }

        public void CreateNewGroup(GroupDTO newGroup)
        {
            repositroties.GroupRepos.Insert(mapper.Map<Group>(newGroup));
            repositroties.Save();
        }

        public void CreateNewMessage(MessageDTO newMessage)
        {
            repositroties.MessageRepos.Insert(mapper.Map<Message>(newMessage));
            repositroties.Save();
        }

        public void CreateNewUser(UserDTO newUser)
        {
            repositroties.UserRepos.Insert(mapper.Map<User>(newUser));
            repositroties.Save();
        } 
        #endregion

        #region Gets
        public IEnumerable<FileDTO> GetAllFiles()
        {
            return mapper.Map<IEnumerable<FileDTO>>(repositroties.FileRepos.Get());
        }

        public IEnumerable<GroupDTO> GetAllGroups()
        {
            return mapper.Map<IEnumerable<GroupDTO>>(repositroties.GroupRepos.Get());
        }

        public IEnumerable<MessageDTO> GetAllMessages()
        {
            return mapper.Map<IEnumerable<MessageDTO>>(repositroties.MessageRepos.Get());
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return mapper.Map<IEnumerable<UserDTO>>(repositroties.UserRepos.Get());
        } 
        #endregion
    }
}
