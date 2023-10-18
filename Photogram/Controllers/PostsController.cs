using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Photogram.Entities;
using Photogram.Service;

namespace Photogram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _service;

        public PostsController(IPostService postService) 
        {
            _service = postService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateAsync([FromForm]Post post, [FromForm] UploadImageDTO imageDTO)
                => Ok(await _service.CreateAsync(post, imageDTO));
    }
}
