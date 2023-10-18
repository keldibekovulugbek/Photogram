using FileBaseContext.Abstractions.Models.FileSet;
using Photogram.Entities;

namespace Photogram.Data
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }

        public IFileSet<Post, Guid> Posts { get; }

        ValueTask SaveChangesAsync();
    }
}
