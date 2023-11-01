using HomeworkMay29.Data;
using HomeworkMay29.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkMay29.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly string _connectionString;

        public UserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        private User GetCurrentUser()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return null;
            }

            var repo = new GuestRepository(_connectionString);
            return repo.GetByEmail(User.Identity.Name);
        }

        [HttpPost]
        [Route("logout")]
        public void Logout()
        {
            HttpContext.SignOutAsync().Wait();
        }
        [HttpPost]
        [Route("AddBookmark")]
        public void AddBookmark(Website website)
        {
            var user = GetCurrentUser();
            website.UserId = user.Id;
            var repo = new GuestRepository(_connectionString);
            repo.AddWebsite(website);
        }
        [HttpGet]
        [Route("getbookmarks")]
        public List<Website> GetBookmarks()
        {
            var user = GetCurrentUser();
            var UserRepo = new GuestRepository(_connectionString);
            return UserRepo.GetBookmarksById(user.Id);
        }

        [HttpPost]
        [Route("updatebookmarktitle")]
        public void UpdateBookmarkTitle(UpdateBookmarkViewModel vm)
        {
            var UserRepo = new GuestRepository(_connectionString);
            UserRepo.UpdateBookmarkTitle(vm.Title, vm.Id);

        }

        [HttpPost]
        [Route("deletebookmark")]
        public void DeleteBookmark(DeleteViewModel vm)
        {
            var UserRepo = new GuestRepository(_connectionString);
            UserRepo.DeleteBookmark(vm.Id);
        }

    }
}
