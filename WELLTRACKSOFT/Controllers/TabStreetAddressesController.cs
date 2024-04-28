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
    public class TabStreetAddressesController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabStreetAddressesController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabStreetAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabStreetAddresses.ToListAsync());
        }

        // GET: TabStreetAddresses/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabStreetAddress = await _context.TabStreetAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabStreetAddress == null)
            {
                return NotFound();
            }

            return View(tabStreetAddress);
        }

        // GET: TabStreetAddresses/Create
        public IActionResult Create()
        {

            var placeslist = _context.TabPlacesOfServices.ToList();

            ViewData["placesid"] = new SelectList(placeslist,"Id","PlaceOfServiceDesc");

            return View();
        }

        // POST: TabStreetAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address1,Address2,City,State,ZipCode,Phone")] TabStreetAddress tabStreetAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabStreetAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabStreetAddress);
        }

        // GET: TabStreetAddresses/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabStreetAddress = await _context.TabStreetAddresses.FindAsync(id);
            if (tabStreetAddress == null)
            {
                return NotFound();
            }
            return View(tabStreetAddress);
        }

        // POST: TabStreetAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Address1,Address2,City,State,ZipCode,Phone")] TabStreetAddress tabStreetAddress)
        {
            if (id != tabStreetAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabStreetAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabStreetAddressExists(tabStreetAddress.Id))
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
            return View(tabStreetAddress);
        }

        // GET: TabStreetAddresses/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabStreetAddress = await _context.TabStreetAddresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabStreetAddress == null)
            {
                return NotFound();
            }

            return View(tabStreetAddress);
        }

        // POST: TabStreetAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tabStreetAddress = await _context.TabStreetAddresses.FindAsync(id);
            if (tabStreetAddress != null)
            {
                _context.TabStreetAddresses.Remove(tabStreetAddress);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabStreetAddressExists(long id)
        {
            return _context.TabStreetAddresses.Any(e => e.Id == id);
        }
    }
}
