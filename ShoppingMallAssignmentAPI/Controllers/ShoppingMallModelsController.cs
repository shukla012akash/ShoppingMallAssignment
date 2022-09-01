using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMallAssignmentDB.DBConnections;
using ShoppingMallAssignmentDB.Models;

namespace ShoppingMallAssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingMallModelsController : ControllerBase
    {
        private readonly ShoppingMallDBContext _context;

        public ShoppingMallModelsController(ShoppingMallDBContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingMallModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingMallModel>>> GetShoppingMallModels()
        {
          if (_context.ShoppingMallModels == null)
          {
              return NotFound();
          }
            return await _context.ShoppingMallModels.ToListAsync();
        }

        // GET: api/ShoppingMallModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingMallModel>> GetShoppingMallModel(int id)
        {
          if (_context.ShoppingMallModels == null)
          {
              return NotFound();
          }
            var shoppingMallModel = await _context.ShoppingMallModels.FindAsync(id);

            if (shoppingMallModel == null)
            {
                return NotFound();
            }

            return shoppingMallModel;
        }

        // PUT: api/ShoppingMallModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutShoppingMallModel(int id, ShoppingMallModel shoppingMallModel)
        {
            if (id != shoppingMallModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(shoppingMallModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingMallModelExists(id))
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

        // POST: api/ShoppingMallModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShoppingMallModel>> PostShoppingMallModel(ShoppingMallModel shoppingMallModel)
        {
          if (_context.ShoppingMallModels == null)
          {
              return Problem("Entity set 'ShoppingMallDBContext.ShoppingMallModels'  is null.");
          }
            _context.ShoppingMallModels.Add(shoppingMallModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingMallModel", new { id = shoppingMallModel.ID }, shoppingMallModel);
        }

        // DELETE: api/ShoppingMallModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingMallModel(int id)
        {
            if (_context.ShoppingMallModels == null)
            {
                return NotFound();
            }
            var shoppingMallModel = await _context.ShoppingMallModels.FindAsync(id);
            if (shoppingMallModel == null)
            {
                return NotFound();
            }

            _context.ShoppingMallModels.Remove(shoppingMallModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingMallModelExists(int id)
        {
            return (_context.ShoppingMallModels?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
