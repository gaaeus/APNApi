using System.Collections.Generic;
using System.Threading.Tasks;
using APN.DBContexts;
using APN.Model;
//using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        // GET: api/Image
        [HttpGet]
        public async Task<IEnumerable<Image>> Get(uint noteId)
        {
            var imageDBcontext = HttpContext.RequestServices.GetService(typeof(ImageDBContext)) as ImageDBContext;

            return await imageDBcontext.GetImages(noteId);
        }

        // GET: api/Image/5
        [HttpGet("{id}", Name = "GetImage")]
        public async Task<Image> Get(uint imageId, uint noteId)
        {
            var imageDBcontext = HttpContext.RequestServices.GetService(typeof(ImageDBContext)) as ImageDBContext;

            return await imageDBcontext.GetImage(imageId, noteId);
        }

        // POST: api/Image
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Image/5
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
