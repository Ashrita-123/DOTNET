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
    public class EngineTblsController : Controller
    {
        private readonly CarDbContext _context;

        public EngineTblsController(CarDbContext context)
        {
            _context = context;
        }

        // GET: EngineTbls
        public async Task<IActionResult> Index()
        {
            return View(await _context.EngineTbls.ToListAsync());
        }

        // GET: EngineTbls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineTbl = await _context.EngineTbls
                .FirstOrDefaultAsync(m => m.EngineId == id);
            if (engineTbl == null)
            {
                return NotFound();
            }

            return View(engineTbl);
        }

        // GET: EngineTbls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EngineTbls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineId,EngineType")] EngineTbl engineTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineTbl);
        }

        // GET: EngineTbls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineTbl = await _context.EngineTbls.FindAsync(id);
            if (engineTbl == null)
            {
                return NotFound();
            }
            return View(engineTbl);
        }

        // POST: EngineTbls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineId,EngineType")] EngineTbl engineTbl)
        {
            if (id != engineTbl.EngineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineTblExists(engineTbl.EngineId))
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
            return View(engineTbl);
        }

        // GET: EngineTbls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineTbl = await _context.EngineTbls
                .FirstOrDefaultAsync(m => m.EngineId == id);
            if (engineTbl == null)
            {
                return NotFound();
            }

            return View(engineTbl);
        }

        // POST: EngineTbls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engineTbl = await _context.EngineTbls.FindAsync(id);
            if (engineTbl != null)
            {
                _context.EngineTbls.Remove(engineTbl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineTblExists(int id)
        {
            return _context.EngineTbls.Any(e => e.EngineId == id);
        }
    }
}
