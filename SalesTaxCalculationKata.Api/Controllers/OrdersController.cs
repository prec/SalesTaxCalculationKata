using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesTaxCalculationKata.Core;
using SalesTaxCalculationKata.Core.Models;
using SalesTaxCalculationKata.Data;
using SalesTaxCalculationKata.Data.Models;

namespace SalesTaxCalculationKata.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly KataDbContext _context;
        private readonly IMapper _mapper;

        public OrdersController(KataDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
        {
            return await _context.Orders.Select(o => _mapper.Map<OrderModel>(o)).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return _mapper.Map<OrderModel>(order);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderModel orderModel)
        {
            var order = _mapper.Map<Order>(orderModel);

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<OrderModel>> PostOrder()
        {
            var order = new Order();
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        [HttpPut("{id}/Complete")]
        public async Task<ActionResult<OrderModel>> CompleteOrder(int id)
        {
            var register = await SetupTransactionRegister();

            var order = await _context.Orders.FindAsync(id);
            var orderModel = _mapper.Map<OrderModel>(order);

            orderModel = register.CompleteOrder(orderModel);
            _mapper.Map(orderModel, order);

            await _context.SaveChangesAsync();

            return orderModel;
        }

        private async Task<TransactionRegister> SetupTransactionRegister()
        {
            var taxes = await _context.Taxes.Select(t => _mapper.Map<TaxModel>(t)).ToListAsync();
            var taxCategories = await _context.TaxCategories.Select(tc => _mapper.Map<TaxCategoryModel>(tc)).ToListAsync();

            return new TransactionRegister(taxes, taxCategories);
        }

        [HttpPost("{id}/AddProduct")]
        public async Task<ActionResult<OrderModel>> AddProductToOrder(int id, [FromBody] ProductModel productModel)
        {
            var order = await _context.Orders.FindAsync(id);
            var product = await _context.Products.FindAsync(productModel.ProductId);
            productModel = _mapper.Map<ProductModel>(product);

            if (order == null)
            {
                return NotFound();
            }

            var orderModel = _mapper.Map<OrderModel>(order);

            var register = await SetupTransactionRegister();

            orderModel = register.AddItem(productModel, orderModel);
            _mapper.Map(orderModel, order);

            await _context.SaveChangesAsync();

            return orderModel;
        }


        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderModel>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderModel>(order);
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
