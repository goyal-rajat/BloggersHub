using BloggersHub.DTO;
using BloggersHub.Models;

namespace BloggersHub.Services
{
    public interface IBlogsService
    {
        public Task<List<Models.Blogs>> GetBlogs();
        public Task<int> CreateBlogs(BlogsDTO blogsDTO);
    }
}
