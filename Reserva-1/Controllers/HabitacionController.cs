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
    public class HabitacionController : ControllerBase
    {
        private readonly ReservacionContext _context;

        public HabitacionController(ReservacionContext context)
        {
            _context = context;
        }

        // GET: api/Habitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitaciones()
        {
          if (_context.Habitacions == null)
          {
              return NotFound();
          }
            return await _context.Habitacions.Include(x => x.TipoHabitacion).ToListAsync();
        }

        // GET: api/Habitacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Habitacion>> GetHabitacion(int id)
        {
          if (_context.Habitacions == null)
          {
              return NotFound();
          }
            var habitacion = await _context.Habitacions.Include(x => x.TipoHabitacion).FirstOrDefaultAsync(x => x.HabitacionId == id);

            if (habitacion == null)
            {
                return NotFound();
            }

            return habitacion;
        }

        // PUT: api/Habitacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitacion(int id, Habitacion habitacion)
        {
            if (id != habitacion.HabitacionId)
            {
                return BadRequest();
            }

            _context.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(id))
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

        // POST: api/Habitacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habitacion>> PostHabitacion(Habitacion habitacion)
        {
          if (_context.Habitacions == null)
          {
              return Problem("Entity set 'ReservacionContext.Habitacions'  is null.");
          }
            _context.Habitacions.Add(habitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitacion", new { id = habitacion.HabitacionId }, habitacion);
        }

        // DELETE: api/Habitacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabitacion(int id)
        {
            if (_context.Habitacions == null)
            {
                return NotFound();
            }
            var habitacion = await _context.Habitacions.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.Habitacions.Remove(habitacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitacionExists(int id)
        {
            return (_context.Habitacions?.Any(e => e.HabitacionId == id)).GetValueOrDefault();
        }
    }
}
