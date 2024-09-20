
using BloggersHub.DTO;
using BloggersHub.Models;
using BloggersHub.Repository;
using FirebaseAdmin.Auth;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace BloggersHub.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly IBlogsRepository _repository;
        private readonly IHttpContextAccessor _contextAccessor;
        public BlogsService(IBlogsRepository repository, IHttpContextAccessor httpContextAccessor) {
            _repository = repository;
            _contextAccessor = httpContextAccessor;
        }
        public async Task<List<Models.Blogs>> GetBlogs()
        {
            var posts = await _repository.GetBlogs();
            return posts;
        }

        public async Task<int> CreateBlogs(BlogsDTO blogsDTO)
        {
            var user = _contextAccessor.HttpContext?.Items["User"] as FirebaseToken;
            if (user == null)
            {
                Console.WriteLine("User not authenticated");
            }

            var blog = new Blogs
            {
                Title = blogsDTO.Title,
                Content = blogsDTO.Content,
                CreatedAt = DateTime.UtcNow,
                UserName = user.Claims["email"].ToString(),
                Name = user.Claims["name"].ToString(),
            };
            var post = await _repository.CreateBlog(blog);
            return post;
        }

        public async Task<List<Blogs>> GetMyBlogs()
        {
            var user = _contextAccessor.HttpContext?.Items["User"] as FirebaseToken;
            var userName = user.Claims["email"].ToString();
            var posts = await _repository.GetMyBlogs(userName);
            return posts;
        }
    }
}
