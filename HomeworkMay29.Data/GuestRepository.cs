using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        public List<TopWebsites> GetTopBookmarks()
        {
            using var context = new WebsiteContext(_connectionString);
            var websites = context.Websites.ToList();
            var dictionary = new Dictionary<string, int>();
            foreach (var website in websites)
            {
                if (dictionary.ContainsKey(website.Url))
                {
                    dictionary[website.Url]++;
                }
                else
                {
                    dictionary[website.Url] = 1;
                }
            }


            return dictionary.OrderByDescending(k => k.Value).Take(2).Select(kvp => new TopWebsites
            {
                URL = kvp.Key,
                Count = kvp.Value
            }).ToList();
        }
        //public List<Website> GetTopBookmarks()
        //{
        //    using var context = new WebsiteContext(_connectionString);
        //    if (context.Websites != null)
        //    {
        //        var bookmarks = context.Websites.FromSqlRaw("SELECT TOP 2 Url, COUNT(*) as liked FROM websites " +
        //                                         "GROUP BY Url " +
        //                                         "ORDER BY liked DESC"
        //                                         )

        //        .Select(w => new TopBookmark
        //        {
        //            URL = w.Url,
        //            Count = (int)w.count
        //        }).ToList();

        //        return bookmarks;

        //    }
        //    else
        //    {
        //        return new List<Website>();
        //    }
        //}


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
        public void AddWebsite(Website website)
        {
            using var context = new WebsiteContext(_connectionString);
            context.Websites.Add(website);
            context.SaveChanges();
        }
        public List<Website> GetBookmarksById(int id)
        {
            using var context = new WebsiteContext(_connectionString);
            return context.Websites.Where(b => b.UserId == id).ToList();
        }


        public void UpdateBookmarkTitle(string title, int id)
        {
            using var context = new WebsiteContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"UPDATE Websites SET title={title} WHERE id={id}");
            context.SaveChanges();

        }

        public void DeleteBookmark(int id)
        {
            using var context = new WebsiteContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"DELETE FROM Websites WHERE Id={id}");

        }
    }
}
