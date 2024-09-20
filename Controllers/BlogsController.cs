using BloggersHub.DTO;
using BloggersHub.Models;
using BloggersHub.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace BloggersHub.Controllers
{
    [Route("api/v1/blog/")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService _blogs;
        public BlogsController(IBlogsService blogs) {
            _blogs = blogs;
        }

        [HttpGet("blogs")]
        public async Task<IActionResult> GetBlogs()
        {
            var posts = await _blogs.GetBlogs();
            return Ok(posts);
        }

        [HttpGet("myblogs")]
        public async Task<IActionResult> GetMyBlogs()
        {
            //hardcoded till firebase works
            var posts = await _blogs.GetMyBlogs();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogs([FromBody] BlogsDTO blogsDTO)
        {
            //var user = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var posts = await _blogs.CreateBlogs(blogsDTO);
            return Ok(posts);
        }

    }
}
