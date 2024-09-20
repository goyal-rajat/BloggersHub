using BloggersHub.DTO;
using BloggersHub.Models;
using BloggersHub.Repository;
using FirebaseAdmin.Auth;

namespace BloggersHub.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentsRepository;
        private readonly IHttpContextAccessor _contextAccessor;

        public CommentService(ICommentRepository commentsRepository, IHttpContextAccessor httpContextAccessor)
        {
            _commentsRepository = commentsRepository;
            _contextAccessor = httpContextAccessor;
        }

        public Task<int> AddComment(CommentDTO comment, int blogId)
        {
            var user = _contextAccessor.HttpContext?.Items["User"] as FirebaseToken;
            var comments = new Comments()
            {
                BlogId = blogId,
                Content = comment.Content,
                CreatedAt = DateTime.UtcNow,
                UserName = user.Claims["email"].ToString(),
                Name = user.Claims["name"].ToString(),
            };

            var res = _commentsRepository.AddComment(comments);
            return res;
        }

        public Task<IEnumerable<Comments>> GetComments(int id)
        {
            var commentts = _commentsRepository.GetCommentsAsync(id);
            return commentts;
        }
    }
}
