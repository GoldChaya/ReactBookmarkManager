using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkMay29.Data
{
    public class GuestRepository
    {
        private readonly string _connectionString;

        public GuestRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Website> GetTopFiveBookmarks()
        {
            using var context = new WebsiteContext(_connectionString);
            if (context.Websites != null)
            {
                var bookmarks = context.Websites.FromSqlRaw("SELECT TOP 5 Url, COUNT(*) as liked FROM websites " +
                                                 "GROUP BY Url " +
                                                 "ORDER BY liked DESC"
                                                 )

                .Select(b => new Website
                {
                    Url = b.Url,
                    Liked = (int)b.Liked
                }).ToList();

                return bookmarks;

            }
            else
            {
                return new List<Website>();
            }
        }


        public void AddUser(User user, string password)
        {
            var hash = BCrypt.Net.BCrypt.HashPassword(password);
            user.PasswordHash = hash;
            using var context = new WebsiteContext(_connectionString);
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User Login(string email, string password)
        {
            var user = GetByEmail(email);
            if (user == null)
            {
                return null;
            }

            var isValidPassword = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isValidPassword)
            {
                return null;
            }

            return user;

        }

        public User GetByEmail(string email)
        {
            using var ctx = new WebsiteContext(_connectionString);
            return ctx.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
