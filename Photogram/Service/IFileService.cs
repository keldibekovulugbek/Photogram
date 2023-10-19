using System;

namespace Photogram.Service
{
    public interface IFileService
    {
        string FolderName { get; }

        ValueTask<string> SaveImageAsync(Guid user, IFormFile image);

        ValueTask<bool> DeleteAsync(string imageName);
        public bool DeleteUserFolder(Guid userId);
    }
}
