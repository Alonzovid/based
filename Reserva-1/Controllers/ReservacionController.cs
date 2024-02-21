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
    public class ReservacionController : ControllerBase
    {
        private readonly ReservacionContext _context;

        public ReservacionController(ReservacionContext context)
        {
            _context = context;
        }

        // GET: api/Reservacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservacion>>> GetReservaciones()
        {
          if (_context.Reservacions == null)
          {
              return NotFound();
          }
            return await _context.Reservacions.ToListAsync();
        }

        // GET: api/Reservacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservacion>> GetReservacion(int id)
        {
          if (_context.Reservacions == null)
          {
              return NotFound();
          }
            var reservacion = await _context.Reservacions.FindAsync(id);

            if (reservacion == null)
            {
                return NotFound();
            }

            return reservacion;
        }

        // PUT: api/Reservacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservacion(int id, Reservacion reservacion)
        {
            if (id != reservacion.ReservacionId)
            {
                return BadRequest();
            }

            _context.Entry(reservacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservacionExists(id))
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

        // POST: api/Reservacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservacion>> PostReservacion(Reservacion reservacion)
        {
          if (_context.Reservacions == null)
          {
              return Problem("Entity set 'ReservacionContext.Reservacions'  is null.");
          }
            _context.Reservacions.Add(reservacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservacion", new { id = reservacion.ReservacionId }, reservacion);
        }

        // DELETE: api/Reservacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            if (_context.Reservacions == null)
            {
                return NotFound();
            }
            var reservacion = await _context.Reservacions.FindAsync(id);
            if (reservacion == null)
            {
                return NotFound();
            }

            _context.Reservacions.Remove(reservacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservacionExists(int id)
        {
            return (_context.Reservacions?.Any(e => e.ReservacionId == id)).GetValueOrDefault();
        }
    }
}
