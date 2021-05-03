using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdataTest.Models;

namespace OdataTest.Controllers
{
    [EnableQuery]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePedidosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientePedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientePedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientePedido>>> GetClientePedidos()
        {
            return await _context.ClientePedidos.ToListAsync();
        }

        // GET: api/ClientePedidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientePedido>> GetClientePedido(int id)
        {
            var clientePedido = await _context.ClientePedidos.FindAsync(id);

            if (clientePedido == null)
            {
                return NotFound();
            }

            return clientePedido;
        }

        // PUT: api/ClientePedidos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClientePedido(int id, ClientePedido clientePedido)
        {
            if (id != clientePedido.ID)
            {
                return BadRequest();
            }

            _context.Entry(clientePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientePedidoExists(id))
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

        // POST: api/ClientePedidos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ClientePedido>> PostClientePedido(ClientePedido clientePedido)
        {
            _context.ClientePedidos.Add(clientePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClientePedido", new { id = clientePedido.ID }, clientePedido);
        }

        // DELETE: api/ClientePedidos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientePedido>> DeleteClientePedido(int id)
        {
            var clientePedido = await _context.ClientePedidos.FindAsync(id);
            if (clientePedido == null)
            {
                return NotFound();
            }

            _context.ClientePedidos.Remove(clientePedido);
            await _context.SaveChangesAsync();

            return clientePedido;
        }

        private bool ClientePedidoExists(int id)
        {
            return _context.ClientePedidos.Any(e => e.ID == id);
        }
    }
}
