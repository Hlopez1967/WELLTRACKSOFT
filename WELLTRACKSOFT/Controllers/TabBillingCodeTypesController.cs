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
    public class TabBillingCodeTypesController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabBillingCodeTypesController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabBillingCodeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabBillingCodeTypes.ToListAsync());
        }

        // GET: TabBillingCodeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodeType = await _context.TabBillingCodeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabBillingCodeType == null)
            {
                return NotFound();
            }

            return View(tabBillingCodeType);
        }

        // GET: TabBillingCodeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabBillingCodeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BctypeCode,BctypeDesc")] TabBillingCodeType tabBillingCodeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabBillingCodeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabBillingCodeType);
        }

        // GET: TabBillingCodeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodeType = await _context.TabBillingCodeTypes.FindAsync(id);
            if (tabBillingCodeType == null)
            {
                return NotFound();
            }
            return View(tabBillingCodeType);
        }

        // POST: TabBillingCodeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BctypeCode,BctypeDesc")] TabBillingCodeType tabBillingCodeType)
        {
            if (id != tabBillingCodeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabBillingCodeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabBillingCodeTypeExists(tabBillingCodeType.Id))
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
            return View(tabBillingCodeType);
        }

        // GET: TabBillingCodeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodeType = await _context.TabBillingCodeTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabBillingCodeType == null)
            {
                return NotFound();
            }

            return View(tabBillingCodeType);
        }

        // POST: TabBillingCodeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabBillingCodeType = await _context.TabBillingCodeTypes.FindAsync(id);
            if (tabBillingCodeType != null)
            {
                _context.TabBillingCodeTypes.Remove(tabBillingCodeType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabBillingCodeTypeExists(int id)
        {
            return _context.TabBillingCodeTypes.Any(e => e.Id == id);
        }
    }
}
