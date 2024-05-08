using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WELLTRACKSOFT.Models;

namespace WELLTRACKSOFT.Controllers
{
    public class TabBillingCodesTypesRelationsController : Controller
    {
        private readonly WellTrackDbContext _context;

        private readonly UserManager<IdentityUser> _UserManager;

        public string UsuarioTemp = "hlopez";

        public TabBillingCodesTypesRelationsController(WellTrackDbContext context, UserManager<IdentityUser> UserManager)
        {
            _context = context;
            _UserManager = UserManager;
        }

        // GET: TabBillingCodesTypesRelations
        public async Task<IActionResult> Index()
        {

            var query = await (from tbc in _context.TabBillingCodesTypesRelations
                               join btc in _context.TabBillingCodeTypes on tbc.TabBillingCodeTypeId equals btc.Id
                               join posr in _context.TabBillingCodesTypesPlacesOfServicesRelations on tbc.Id equals posr.TabBillingCodesTypesRelationId into posrGroup
                               from posr in posrGroup.DefaultIfEmpty()
                               join pos in _context.TabPlacesOfServices on posr.TabPlacesOfServiceId equals pos.Id into posGroup
                               from pos in posGroup.DefaultIfEmpty()
                               group new { pos, tbc, btc } by new { btc.BctypeCode, tbc.BillingCode, tbc.BillingCodeDesc, tbc.Id } into g
                               select new csBillCodesRelations
                               {
                                   Id = 0,
                                   Type = g.Key.BctypeCode,
                                   Code = g.Key.BillingCode,
                                   PlacesOfService = string.Join(", ", g.Select(x => x.pos == null ? "All" : $"{x.pos.PlaceOfServiceDesc} ({x.pos.PlaceOfServiceCode})")),
                                   Description = g.Key.BillingCodeDesc,
                                   tabBillingCodesTypesRelationId = Convert.ToInt32(g.Key.Id)
                               }).ToListAsync();

            int contador = 0;

            foreach (var item in query)
            {
                item.Id = contador++;

            }

            return View(query);
        }

        // GET: TabBillingCodesTypesRelations/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodesTypesRelation = await _context.TabBillingCodesTypesRelations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabBillingCodesTypesRelation == null)
            {
                return NotFound();
            }

            return View(tabBillingCodesTypesRelation);
        }

        // GET: TabBillingCodesTypesRelations/Create
        public IActionResult Create()
        {

            var listcodes = _context.TabBillingCodeTypes.ToList();

            var liststandard = _context.TabStandardBillingCodes.ToList();

            var listmodifier = _context.TabBillingCodesModifiers.ToList();

            var listplaces = _context.TabPlacesOfServices.ToList();

            ViewData["codesid"] = new SelectList(listcodes, "Id", "BctypeCode");

            ViewData["standardid"] = new SelectList(liststandard, "Id", "StdBillingCode");

            ViewData["modifierid"] = new SelectList(listmodifier, "Id", "BcmodifierCode");

            ViewData["placesid"] = new SelectList(listplaces, "Id", "PlaceOfServiceDesc");

            return View();
        }

