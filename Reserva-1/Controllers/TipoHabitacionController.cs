using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reserva_1.Models;

namespace Reserva_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoHabitacionController : ControllerBase
    {
        private readonly ReservacionContext _context;

        public TipoHabitacionController(ReservacionContext context)
        {
            _context = context;
        }

        // GET: api/TipoHabitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoHabitacion>>> GetTipoHabitaciones()
        {
          if (_context.TipoHabitacions == null)
          {
              return NotFound();
          }
            return await _context.TipoHabitacions.ToListAsync();
        }

        // GET: api/TipoHabitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoHabitacion>> GetTipoHabitacion(int id)
        {
          if (_context.TipoHabitacions == null)
          {
              return NotFound();
          }
            var tipoHabitacion = await _context.TipoHabitacions.FindAsync(id);

            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return tipoHabitacion;
        }

        // PUT: api/TipoHabitacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoHabitacion(int id, TipoHabitacion tipoHabitacion)
        {
            if (id != tipoHabitacion.TipoHabitacionId)
            {
                return BadRequest();
            }

            _context.Entry(tipoHabitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoHabitacionExists(id))
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

        // POST: api/TipoHabitacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoHabitacion>> PostTipoHabitacion(TipoHabitacion tipoHabitacion)
        {
          if (_context.TipoHabitacions == null)
          {
              return Problem("Entity set 'ReservacionContext.TipoHabitacions'  is null.");
          }
            _context.TipoHabitacions.Add(tipoHabitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoHabitacion", new { id = tipoHabitacion.TipoHabitacionId }, tipoHabitacion);
        }

        // DELETE: api/TipoHabitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoHabitacion(int id)
        {
            if (_context.TipoHabitacions == null)
            {
                return NotFound();
            }
            var tipoHabitacion = await _context.TipoHabitacions.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            _context.TipoHabitacions.Remove(tipoHabitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoHabitacionExists(int id)
        {
            return (_context.TipoHabitacions?.Any(e => e.TipoHabitacionId == id)).GetValueOrDefault();
        }
    }
}
