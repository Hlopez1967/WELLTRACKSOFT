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
    public class TabBillingCodesModifiersController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabBillingCodesModifiersController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabBillingCodesModifiers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabBillingCodesModifiers.ToListAsync());
        }

        // GET: TabBillingCodesModifiers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodesModifier = await _context.TabBillingCodesModifiers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabBillingCodesModifier == null)
            {
                return NotFound();
            }

            return View(tabBillingCodesModifier);
        }

        // GET: TabBillingCodesModifiers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabBillingCodesModifiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BcmodifierCode,BcmodifierDesc,CreatedDate,CreatedBy")] TabBillingCodesModifier tabBillingCodesModifier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabBillingCodesModifier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabBillingCodesModifier);
        }

        // GET: TabBillingCodesModifiers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodesModifier = await _context.TabBillingCodesModifiers.FindAsync(id);
            if (tabBillingCodesModifier == null)
            {
                return NotFound();
            }
            return View(tabBillingCodesModifier);
        }

        // POST: TabBillingCodesModifiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,BcmodifierCode,BcmodifierDesc,CreatedDate,CreatedBy")] TabBillingCodesModifier tabBillingCodesModifier)
        {
            if (id != tabBillingCodesModifier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabBillingCodesModifier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabBillingCodesModifierExists(tabBillingCodesModifier.Id))
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
            return View(tabBillingCodesModifier);
        }

        // GET: TabBillingCodesModifiers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodesModifier = await _context.TabBillingCodesModifiers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabBillingCodesModifier == null)
            {
                return NotFound();
            }

            return View(tabBillingCodesModifier);
        }

        // POST: TabBillingCodesModifiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tabBillingCodesModifier = await _context.TabBillingCodesModifiers.FindAsync(id);
            if (tabBillingCodesModifier != null)
            {
                _context.TabBillingCodesModifiers.Remove(tabBillingCodesModifier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabBillingCodesModifierExists(long id)
        {
            return _context.TabBillingCodesModifiers.Any(e => e.Id == id);
        }
    }
}
