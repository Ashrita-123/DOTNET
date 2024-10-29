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
    public class OrderTblsController : Controller
    {
        private readonly ProductDbContext _context;

        public OrderTblsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: OrderTbls
        public async Task<IActionResult> Index()
        {
            var productDbContext = _context.OrderTbls.Include(o => o.Customer);
            return View(await productDbContext.ToListAsync());
        }

        // GET: OrderTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTbl = await _context.OrderTbls
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            return View(orderTbl);
        }

        // GET: OrderTbls/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.CustomerTbls, "CustomerId", "CustomerId");
            return View();
        }

        // POST: OrderTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId")] OrderTbl orderTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerTbls, "CustomerId", "CustomerId", orderTbl.CustomerId);
            return View(orderTbl);
        }

        // GET: OrderTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTbl = await _context.OrderTbls.FindAsync(id);
            if (orderTbl == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.CustomerTbls, "CustomerId", "CustomerId", orderTbl.CustomerId);
            return View(orderTbl);
        }

        // POST: OrderTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId")] OrderTbl orderTbl)
        {
            if (id != orderTbl.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderTblExists(orderTbl.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.CustomerTbls, "CustomerId", "CustomerId", orderTbl.CustomerId);
            return View(orderTbl);
        }

        // GET: OrderTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderTbl = await _context.OrderTbls
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderTbl == null)
            {
                return NotFound();
            }

            return View(orderTbl);
        }

        // POST: OrderTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderTbl = await _context.OrderTbls.FindAsync(id);
            if (orderTbl != null)
            {
                _context.OrderTbls.Remove(orderTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderTblExists(int id)
        {
            return _context.OrderTbls.Any(e => e.OrderId == id);
        }
    }
}
