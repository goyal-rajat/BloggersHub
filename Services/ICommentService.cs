using BloggersHub.DTO;
using BloggersHub.Models;

namespace BloggersHub.Services
{
    public interface ICommentService
    {
        public Task<IEnumerable<Comments>> GetComments(int id);
        public Task<int> AddComment(CommentDTO comment, int blogId);
    }
}
