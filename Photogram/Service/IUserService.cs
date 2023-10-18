using Microsoft.AspNetCore.Mvc;
using Photogram.Entities;

namespace Photogram.Service
{
    public interface IUserService
    {
        ValueTask<ICollection<User>> Get (CancellationToken cancellationToken = default);
        ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        ValueTask<User> CreateAsync(User user, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> UpdateAsync(Guid id, User user, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<User> UploadImageAsync(Guid id, UploadImageDTO imageDTO, bool SaveChanges = true, CancellationToken cancellationToken = default);
    }
}
