using BloggersHub.DTO;
using BloggersHub.Models;
using BloggersHub.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggersHub.Controllers
{
    [Route("api/v1/blog/{blogId}/comment")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comments>>> GetComments(int blogId)
        {
            var comments = await _commentService.GetComments(blogId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<ActionResult<Comments>> AddComment([FromBody] CommentDTO commentDTO, int blogId)
        {
            var res = await _commentService.AddComment(commentDTO, blogId);
            return Ok(res);
        }
    }
}
