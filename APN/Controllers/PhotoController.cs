using System.Collections.Generic;
using System.Threading.Tasks;
using APN.DBContexts;
using APN.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        // GET: api/Photo
        [HttpGet]
        public async Task<IEnumerable<Photo>> Get(uint noteId)
        {
            var PhotoDBcontext = HttpContext.RequestServices.GetService(typeof(PhotoDBContext)) as PhotoDBContext;

            return await PhotoDBcontext.GetPhotos(noteId);
        }

        // GET: api/Photo/5
        [HttpGet("{id}", Name = "GetPhoto")]
        public async Task<Photo> Get(uint photoId, uint noteId)
        {
            var PhotoDBcontext = HttpContext.RequestServices.GetService(typeof(PhotoDBContext)) as PhotoDBContext;

            return await PhotoDBcontext.GetPhoto(photoId, noteId);
        }

        // POST: api/Photo
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Photo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
