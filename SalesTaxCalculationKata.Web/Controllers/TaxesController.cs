using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTaxCalculationKata.Core.Models;
using SalesTaxCalculationKata.Data;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxesController : ControllerBase
    {
        private readonly KataDbContext _context;
        private readonly IMapper _mapper;

        public TaxesController(KataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Taxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxModel>>> GetTaxes()
        {
            return await _context.Taxes.Select(t => _mapper.Map<TaxModel>(t)).ToListAsync();
        }

        // GET: api/Taxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxModel>> GetTax(int id)
        {
            var tax = await _context.Taxes.FindAsync(id);

            if (tax == null)
            {
                return NotFound();
            }

            return _mapper.Map<TaxModel>(tax);
        }

        // PUT: api/Taxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTax(int id, TaxModel taxModel)
        {
            var tax = _mapper.Map<Tax>(taxModel);

            if (id != tax.TaxId)
            {
                return BadRequest();
            }

            _context.Entry(tax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxExists(id))
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

        // POST: api/Taxes
        [HttpPost]
        public async Task<ActionResult<TaxModel>> PostTax(TaxModel taxModel)
        {
            var tax = _mapper.Map<Tax>(taxModel);

            _context.Taxes.Add(tax);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTax", new { id = tax.TaxId }, tax);
        }

        // DELETE: api/Taxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxModel>> DeleteTax(int id)
        {
            var tax = await _context.Taxes.FindAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            _context.Taxes.Remove(tax);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaxModel>(tax);
        }

        private bool TaxExists(int id)
        {
            return _context.Taxes.Any(e => e.TaxId == id);
        }
    }
}
