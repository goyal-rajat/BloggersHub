
using BloggersHub.DTO;
using BloggersHub.Models;
using BloggersHub.Repository;

namespace BloggersHub.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _repository;
        public BlogsService(IBlogsRepository repository) {
            _repository = repository;
        }
        public async Task<List<Models.Blogs>> GetBlogs()
        {
            var posts = await _repository.GetBlogs();
            return posts;
        }

        public async Task<int> CreateBlogs(BlogsDTO blogsDTO)
        {
            var blog = new Blogs
            {
                Title = blogsDTO.Title,
                Content = blogsDTO.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = 1
            };
            var post = await _repository.CreateBlog(blog);
            return post;
        }

        public async Task<List<Blogs>> GetMyBlogs(int Id)
        {
            var posts = await _repository.GetBlogs();
            return posts;
        }
    }
}
