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
    public class TabPayersCatalogsController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabPayersCatalogsController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabPayersCatalogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabPayersCatalogs.ToListAsync());
        }

        // GET: TabPayersCatalogs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPayersCatalog = await _context.TabPayersCatalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabPayersCatalog == null)
            {
                return NotFound();
            }

            return View(tabPayersCatalog);
        }

        // GET: TabPayersCatalogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabPayersCatalogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PayerId,PayerName,PayerType,DateCreated")] TabPayersCatalog tabPayersCatalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabPayersCatalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabPayersCatalog);
        }

        // GET: TabPayersCatalogs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPayersCatalog = await _context.TabPayersCatalogs.FindAsync(id);
            if (tabPayersCatalog == null)
            {
                return NotFound();
            }
            return View(tabPayersCatalog);
        }

        // POST: TabPayersCatalogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PayerId,PayerName,PayerType,DateCreated")] TabPayersCatalog tabPayersCatalog)
        {
            if (id != tabPayersCatalog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabPayersCatalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabPayersCatalogExists(tabPayersCatalog.Id))
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
            return View(tabPayersCatalog);
        }

        // GET: TabPayersCatalogs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPayersCatalog = await _context.TabPayersCatalogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabPayersCatalog == null)
            {
                return NotFound();
            }

            return View(tabPayersCatalog);
        }

        // POST: TabPayersCatalogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tabPayersCatalog = await _context.TabPayersCatalogs.FindAsync(id);
            if (tabPayersCatalog != null)
            {
                _context.TabPayersCatalogs.Remove(tabPayersCatalog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabPayersCatalogExists(long id)
        {
            return _context.TabPayersCatalogs.Any(e => e.Id == id);
        }
    }
}
