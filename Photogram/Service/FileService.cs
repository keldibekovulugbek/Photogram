namespace Photogram.Service
{
    public class FileService : IFileService
    {
        private readonly string _folderName = "images";
        private readonly string _basePath;

       public FileService(IWebHostEnvironment webHost)
        {
            _basePath = webHost.WebRootPath;
        }

        public string FolderName => _folderName;

        public async ValueTask<bool> DeleteAsync(string imageName)
        {
            var path = Path.Combine(_basePath, _folderName, imageName);

            if (!File.Exists(path))
            {
                return false;
            }

            File.Delete(path);

            return true;

        }

        public async ValueTask<string> SaveImageAsync(Guid userId, IFormFile image)
        {
            var imagesPath = Path.Combine(_basePath, _folderName); // wwwroot/images
            
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }

            if (!Directory.Exists(imagesPath))
            { 
                Directory.CreateDirectory(imagesPath);
            }

            var userFolderPath = Path.Combine(imagesPath, userId.ToString());  // wwwroot/images/4fdghjkls7239ds8sdf4

            if (!Directory.Exists(userFolderPath))
            {
                Directory.CreateDirectory(userFolderPath);
            }

            var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName); // 12fgusady78278282.jpeg

            var imagePath = Path.Combine(userFolderPath, imageName); // wwwroot/images/4fdghjkls7239ds8sdf4/12fgusady78278282.jpeg

            var stream = File.Create(imagePath);
            await image.CopyToAsync(stream);
            stream.Close();

            return imageName;
        }
    }
}
