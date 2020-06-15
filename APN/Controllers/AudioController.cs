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
    public class AudioController : ControllerBase
    {
        // GET: api/Audio/5
        [HttpGet("{noteId}")]
        public async Task<IEnumerable<Audio>> Get(uint noteId)
        {
            var audioDBcontext = HttpContext.RequestServices.GetService(typeof(AudioDBContext)) as AudioDBContext;

            return await audioDBcontext.GetAudios(noteId);
        }

        // GET: api/Audio/5/11
        [HttpGet("{noteId}/{id}", Name = "GetAudio")]
        public async Task<Audio> Get(uint noteId, uint id)
        {
            var audioDBcontext = HttpContext.RequestServices.GetService(typeof(AudioDBContext)) as AudioDBContext;

            return await audioDBcontext.GetAudio(noteId, id);
        }

        // POST: api/Audio
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Audio/5
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
