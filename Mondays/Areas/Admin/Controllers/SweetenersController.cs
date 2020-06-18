using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mondays.DataAccess.Data;
using Mondays.Models;

namespace Mondays.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SweetenersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SweetenersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Sweeteners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sweeteners.ToListAsync());
        }

        // GET: Admin/Sweeteners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweeteners = await _context.Sweeteners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sweeteners == null)
            {
                return NotFound();
            }

            return View(sweeteners);
        }

        // GET: Admin/Sweeteners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sweeteners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SweetenerName")] Sweeteners sweeteners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweeteners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweeteners);
        }

        // GET: Admin/Sweeteners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweeteners = await _context.Sweeteners.FindAsync(id);
            if (sweeteners == null)
            {
                return NotFound();
            }
            return View(sweeteners);
        }

        // POST: Admin/Sweeteners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SweetenerName")] Sweeteners sweeteners)
        {
            if (id != sweeteners.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweeteners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetenersExists(sweeteners.Id))
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
            return View(sweeteners);
        }

        // GET: Admin/Sweeteners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweeteners = await _context.Sweeteners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sweeteners == null)
            {
                return NotFound();
            }

            return View(sweeteners);
        }

        // POST: Admin/Sweeteners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sweeteners = await _context.Sweeteners.FindAsync(id);
            _context.Sweeteners.Remove(sweeteners);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetenersExists(int id)
        {
            return _context.Sweeteners.Any(e => e.Id == id);
        }
    }
}
