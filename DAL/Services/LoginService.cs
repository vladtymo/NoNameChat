using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class LoginService
    {
        public enum LoginStatus
        {
            SuccessLogin,
            NotExist,
        }

        // With hash password
        public static Tuple<User, LoginStatus> Login(ChatModel _context, User user)
        {
            return Login(_context.Users, user);
        }

        public static Tuple<User, LoginStatus> Login(DbSet<User> users, User user)
        {
            if (users.Where(u => u.Email == user.Email).FirstOrDefault(u => u.Password == user.Password) is User user1 && user1 != null)
                return new Tuple<User, LoginStatus>(user1, LoginStatus.SuccessLogin);
            else
                return new Tuple<User, LoginStatus>(null, LoginStatus.NotExist);

        }

        // Without hash password
        public static Tuple<User, LoginStatus> Login(ChatModel _context, string email, string password)
        {
            string _password = RegisterService.ComputeSha256Hash(password);
            return Login(_context, new User() { Email = email, Password = _password });
        }
    }
}
