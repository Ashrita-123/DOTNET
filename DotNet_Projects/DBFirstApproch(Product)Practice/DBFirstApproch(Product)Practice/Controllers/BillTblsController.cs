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
    public class BillTblsController : Controller
    {
        private readonly ProductDbContext _context;

        public BillTblsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: BillTbls
        public async Task<IActionResult> Index()
        {
            var productDbContext = _context.BillTbls.Include(b => b.Order);
            return View(await productDbContext.ToListAsync());
        }

        // GET: BillTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billTbl = await _context.BillTbls
                .Include(b => b.Order)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (billTbl == null)
            {
                return NotFound();
            }

            return View(billTbl);
        }

        // GET: BillTbls/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId");
            return View();
        }

        // POST: BillTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BillId,OrderId")] BillTbl billTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId", billTbl.OrderId);
            return View(billTbl);
        }

        // GET: BillTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billTbl = await _context.BillTbls.FindAsync(id);
            if (billTbl == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId", billTbl.OrderId);
            return View(billTbl);
        }

        // POST: BillTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BillId,OrderId")] BillTbl billTbl)
        {
            if (id != billTbl.BillId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillTblExists(billTbl.BillId))
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
            ViewData["OrderId"] = new SelectList(_context.OrderTbls, "OrderId", "OrderId", billTbl.OrderId);
            return View(billTbl);
        }

        // GET: BillTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billTbl = await _context.BillTbls
                .Include(b => b.Order)
                .FirstOrDefaultAsync(m => m.BillId == id);
            if (billTbl == null)
            {
                return NotFound();
            }

            return View(billTbl);
        }

        // POST: BillTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billTbl = await _context.BillTbls.FindAsync(id);
            if (billTbl != null)
            {
                _context.BillTbls.Remove(billTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillTblExists(int id)
        {
            return _context.BillTbls.Any(e => e.BillId == id);
        }
    }
}
