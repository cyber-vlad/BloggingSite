using Forums.Domain.Entities.Posts;

namespace Forums.Web.Models
{
    public class PostUserViewModel
    {
        public Post post { get; set; }
        public UserData User { get; set; }
    }
}
