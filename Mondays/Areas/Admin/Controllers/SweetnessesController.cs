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
    public class SweetnessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SweetnessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Sweetnesses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sweetness.ToListAsync());
        }

        // GET: Admin/Sweetnesses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweetness = await _context.Sweetness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sweetness == null)
            {
                return NotFound();
            }

            return View(sweetness);
        }

        // GET: Admin/Sweetnesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sweetnesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SweetnessName,Weight")] Sweetness sweetness)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sweetness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sweetness);
        }

        // GET: Admin/Sweetnesses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweetness = await _context.Sweetness.FindAsync(id);
            if (sweetness == null)
            {
                return NotFound();
            }
            return View(sweetness);
        }

        // POST: Admin/Sweetnesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SweetnessName,Weight")] Sweetness sweetness)
        {
            if (id != sweetness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sweetness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SweetnessExists(sweetness.Id))
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
            return View(sweetness);
        }

        // GET: Admin/Sweetnesses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sweetness = await _context.Sweetness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sweetness == null)
            {
                return NotFound();
            }

            return View(sweetness);
        }

        // POST: Admin/Sweetnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sweetness = await _context.Sweetness.FindAsync(id);
            _context.Sweetness.Remove(sweetness);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SweetnessExists(int id)
        {
            return _context.Sweetness.Any(e => e.Id == id);
        }
    }
}
