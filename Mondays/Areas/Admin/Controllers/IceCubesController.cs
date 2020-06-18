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
    public class IceCubesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IceCubesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/IceCubes
        public async Task<IActionResult> Index()
        {
            return View(await _context.IceCubes.ToListAsync());
        }

        // GET: Admin/IceCubes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCube = await _context.IceCubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iceCube == null)
            {
                return NotFound();
            }

            return View(iceCube);
        }

        // GET: Admin/IceCubes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/IceCubes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IceCubeName")] IceCube iceCube)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iceCube);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iceCube);
        }

        // GET: Admin/IceCubes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCube = await _context.IceCubes.FindAsync(id);
            if (iceCube == null)
            {
                return NotFound();
            }
            return View(iceCube);
        }

        // POST: Admin/IceCubes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IceCubeName")] IceCube iceCube)
        {
            if (id != iceCube.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iceCube);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IceCubeExists(iceCube.Id))
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
            return View(iceCube);
        }

        // GET: Admin/IceCubes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iceCube = await _context.IceCubes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iceCube == null)
            {
                return NotFound();
            }

            return View(iceCube);
        }

        // POST: Admin/IceCubes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iceCube = await _context.IceCubes.FindAsync(id);
            _context.IceCubes.Remove(iceCube);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IceCubeExists(int id)
        {
            return _context.IceCubes.Any(e => e.Id == id);
        }
    }
}
