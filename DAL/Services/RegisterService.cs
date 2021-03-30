using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class RegisterService
    {
        public enum RegisterStatus
        {
            SuccessRegister,
            ExistUser,
        }
        public static RegisterStatus Register(ChatModel _context, User user, bool needHash = false)
        {
            return Register(_context.Users, user);
        }

        public static RegisterStatus Register(DbSet<User> users, User user, bool needHash = false)
        {
            if (needHash)
                user.Password = ComputeSha256Hash(user.Password);
            if (users.FirstOrDefault(u => u.Email == user.Email) == null)
                users.Add(user);
            return RegisterStatus.ExistUser;
        }

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }
    }
}
