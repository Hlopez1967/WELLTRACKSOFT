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
    public class TabCompanyGeneralInfoesController : Controller
    {
        private readonly WellTrackDbContext _context;

        public TabCompanyGeneralInfoesController(WellTrackDbContext context)
        {
            _context = context;
        }

        // GET: TabCompanyGeneralInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TabCompanyGeneralInfos.ToListAsync());
        }

        // GET: TabCompanyGeneralInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabCompanyGeneralInfo = await _context.TabCompanyGeneralInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabCompanyGeneralInfo == null)
            {
                return NotFound();
            }

            return View(tabCompanyGeneralInfo);
        }

        // GET: TabCompanyGeneralInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TabCompanyGeneralInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LegalName,TradeName,Email,PhoneNumber,Fax,Website,Ein,Npi,Mpi,TaxonomyCode,DateCreated,Domain,AboutMe,Logo")] TabCompanyGeneralInfo tabCompanyGeneralInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabCompanyGeneralInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabCompanyGeneralInfo);
        }

        // GET: TabCompanyGeneralInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabCompanyGeneralInfo = await _context.TabCompanyGeneralInfos.FindAsync(id);
            if (tabCompanyGeneralInfo == null)
            {
                return NotFound();
            }
            return View(tabCompanyGeneralInfo);
        }

        // POST: TabCompanyGeneralInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LegalName,TradeName,Email,PhoneNumber,Fax,Website,Ein,Npi,Mpi,TaxonomyCode,DateCreated,Domain,AboutMe,Logo")] TabCompanyGeneralInfo tabCompanyGeneralInfo)
        {
            if (id != tabCompanyGeneralInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabCompanyGeneralInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabCompanyGeneralInfoExists(tabCompanyGeneralInfo.Id))
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
            return View(tabCompanyGeneralInfo);
        }

        // GET: TabCompanyGeneralInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabCompanyGeneralInfo = await _context.TabCompanyGeneralInfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabCompanyGeneralInfo == null)
            {
                return NotFound();
            }

            return View(tabCompanyGeneralInfo);
        }

        // POST: TabCompanyGeneralInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabCompanyGeneralInfo = await _context.TabCompanyGeneralInfos.FindAsync(id);
            if (tabCompanyGeneralInfo != null)
            {
                _context.TabCompanyGeneralInfos.Remove(tabCompanyGeneralInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabCompanyGeneralInfoExists(int id)
        {
            return _context.TabCompanyGeneralInfos.Any(e => e.Id == id);
        }
    }
}
