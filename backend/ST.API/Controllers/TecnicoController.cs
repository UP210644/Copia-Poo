using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ST.Core.Entidades;
using ST.Infrastructure.Data;

namespace ST.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TecnicoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Tecnico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tecnico>>> GetTecnicos()
        {
            return await _context.Tecnicos.ToListAsync();
        }

        // GET: api/Tecnico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tecnico>> GetTecnico(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);

            if (tecnico == null)
            {
                return NotFound();
            }

            return tecnico;
        }

        // PUT: api/Tecnico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Id_Tecnico}")]
        public async Task<IActionResult> PutTecnico(int id, Tecnico tecnico)
        {
            if (id != tecnico.Id_Tecnico)
            {
                return BadRequest();
            }

            _context.Entry(tecnico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TecnicoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tecnico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tecnico>> PostTecnico(Tecnico tecnico)
        {
            _context.Tecnicos.Add(tecnico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTecnico", new { id = tecnico.Id_Tecnico }, tecnico);
        }

        // DELETE: api/Tecnico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTecnico(int id)
        {
            var tecnico = await _context.Tecnicos.FindAsync(id);
            if (tecnico == null)
            {
                return NotFound();
            }

            _context.Tecnicos.Remove(tecnico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TecnicoExists(int id)
        {
            return _context.Tecnicos.Any(e => e.Id_Tecnico == id);
        }
    }
}
