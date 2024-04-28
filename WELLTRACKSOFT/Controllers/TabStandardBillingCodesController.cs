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
    public class TabStandardBillingCodesController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabStandardBillingCodesController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabStandardBillingCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabStandardBillingCodes.ToListAsync());
        }

        // GET: TabStandardBillingCodes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabStandardBillingCode = await _context.TabStandardBillingCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabStandardBillingCode == null)
            {
                return NotFound();
            }

            return View(tabStandardBillingCode);
        }

        // GET: TabStandardBillingCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabStandardBillingCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StdBillingCode,StdBillingCodeDesc")] TabStandardBillingCode tabStandardBillingCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabStandardBillingCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabStandardBillingCode);
        }

        // GET: TabStandardBillingCodes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabStandardBillingCode = await _context.TabStandardBillingCodes.FindAsync(id);
            if (tabStandardBillingCode == null)
            {
                return NotFound();
            }
            return View(tabStandardBillingCode);
        }

        // POST: TabStandardBillingCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,StdBillingCode,StdBillingCodeDesc")] TabStandardBillingCode tabStandardBillingCode)
        {
            if (id != tabStandardBillingCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabStandardBillingCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabStandardBillingCodeExists(tabStandardBillingCode.Id))
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
            return View(tabStandardBillingCode);
        }

        // GET: TabStandardBillingCodes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabStandardBillingCode = await _context.TabStandardBillingCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabStandardBillingCode == null)
            {
                return NotFound();
            }

            return View(tabStandardBillingCode);
        }

        // POST: TabStandardBillingCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tabStandardBillingCode = await _context.TabStandardBillingCodes.FindAsync(id);
            if (tabStandardBillingCode != null)
            {
                _context.TabStandardBillingCodes.Remove(tabStandardBillingCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabStandardBillingCodeExists(long id)
        {
            return _context.TabStandardBillingCodes.Any(e => e.Id == id);
        }
    }
}
