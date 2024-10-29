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
    public class ProductTblsController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductTblsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: ProductTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductTbls.ToListAsync());
        }

        // GET: ProductTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTbl = await _context.ProductTbls
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productTbl == null)
            {
                return NotFound();
            }

            return View(productTbl);
        }

        // GET: ProductTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductPice,ProductDate")] ProductTbl productTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productTbl);
        }

        // GET: ProductTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTbl = await _context.ProductTbls.FindAsync(id);
            if (productTbl == null)
            {
                return NotFound();
            }
            return View(productTbl);
        }

        // POST: ProductTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductPice,ProductDate")] ProductTbl productTbl)
        {
            if (id != productTbl.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductTblExists(productTbl.ProductId))
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
            return View(productTbl);
        }

        // GET: ProductTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productTbl = await _context.ProductTbls
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (productTbl == null)
            {
                return NotFound();
            }

            return View(productTbl);
        }

        // POST: ProductTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productTbl = await _context.ProductTbls.FindAsync(id);
            if (productTbl != null)
            {
                _context.ProductTbls.Remove(productTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductTblExists(int id)
        {
            return _context.ProductTbls.Any(e => e.ProductId == id);
        }
    }
}
