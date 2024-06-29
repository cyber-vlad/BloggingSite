using System.ComponentModel.DataAnnotations;

namespace Forums.Web.Models
{
    public class UsersPostsViewModel: UserData
    {
        public List<PostData>? Posts { get; set; }
    }
}
