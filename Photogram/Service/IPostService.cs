using Photogram.Entities;

namespace Photogram.Service
{
    public interface IPostService
    {
        ValueTask<ICollection<Post>> Get(CancellationToken cancellationToken = default);
        ValueTask<Post> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        ValueTask<Post> CreateAsync(Post post, UploadImageDTO imageDTO, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Post> UpdateAsync(Guid id, Post post, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Post> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default);
    }
}
