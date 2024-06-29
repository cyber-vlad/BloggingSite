using System.Threading.Tasks;
using AutoMapper;
using Forums.BusinessLogic.Core;
using Forums.BusinessLogic.DBModel;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Posts;
using Forums.Domain.Entities.Response;
using Forums.Domain.Entities.User;
using Microsoft.AspNetCore.Http;

namespace Forums.BusinessLogic
{
    public class PostBL : PostAPI, IPost
    {
        public PostBL(PostContext postContext) :
            base(postContext)
        {
        }
        public Task<GeneralResp> SavePost(Post postData)
        {
            return SavePostAsync(postData);
        }
        public Task<List<Post>> GetUserPosts(int UserId)
        {
            return GetUserPostsAsync(UserId);
        }
        public Task<List<Post>> GetRecentPosts()
        {
            return GetRecentPostsAsync();
        }
        public Task<GeneralResp> DeleteUserPosts(int UserId) 
        {
            return DeleteUserPostsAsync(UserId);
        }
        public Task<GeneralResp> DeletePost(int PostId)
        {
            return DeletePostAsync(PostId);
        }
    }
}
