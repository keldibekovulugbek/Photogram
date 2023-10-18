using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photogram.Entities;
using Photogram.Service;

namespace P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service) 
        {
            _service = service;
        }

        [HttpPost("register")]
        public async ValueTask<IActionResult> CreateAsync(User user)
        {
            await _service.CreateAsync(user);

            return Ok(user);
        }
        [HttpPost("imageUpload")]
        public async ValueTask<IActionResult> UploadImageAync(Guid id,[FromForm] UploadImageDTO imageDTO)
        {
            await _service.UploadImageAsync(id, imageDTO);

            return Ok();
        }

        [HttpDelete("{userId:guid}")]
        public async ValueTask<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
