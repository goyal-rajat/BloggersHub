using BloggersHub.Data;
using BloggersHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggersHub.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _dbContext;

        public CommentRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddComment(Comments comments)
        {
            var res = await _dbContext.Comments.AddAsync(comments);
            _dbContext.SaveChanges();

            return res.Entity.Id;
        }

        public async Task<IEnumerable<Comments>> GetCommentsAsync(int blogId)
        {
           var comments = await _dbContext.Comments.Where(x => x.BlogId == blogId).ToListAsync();
            return comments;
        }
    }
}
