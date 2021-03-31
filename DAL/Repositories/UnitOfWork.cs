using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private /*static*/ ChatModel context = new ChatModel();
        private GenericRepository<File> fileRepository;
        private GenericRepository<Group> groupRepository;
        private GenericRepository<Message> messageRepository;
        private GenericRepository<User> userRepository;

        public IRepository<File> FileRepos
        {
            get
            {
                // repository lazy loading
                if (this.fileRepository == null)
                {
                    this.fileRepository = new GenericRepository<File>(context);
                }
                return fileRepository;
            }
        }
        public IRepository<Group> GroupRepos
        {
            get
            {
                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<Group>(context);
                }
                return groupRepository;
            }
        }
        public IRepository<Message> MessageRepos
        {
            get
            {
                if (this.messageRepository == null)
                {
                    this.messageRepository = new GenericRepository<Message>(context);
                }
                return messageRepository;
            }
        }

        public IRepository<User> UserRepos
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository= new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
