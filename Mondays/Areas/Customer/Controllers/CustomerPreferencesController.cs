using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mondays.DataAccess.Data;
using Mondays.DataAccess.Repository.IRepository;
using Mondays.Models;
using Mondays.Utility;

namespace Mondays.Areas.Customer.Controllers
{

    [Area("Customer")]
    public class CustomerPreferencesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;


        public CustomerPreferencesController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _hostEnvironment = hostEnvironment;

        }

        [HttpGet]
        public IActionResult GetAll(string id)
        {
            var customerPreferencesList = _context.CustomerPreferences
                .Include(c => c.ApplicationUser)
                .Include(c => c.MilkTypes)
                .Include(c => c.Product)
                .Include(c => c.Sweetener)
                .Include(c => c.Sweetness)
                .Include(c => c.Topping)
                .Include(c => c.IceCubes)
                .Include(c => c.Origins).ToList();
            if (id != null)
            {
                customerPreferencesList.Where(x => x.ApplicationUser.Id == id).ToList();

                return Json(new { data = customerPreferencesList });
            }

            return Json(new { data = customerPreferencesList });
        }

        // GET: Customer/CustomerPreferences
        public async Task<IActionResult> Index(string id)
        {
            if (id != null)
            {
                var applicationDbContext = _context.CustomerPreferences
                    .Include(c => c.ApplicationUser)
                    .Include(c => c.MilkTypes)
                    .Include(c => c.Product)
                    .Include(c => c.Sweetener)
                    .Include(c => c.Sweetness)
                    .Include(c => c.Topping)
                    .Include(c => c.IceCubes)
                    .Include(c => c.Origins)
                    .Where(x => x.ApplicationUser.Id == id).ToList();

                return View(applicationDbContext);
            }

            var username = HttpContext.User.Identity.Name;
            if (!HttpContext.User.IsInRole(SD.Role_Admin))
            {
                var applicationDbContext = _context.CustomerPreferences.Where(x => x.ApplicationUser.UserName == username)
                                    .Include(c => c.ApplicationUser)
                                    .Include(c => c.MilkTypes)
                                    .Include(c => c.Product)
                                    .Include(c => c.Sweetener)
                                    .Include(c => c.Sweetness)
                                    .Include(c => c.Topping)
                                    .Include(c => c.IceCubes)
                                    .Include(c => c.Origins);

                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.CustomerPreferences
                                    .Include(c => c.ApplicationUser)
                                    .Include(c => c.MilkTypes)
                                    .Include(c => c.Product)
                                    .Include(c => c.Sweetener)
                                    .Include(c => c.Sweetness)
                                    .Include(c => c.Topping)
                                    .Include(c => c.IceCubes)
                                    .Include(c => c.Origins);
                return View(await applicationDbContext.ToListAsync());
            }


        }

        // GET: Customer/CustomerPreferences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPreferences = await _context.CustomerPreferences
                .Include(c => c.ApplicationUser)
                .Include(c => c.MilkTypes)
                .Include(c => c.Product)
                .Include(c => c.Sweetener)
                .Include(c => c.Sweetness)
                .Include(c => c.Topping)
                .Include(c => c.IceCubes)
                .Include(c => c.Origins)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customerPreferences == null)
            {
                return NotFound();
            }

            return View(customerPreferences);
        }

        // GET: Customer/CustomerPreferences/Create
        public IActionResult Create()
        {
            var username = HttpContext.User.Identity.Name;
            var userid = _context.ApplicationUsers.Where(x => x.UserName == username).FirstOrDefault().Id;
            
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "UserName");
            ViewData["MilkTypeId"] = new SelectList(_context.MilkTypes, "Id", "MilkTypeName");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title");
            ViewData["SweetenerId"] = new SelectList(_context.Sweeteners, "Id", "SweetenerName");
            ViewData["SweetnessId"] = new SelectList(_context.Sweetness, "Id", "SweetnessName");
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "Id", "ToppingName");
            ViewData["OriginId"] = new SelectList(_context.Origins, "Id", "OriginName");
            ViewData["IceCubeId"] = new SelectList(_context.IceCubes, "Id", "IceCubeName");
            if (!HttpContext.User.IsInRole(SD.Role_Admin))
            {
                ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers.Where(x => x.UserName == username), "Id", "Name");
                CustomerPreferences customerPreferences = new CustomerPreferences();
                customerPreferences.ApplicationUserId = userid;
                return View(customerPreferences);
            }

            return View();
        }

        // POST: Customer/CustomerPreferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,ProductId,SweetenerId,SweetnessId,ToppingId,MilkTypeId,OriginId,IceCubeId,Notes")] CustomerPreferences customerPreferences)
        {

           if (ModelState.IsValid)
            {
                _context.Add(customerPreferences);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(customerPreferences);
        }

        // GET: Customer/CustomerPreferences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerPreferences = await _context.CustomerPreferences.FindAsync(id);
            if (customerPreferences == null)
            {
                return NotFound();
            }
            var username = HttpContext.User.Identity.Name;
            if (!HttpContext.User.IsInRole(SD.Role_Admin))
            {
                ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers.Where(x => x.UserName == username), "Id", "Name");
            }
            else
            {
                ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            }
            ViewData["MilkTypeId"] = new SelectList(_context.MilkTypes, "Id", "MilkTypeName", customerPreferences.MilkTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", customerPreferences.ProductId);
            ViewData["SweetenerId"] = new SelectList(_context.Sweeteners, "Id", "SweetenerName", customerPreferences.SweetenerId);
            ViewData["SweetnessId"] = new SelectList(_context.Sweetness, "Id", "SweetnessName", customerPreferences.SweetnessId);
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "Id", "ToppingName", customerPreferences.ToppingId);
            ViewData["OriginId"] = new SelectList(_context.Origins, "Id", "OriginName", customerPreferences.OriginId);
            ViewData["IceCubeId"] = new SelectList(_context.IceCubes, "Id", "IceCubeName", customerPreferences.IceCubeId);

            return View(customerPreferences);
        }

        // POST: Customer/CustomerPreferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,ProductId,SweetenerId,SweetnessId,ToppingId,MilkTypeId,OriginId,IceCubeId,Notes")] CustomerPreferences customerPreferences)
        {
            if (id != customerPreferences.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerPreferences);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerPreferencesExists(customerPreferences.Id))
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
            var username = HttpContext.User.Identity.Name;
            if (!HttpContext.User.IsInRole(SD.Role_Admin))
            {
                ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers.Where(x => x.UserName == username), "Id", "Name");
            }
            else
            {
                ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Name");
            }
            ViewData["MilkTypeId"] = new SelectList(_context.MilkTypes, "Id", "MilkTypeName", customerPreferences.MilkTypeId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Title", customerPreferences.ProductId);
            ViewData["SweetenerId"] = new SelectList(_context.Sweeteners, "Id", "SweetenerName", customerPreferences.SweetenerId);
            ViewData["SweetnessId"] = new SelectList(_context.Sweetness, "Id", "SweetnessName", customerPreferences.SweetnessId);
            ViewData["ToppingId"] = new SelectList(_context.Toppings, "Id", "ToppingName", customerPreferences.ToppingId);
            ViewData["OriginId"] = new SelectList(_context.Origins, "Id", "OriginName", customerPreferences.OriginId);
            ViewData["IceCubeId"] = new SelectList(_context.IceCubes, "Id", "IceCubeName", customerPreferences.IceCubeId);

            return View(customerPreferences);
        }
        [HttpDelete]

        private bool CustomerPreferencesExists(int id)
        {
            return _context.CustomerPreferences.Any(e => e.Id == id);
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _context.CustomerPreferences.Where(x=>x.Id==id).FirstOrDefault();
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Σφάλμα κατά τη διαγραφή" });
            }
            _context.CustomerPreferences.Remove(objFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Διαγραφή επιτυχής" });

        }

    }
}
