using Forums.BusinessLogic;
using Forums.BusinessLogic.DBModel;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Posts;
using Forums.Domain.Entities.Response;
using Forums.Web.Extension;
using Forums.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Forums.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPost _post;
        private readonly IUser _user;
        private readonly IMySession _session;

        public HomeController(IPost post, IMySession session, IUser user)
        {
            _post = post;
            _session = session;
            _user = user;
        }

        public async Task<IActionResult> HomePage()
        {
            var posts = await _post.GetRecentPosts();
            var postDataList = new List<PostUserViewModel>();

            if (posts.Any())
            {
                foreach (var post in posts)
                {
                    var user = await _user.GetUserDataByIdAsync(post.AuthorId);
                    var userData = user != null ? new UserData { Username = user.Username, Photo = user.Photo } : new UserData();

                    var postData = new PostUserViewModel
                    {
                        post = post,
                        User = userData,
                    };
                    postDataList.Add(postData);
                }
            }
            return View(postDataList); 
        }
    }
}
