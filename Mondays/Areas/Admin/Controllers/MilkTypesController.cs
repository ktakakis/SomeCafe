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
    public class MilkTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MilkTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/MilkTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MilkTypes.ToListAsync());
        }

        // GET: Admin/MilkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milkType = await _context.MilkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milkType == null)
            {
                return NotFound();
            }

            return View(milkType);
        }

        // GET: Admin/MilkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MilkTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MilkTypeName")] MilkType milkType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(milkType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(milkType);
        }

        // GET: Admin/MilkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milkType = await _context.MilkTypes.FindAsync(id);
            if (milkType == null)
            {
                return NotFound();
            }
            return View(milkType);
        }

        // POST: Admin/MilkTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MilkTypeName")] MilkType milkType)
        {
            if (id != milkType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(milkType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MilkTypeExists(milkType.Id))
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
            return View(milkType);
        }

        // GET: Admin/MilkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var milkType = await _context.MilkTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (milkType == null)
            {
                return NotFound();
            }

            return View(milkType);
        }

        // POST: Admin/MilkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var milkType = await _context.MilkTypes.FindAsync(id);
            _context.MilkTypes.Remove(milkType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MilkTypeExists(int id)
        {
            return _context.MilkTypes.Any(e => e.Id == id);
        }
    }
}
