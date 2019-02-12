using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTaxCalculationKata.Core.Models;
using SalesTaxCalculationKata.Data;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCategoriesController : ControllerBase
    {
        private readonly KataDbContext _context;
        private readonly IMapper _mapper;

        public TaxCategoriesController(KataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TaxCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxCategoryModel>>> GetTaxCategories()
        {
            return await _context.TaxCategories.Select(tc => _mapper.Map<TaxCategoryModel>(tc)).ToListAsync();
        }

        // GET: api/TaxCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxCategoryModel>> GetTaxCategory(int id)
        {
            var taxCategory = await _context.TaxCategories.FindAsync(id);

            if (taxCategory == null)
            {
                return NotFound();
            }

            return _mapper.Map<TaxCategoryModel>(taxCategory);
        }

        // PUT: api/TaxCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxCategory(int id, TaxCategoryModel taxCategoryModel)
        {
            var taxCategory = _mapper.Map<TaxCategory>(taxCategoryModel);

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
        public async Task<ActionResult<TaxCategoryModel>> PostTaxCategory(TaxCategoryModel taxCategoryModel)
        {
            var taxCategory = _mapper.Map<TaxCategory>(taxCategoryModel);

            _context.TaxCategories.Add(taxCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxCategory", new { id = taxCategory.TaxCategoryId }, taxCategory);
        }

        // DELETE: api/TaxCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxCategoryModel>> DeleteTaxCategory(int id)
        {
            var taxCategory = await _context.TaxCategories.FindAsync(id);
            if (taxCategory == null)
            {
                return NotFound();
            }

            _context.TaxCategories.Remove(taxCategory);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaxCategoryModel>(taxCategory);
        }

        private bool TaxCategoryExists(int id)
        {
            return _context.TaxCategories.Any(e => e.TaxCategoryId == id);
        }
    }
}
