using BloggersHub.DTO;
using BloggersHub.Models;

namespace BloggersHub.Repository
{
    public interface IBlogsRepository
    {
        public Task<int> CreateBlog(Blogs blogsDTO);
        public Task<List<Models.Blogs>> GetBlogs();
        public Task<List<Models.Blogs>> GetMyBlogs(string userName);
    }
}
