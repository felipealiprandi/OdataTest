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
    public class PedidoProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PedidoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoProduto>>> GetPedidoProdutos()
        {
            return await _context.PedidoProdutos.ToListAsync();
        }

        // GET: api/PedidoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoProduto>> GetPedidoProduto(int id)
        {
            var pedidoProduto = await _context.PedidoProdutos.FindAsync(id);

            if (pedidoProduto == null)
            {
                return NotFound();
            }

            return pedidoProduto;
        }

        // PUT: api/PedidoProdutos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoProduto(int id, PedidoProduto pedidoProduto)
        {
            if (id != pedidoProduto.ID)
            {
                return BadRequest();
            }

            _context.Entry(pedidoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoProdutoExists(id))
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

        // POST: api/PedidoProdutos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PedidoProduto>> PostPedidoProduto(PedidoProduto pedidoProduto)
        {
            _context.PedidoProdutos.Add(pedidoProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPedidoProduto", new { id = pedidoProduto.ID }, pedidoProduto);
        }

        // DELETE: api/PedidoProdutos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PedidoProduto>> DeletePedidoProduto(int id)
        {
            var pedidoProduto = await _context.PedidoProdutos.FindAsync(id);
            if (pedidoProduto == null)
            {
                return NotFound();
            }

            _context.PedidoProdutos.Remove(pedidoProduto);
            await _context.SaveChangesAsync();

            return pedidoProduto;
        }

        private bool PedidoProdutoExists(int id)
        {
            return _context.PedidoProdutos.Any(e => e.ID == id);
        }
    }
}
