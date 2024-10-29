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
    public class CustomerTblsController : Controller
    {
        private readonly ProductDbContext _context;

        public CustomerTblsController(ProductDbContext context)
        {
            _context = context;
        }

        // GET: CustomerTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerTbls.ToListAsync());
        }

        // GET: CustomerTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTbl = await _context.CustomerTbls
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerTbl == null)
            {
                return NotFound();
            }

            return View(customerTbl);
        }

        // GET: CustomerTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerContact,Address")] CustomerTbl customerTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerTbl);
        }

        // GET: CustomerTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTbl = await _context.CustomerTbls.FindAsync(id);
            if (customerTbl == null)
            {
                return NotFound();
            }
            return View(customerTbl);
        }

        // POST: CustomerTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,CustomerContact,Address")] CustomerTbl customerTbl)
        {
            if (id != customerTbl.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerTblExists(customerTbl.CustomerId))
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
            return View(customerTbl);
        }

        // GET: CustomerTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerTbl = await _context.CustomerTbls
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerTbl == null)
            {
                return NotFound();
            }

            return View(customerTbl);
        }

        // POST: CustomerTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerTbl = await _context.CustomerTbls.FindAsync(id);
            if (customerTbl != null)
            {
                _context.CustomerTbls.Remove(customerTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerTblExists(int id)
        {
            return _context.CustomerTbls.Any(e => e.CustomerId == id);
        }
    }
}
