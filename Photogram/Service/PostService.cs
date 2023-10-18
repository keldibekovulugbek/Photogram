using Photogram.Data;
using Photogram.Entities;

namespace Photogram.Service
{
    public class PostService : IPostService
    {
        private readonly IDataContext _dataContext;
        private readonly IFileService _fileService;

        public PostService(IDataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public async ValueTask<Post> CreateAsync(Post post, UploadImageDTO imageDTO, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            string path = await _fileService.SaveImageAsync(post.UserId, imageDTO.Image);
            post.ImagePath = path;

            await _dataContext.Posts.AddAsync(post);
            await _dataContext.SaveChangesAsync();
            return post;
        }

        public ValueTask<Post> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ICollection<Post>> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<Post> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity =  _dataContext.Posts.FirstOrDefault(t=> t.Id==id);

            return entity;
        }

        public ValueTask<Post> UpdateAsync(Guid id, Post post, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
