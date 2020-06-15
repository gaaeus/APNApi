using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APN.DBContexts;
using APN.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        // GET: api/Note
        [HttpGet]
        public async Task<IEnumerable<Note>> Get()
        {
            var noteDBContext= HttpContext.RequestServices.GetService(typeof(NoteDBContext)) as NoteDBContext;

            return await noteDBContext.GetNotes();
        }

        // GET: api/Note/5
        [HttpGet("{id}", Name = "GetNote")]
        public async Task<Note> Get(int id)
        {
            var noteDBContext = HttpContext.RequestServices.GetService(typeof(NoteDBContext)) as NoteDBContext;

            return await noteDBContext.GetNote(id);
        }

        // POST: api/Note
        [HttpPost]
        [DisableCors]
        public async Task<int> Post([FromBody] Note note)
        {
            var noteDBContext = HttpContext.RequestServices.GetService(typeof(NoteDBContext)) as NoteDBContext;
            note.APP_GUID = Guid.NewGuid().ToString();
            return await noteDBContext.CreateNote(note);
        }

        // PUT: api/Note/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Note note)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
