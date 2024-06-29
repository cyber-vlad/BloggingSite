using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.Posts;

namespace Forums.BusinessLogic.Interfaces
{
    public interface IPost
    {
        Task<GeneralResp> SavePost(Post postData);

        Task<List<Post>> GetUserPosts(int UserId);

        Task<List<Post>> GetRecentPosts();

        Task<GeneralResp> DeleteUserPosts(int UserId);

        Task<GeneralResp> DeletePost(int PostId);
    }
}
