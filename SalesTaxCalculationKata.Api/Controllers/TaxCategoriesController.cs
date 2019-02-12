using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTaxCalculationKata.Data;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCategoriesController : ControllerBase
    {
        private readonly KataDbContext _context;

        public TaxCategoriesController(KataDbContext context)
        {
            _context = context;
        }

        // GET: api/TaxCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxCategory>>> GetTaxCategories()
        {
            return await _context.TaxCategories.ToListAsync();
        }

        // GET: api/TaxCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxCategory>> GetTaxCategory(int id)
        {
            var taxCategory = await _context.TaxCategories.FindAsync(id);

            if (taxCategory == null)
            {
                return NotFound();
            }

            return taxCategory;
        }

        // PUT: api/TaxCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxCategory(int id, TaxCategory taxCategory)
        {
            if (id != taxCategory.TaxCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(taxCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxCategoryExists(id))
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

        // POST: api/TaxCategories
        [HttpPost]
        public async Task<ActionResult<TaxCategory>> PostTaxCategory(TaxCategory taxCategory)
        {
            _context.TaxCategories.Add(taxCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxCategory", new { id = taxCategory.TaxCategoryId }, taxCategory);
        }

        // DELETE: api/TaxCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxCategory>> DeleteTaxCategory(int id)
        {
            var taxCategory = await _context.TaxCategories.FindAsync(id);
            if (taxCategory == null)
            {
                return NotFound();
            }

            _context.TaxCategories.Remove(taxCategory);
            await _context.SaveChangesAsync();

            return taxCategory;
        }

        private bool TaxCategoryExists(int id)
        {
            return _context.TaxCategories.Any(e => e.TaxCategoryId == id);
        }
    }
}
