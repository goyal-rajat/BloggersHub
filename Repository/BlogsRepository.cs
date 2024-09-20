
using BloggersHub.Data;
using BloggersHub.DTO;
using BloggersHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggersHub.Repository
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly BlogDbContext _dbContext;
        public BlogsRepository(BlogDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public async Task<List<Models.Blogs>> GetBlogs()
        {
            var posts = await _dbContext.Blogs.Include(p => p.Comments).ToListAsync();
            return posts;
        }

        public async Task<int> CreateBlog(Blogs blogsDTO)
        {
            var post = _dbContext.Add(blogsDTO);
            await _dbContext.SaveChangesAsync();
            return post.Entity.Id;
        }

        public async Task<List<Blogs>> GetMyBlogs(string userName)
        {
            var posts = await _dbContext.Blogs.Where(x => x.UserName == userName).Include(p => p.Comments).ToListAsync();
            return posts;
        }
    }
}
