using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WELLTRACKSOFT.Models;
using System.IO;

namespace WELLTRACKSOFT.Controllers
{
    public class TabPayersController : Controller
    {
        private readonly WellTrackDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public TabPayersController(WellTrackDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: TabPayers
        public async Task<IActionResult> Index()
        {

            var infopayer = _context.TabPayers.FirstOrDefault();

            string webRootPath = _webHostEnvironment.WebRootPath;
            
            string rutafoto = Path.Combine(webRootPath, "image", "logo1.png");
            
            return View(await _context.TabPayers.ToListAsync());
        }

        // GET: TabPayers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPayer = await _context.TabPayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabPayer == null)
            {
                return NotFound();
            }

            return View(tabPayer);
        }

        // GET: TabPayers/Create
        public IActionResult Create()
        {
            var listhouses = _context.TabPayersClearingHouses.ToList();

            ViewData["houseis"] = new SelectList(listhouses, "tabPayersid", "tabClearingHousesId");


            TabPayer tabPayer = new TabPayer();

            tabPayer.catalog = _context.TabPayersCatalogs.ToList();

            return View(tabPayer);
        }

        // POST: TabPayers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PayerId,PayerName,Email,Phone,Fax,Website,Description,TabStreetAddressId,ExternalId,TradingPartnerId,Logo,DateCreated,CreatedBy")] TabPayer tabPayer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabPayer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabPayer);
        }

        public async Task<IActionResult> payershealth(long? id)
        {


            var listhouses = _context.TabPayersClearingHouses.ToList();

            ViewData["houseis"] = new SelectList(listhouses, "tabPayersid", "tabClearingHousesId");
                                   

            var tabPayer = await _context.TabPayers.FindAsync(id);

            tabPayer.catalog = _context.TabPayersCatalogs.ToList();

            if (tabPayer == null)
            {
                return NotFound();
            }
            return View(tabPayer);
        }

        // GET: TabPayers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var listhouses = _context.TabPayersClearingHouses.ToList();

            ViewData["houseis"] = new SelectList(listhouses, "tabPayersid", "tabClearingHousesId");


           // TabPayer tabPayer = new TabPayer();
           

            var tabPayer = await _context.TabPayers.FindAsync(id);

            tabPayer.catalog = _context.TabPayersCatalogs.ToList();

            if (tabPayer == null)
            {
                return NotFound();
            }
            return View(tabPayer);
        }

        // POST: TabPayers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PayerId,PayerName,Email,Phone,Fax,Website,Description,TabStreetAddressId,ExternalId,TradingPartnerId,Logo,DateCreated,CreatedBy")] TabPayer tabPayer)
        {
            if (id != tabPayer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabPayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabPayerExists(tabPayer.Id))
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
            return View(tabPayer);
        }

        // GET: TabPayers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabPayer = await _context.TabPayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabPayer == null)
            {
                return NotFound();
            }

            return View(tabPayer);
        }

        // POST: TabPayers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tabPayer = await _context.TabPayers.FindAsync(id);
            if (tabPayer != null)
            {
                _context.TabPayers.Remove(tabPayer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabPayerExists(long id)
        {
            return _context.TabPayers.Any(e => e.Id == id);
        }
    }
}
