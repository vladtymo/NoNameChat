using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<File> FileRepos { get; }
        IRepository<Group> GroupRepos { get; }
        IRepository<Message> MessageRepos { get; }
        IRepository<User> UserRepos { get; }
        void Save();
    }
}
