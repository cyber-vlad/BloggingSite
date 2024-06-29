using Azure;
using Forums.BusinessLogic.DBModel;
using Forums.BusinessLogic.Interfaces;
using Forums.Domain.Entities.Posts;
using Forums.Domain.Entities.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forums.BusinessLogic.Core
{
    public class PostAPI
    {
        private readonly PostContext _postContext;

        public PostAPI(PostContext postContext)
        {
            _postContext = postContext;
        }

        public async Task<List<Post>> GetUserPostsAsync(int UserId)
        {
            return await _postContext.Posts.Where(p => p.AuthorId == UserId).ToListAsync();
        }

        public async Task<List<Post>> GetRecentPostsAsync()
        {
            var recentPosts = await _postContext.Posts
                .OrderByDescending(p => p.DateOfCreation)
                .Take(10)
                .ToListAsync();
            if (recentPosts?.Any() != true)
            {
                return new List<Post>();
            }
            return recentPosts;
        }

        public async Task<GeneralResp> DeleteUserPostsAsync(int UserId)
        {
            var posts = _postContext.Posts.Where(p => p.AuthorId == UserId).ToList();

            _postContext.Posts.RemoveRange(posts);

            await _postContext.SaveChangesAsync();

            return new GeneralResp { Status = true };

        }

        public async Task<GeneralResp> SavePostAsync(Post postData)
        {
            if(postData == null)
            {
                return new GeneralResp { Status = false ,StatusMsg ="postData is null"};
            }
            else
            {
                _postContext.Posts.Add(postData);
                await _postContext.SaveChangesAsync();
                return new GeneralResp { Status = true, StatusMsg = "post was added" };
            }
        }

        public async Task<GeneralResp> DeletePostAsync(int postId)
        {
            if(postId != 0)
            {
                var post = await _postContext.Posts.FindAsync(postId);
                _postContext.Posts.Remove(post);
                await _postContext.SaveChangesAsync();
                return new GeneralResp { Status = true, StatusMsg = "Post deleted successfully." };
            }
            else { return new GeneralResp { Status = false };}
        }

    }
}
