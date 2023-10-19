using Photogram.Data;
using Photogram.Entities;
using Photogram.Service;
using System.Text.RegularExpressions;

namespace ToDoList.Service
{
    public class UserService : IUserService
    {
        private readonly IDataContext _dataContext;
        private readonly IFileService _fileService;

        public UserService(IDataContext dataContext, IFileService fileService)
        {
            _dataContext = dataContext;
            _fileService = fileService;
        }

        public bool IsExist(User user)
        {
            var existUser = _dataContext.Users.FirstOrDefault(u => u.Email.Equals(user.Email));

            if (existUser == null) return false;
           
            return true;
        }

        public async ValueTask<User> CreateAsync(User user, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            if (!IsValidUser(user))
                throw new ArgumentException("Invalid user.");

            if (IsExist(user))
                throw new ArgumentException("This user already exists");

            var entity = await _dataContext.Users.AddAsync(user);

            await _dataContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async ValueTask<User> DeleteAsync(Guid id, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            var user = await _dataContext.Users.FindAsync(id, cancellationToken);

            if (user == null) throw new Exception();

            await _dataContext.Users.RemoveAsync(user);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        public ValueTask<ICollection<User>> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public ValueTask<User> UpdateAsync(Guid id, User user, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<User> UploadImageAsync(Guid id, UploadImageDTO imageDTO, bool SaveChanges = true, CancellationToken cancellationToken = default)
        {
            var user = await _dataContext.Users.FindAsync(id, cancellationToken);
           
            if(user == null) throw new Exception();


            user.ImagePath = await _fileService.SaveImageAsync(id,imageDTO.Image);
            await _dataContext.SaveChangesAsync();

            return user;
        }

        private bool IsValidUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Firstname) || string.IsNullOrWhiteSpace(user.Lastname))
                return false;

            if (user.Password.Length < 8)
                return false;

            if (!IsValidEmailAddress(user.Email))
                return false;

            return true;
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            var pattern = @"^[a-zA-Z]{4,}[a-zA-Z0-9]*(\.[a-zA-Z0-9]{4,})*@[a-zA-Z0-9]{4,}\.[a-zA-Z]{2,}[a-zA-Z]*$";

            return Regex.IsMatch(emailAddress, pattern);
        }
    }
}