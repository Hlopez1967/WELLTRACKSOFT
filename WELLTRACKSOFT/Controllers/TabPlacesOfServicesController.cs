using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WELLTRACKSOFT.Models;

namespace WELLTRACKSOFT.Controllers
{
    public class TabPlacesOfServicesController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabPlacesOfServicesController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabPlacesOfServices
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabPlacesOfServices.ToListAsync());
        }

        // GET: TabPlacesOfServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPlacesOfService = await _context.TabPlacesOfServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabPlacesOfService == null)
            {
                return NotFound();
            }

            return View(tabPlacesOfService);
        }

        // GET: TabPlacesOfServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabPlacesOfServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PlaceOfServiceCode,PlaceOfServiceDesc")] TabPlacesOfService tabPlacesOfService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabPlacesOfService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabPlacesOfService);
        }

        // GET: TabPlacesOfServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPlacesOfService = await _context.TabPlacesOfServices.FindAsync(id);
            if (tabPlacesOfService == null)
            {
                return NotFound();
            }
            return View(tabPlacesOfService);
        }

        // POST: TabPlacesOfServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PlaceOfServiceCode,PlaceOfServiceDesc")] TabPlacesOfService tabPlacesOfService)
        {
            if (id != tabPlacesOfService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabPlacesOfService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabPlacesOfServiceExists(tabPlacesOfService.Id))
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
            return View(tabPlacesOfService);
        }

        // GET: TabPlacesOfServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPlacesOfService = await _context.TabPlacesOfServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabPlacesOfService == null)
            {
                return NotFound();
            }

            return View(tabPlacesOfService);
        }

        // POST: TabPlacesOfServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabPlacesOfService = await _context.TabPlacesOfServices.FindAsync(id);
            if (tabPlacesOfService != null)
            {
                _context.TabPlacesOfServices.Remove(tabPlacesOfService);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabPlacesOfServiceExists(int id)
        {
            return _context.TabPlacesOfServices.Any(e => e.Id == id);
        }
    }
}
