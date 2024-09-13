using BloggersHub.Models;

namespace BloggersHub.Repository
{
    public interface ICommentRepository
    {
        public Task<IEnumerable<Comments>> GetCommentsAsync(int blogId);
        public Task<int> AddComment(Comments comments);
    }
}
