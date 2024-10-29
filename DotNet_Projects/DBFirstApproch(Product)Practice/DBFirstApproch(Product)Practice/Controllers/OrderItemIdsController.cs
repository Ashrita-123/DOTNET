using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstApproch_Product_Practice.Models;

namespace DBFirstApproch_Product_Practice.Controllers
{
    public class OrderItemIdsController : Controller
    {
        private readonly ProductDbContext _context;

        public OrderItemIdsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: OrderItemIds
        public async Task<IActionResult> Index()
        {
            var productDbContext = _context.OrderItemIds.Include(o => o.Order).Include(o => o.Propduct);
            return View(await productDbContext.ToListAsync());
        }

        // GET: OrderItemIds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemId = await _context.OrderItemIds
                .Include(o => o.Order)
                .Include(o => o.Propduct)
                .FirstOrDefaultAsync(m => m.OrderItemId1 == id);
            if (orderItemId == null)
            {
                return NotFound();
            }

            return View(orderItemId);
        }

        // GET: OrderItemIds/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId");
            ViewData["PropductId"] = new SelectList(_context.ProductTbls, "ProductId", "ProductId");
            return View();
        }

        // POST: OrderItemIds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderItemId1,OrderId,PropductId,NoOfItems")] OrderItemId orderItemId)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItemId);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId", orderItemId.OrderId);
            ViewData["PropductId"] = new SelectList(_context.ProductTbls, "ProductId", "ProductId", orderItemId.PropductId);
            return View(orderItemId);
        }

        // GET: OrderItemIds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemId = await _context.OrderItemIds.FindAsync(id);
            if (orderItemId == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId", orderItemId.OrderId);
            ViewData["PropductId"] = new SelectList(_context.ProductTbls, "ProductId", "ProductId", orderItemId.PropductId);
            return View(orderItemId);
        }

        // POST: OrderItemIds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderItemId1,OrderId,PropductId,NoOfItems")] OrderItemId orderItemId)
        {
            if (id != orderItemId.OrderItemId1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItemId);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemIdExists(orderItemId.OrderItemId1))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId", orderItemId.OrderId);
            ViewData["PropductId"] = new SelectList(_context.ProductTbls, "ProductId", "ProductId", orderItemId.PropductId);
            return View(orderItemId);
        }

        // GET: OrderItemIds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemId = await _context.OrderItemIds
                .Include(o => o.Order)
                .Include(o => o.Propduct)
                .FirstOrDefaultAsync(m => m.OrderItemId1 == id);
            if (orderItemId == null)
            {
                return NotFound();
            }

            return View(orderItemId);
        }

        // POST: OrderItemIds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItemId = await _context.OrderItemIds.FindAsync(id);
            if (orderItemId != null)
            {
                _context.OrderItemIds.Remove(orderItemId);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemIdExists(int id)
        {
            return _context.OrderItemIds.Any(e => e.OrderItemId1 == id);
        }
    }
}
