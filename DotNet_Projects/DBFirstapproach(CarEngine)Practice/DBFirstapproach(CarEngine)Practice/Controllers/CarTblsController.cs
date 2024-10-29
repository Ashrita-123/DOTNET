using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBFirstapproach_CarEngine_Practice.Models;

namespace DBFirstapproach_CarEngine_Practice.Controllers
{
    public class CarTblsController : Controller
    {
        private readonly CarDbContext _context;

        public CarTblsController(CarDbContext context)
        {
            _context = context;
        }

        // GET: CarTbls
        public async Task<IActionResult> Index()
        {
            var carDbContext = _context.CarTbls.Include(c => c.Engine);
            return View(await carDbContext.ToListAsync());
        }

        // GET: CarTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carTbl = await _context.CarTbls
                .Include(c => c.Engine)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (carTbl == null)
            {
                return NotFound();
            }

            return View(carTbl);
        }

        // GET: CarTbls/Create
        public IActionResult Create()
        {
            ViewData["EngineId"] = new SelectList(_context.EngineTbls, "EngineId", "EngineId");
            return View();
        }

        // POST: CarTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarId,CarName,EngineId")] CarTbl carTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EngineId"] = new SelectList(_context.EngineTbls, "EngineId", "EngineId", carTbl.EngineId);
            return View(carTbl);
        }

        // GET: CarTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carTbl = await _context.CarTbls.FindAsync(id);
            if (carTbl == null)
            {
                return NotFound();
            }
            ViewData["EngineId"] = new SelectList(_context.EngineTbls, "EngineId", "EngineId", carTbl.EngineId);
            return View(carTbl);
        }

        // POST: CarTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarId,CarName,EngineId")] CarTbl carTbl)
        {
            if (id != carTbl.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarTblExists(carTbl.CarId))
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
            ViewData["EngineId"] = new SelectList(_context.EngineTbls, "EngineId", "EngineId", carTbl.EngineId);
            return View(carTbl);
        }

        // GET: CarTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carTbl = await _context.CarTbls
                .Include(c => c.Engine)
                .FirstOrDefaultAsync(m => m.CarId == id);
            if (carTbl == null)
            {
                return NotFound();
            }

            return View(carTbl);
        }

        // POST: CarTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carTbl = await _context.CarTbls.FindAsync(id);
            if (carTbl != null)
            {
                _context.CarTbls.Remove(carTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarTblExists(int id)
        {
            return _context.CarTbls.Any(e => e.CarId == id);
        }
    }
}
