using BloggersHub.DTO;
using BloggersHub.Models;
using BloggersHub.Repository;

namespace BloggersHub.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentsRepository;

        public CommentService(ICommentRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public Task<int> AddComment(CommentDTO comment, int blogId)
        {
            var comments = new Comments()
            {
                BlogId = blogId,
                UserId = 1,
                Content = comment.Content,
                CreatedAt = DateTime.UtcNow,
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