        // POST: TabBillingCodesTypesRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TabBillingCodesTypesRelation tabBillingCodesTypesRelation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabBillingCodesTypesRelation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabBillingCodesTypesRelation);
        }


        [HttpPost]

        public async Task<IActionResult> createbillcoderel(string codetype, string billincode,
            string billindesc, string places, string modifiers)
        {
            string errormessage = "OK";
            try
            {

                if (ModelState.IsValid)
                {
                    var Usuario = UsuarioTemp;  //_UserManager.GetUserId(HttpContext.User);

                    _context.Database.BeginTransaction();

                    string[] modifierslist = modifiers.Split(" ");

                    foreach (var mod in modifierslist)
                    {

                        var infomod = await _context.TabBillingCodesModifiers
                                        .FirstOrDefaultAsync(x => x.BcmodifierDesc == mod);

                        if (infomod == null)
                        {
                            TabBillingCodesModifier objmod = new TabBillingCodesModifier();

                            objmod.BcmodifierCode = mod;
                            objmod.BcmodifierDesc = "Description-" + mod.ToString().Trim();
                            objmod.CreatedDate = DateTime.Now;
                            objmod.CreatedBy = Usuario.ToString().Trim();

                            _context.Add(objmod);
                            await _context.SaveChangesAsync();
                        }
                    }


                    TabBillingCodesTypesRelation objdet = new TabBillingCodesTypesRelation();


                    objdet.TabBillingCodeTypeId = Convert.ToInt32(codetype);
                    objdet.BillingCode = billincode.Trim() + "-" + modifiers.ToString().Replace(" ","-");
                    objdet.BillingCodeDesc = billindesc.Trim();
                    objdet.CreatedDate = DateTime.Now;
                    objdet.CreatedBy = Usuario.ToString().Trim();


                    _context.Add(objdet);
                    await _context.SaveChangesAsync();

                    if (places != "All")
                    {
                        string[] placeslist = places.Split(" ");

                        foreach (var pla in placeslist)
                        {

                            var infoplace = await _context.TabPlacesOfServices
                                .FirstOrDefaultAsync(x => x.PlaceOfServiceDesc == pla);

                            if (infoplace != null)
                            {

                                TabBillingCodesTypesPlacesOfServicesRelation objrel = new TabBillingCodesTypesPlacesOfServicesRelation();

                                objrel.TabBillingCodesTypesRelationId = objdet.Id;
                                objrel.TabPlacesOfServiceId = infoplace.Id;


                                _context.Add(objrel);
                                await _context.SaveChangesAsync();

                            }
                        }

                    }

                    _context.Database.CommitTransaction();


                }

                return new ObjectResult(new { status = errormessage });
               
            } 
            catch(Exception ex)
            {
                return new ObjectResult(new { status = ex.Message.Trim() });
            }
        }



        [HttpPost]

        public async Task<IActionResult> findBillCodeDescription(int id)
        {
            string errormessage = "OK";
            try
            {
                string description = "";
                var descinfo = await _context.TabStandardBillingCodes.FirstOrDefaultAsync(x => x.Id == id);

                if (descinfo != null)
                {
                    description = descinfo.StdBillingCodeDesc;
                }
                return new ObjectResult(new { status = errormessage, desc = description });
            }
            catch (Exception ex)
            {

                return new ObjectResult(new { status = ex.Message });
            }

        }

        // GET: TabBillingCodesTypesRelations/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodesTypesRelation = await _context.TabBillingCodesTypesRelations.FindAsync(id);
            if (tabBillingCodesTypesRelation == null)
            {
                return NotFound();
            }
            return View(tabBillingCodesTypesRelation);
        }

        // POST: TabBillingCodesTypesRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TabBillingCodeTypeId,BillingCode,BillingCodeDesc,CreatedDate,CreatedBy")] TabBillingCodesTypesRelation tabBillingCodesTypesRelation)
        {
            if (id != tabBillingCodesTypesRelation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabBillingCodesTypesRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabBillingCodesTypesRelationExists(tabBillingCodesTypesRelation.Id))
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
            return View(tabBillingCodesTypesRelation);
        }

        // GET: TabBillingCodesTypesRelations/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabBillingCodesTypesRelation = await _context.TabBillingCodesTypesRelations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tabBillingCodesTypesRelation == null)
            {
                return NotFound();
            }

            return View(tabBillingCodesTypesRelation);
        }

        // POST: TabBillingCodesTypesRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tabBillingCodesTypesRelation = await _context.TabBillingCodesTypesRelations.FindAsync(id);
            if (tabBillingCodesTypesRelation != null)
            {
                _context.TabBillingCodesTypesRelations.Remove(tabBillingCodesTypesRelation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabBillingCodesTypesRelationExists(long id)
        {
            return _context.TabBillingCodesTypesRelations.Any(e => e.Id == id);
        }
    }
}
