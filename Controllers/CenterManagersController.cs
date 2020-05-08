using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Microsoft.AspNetCore.Http;
using Markers_GPS_Coordiantes.Enumerators;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class CenterMangersController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        private readonly IHttpContextAccessor httpContextAccessor;
        public int CenterID = 0;
        public int UsersID = 0;

        public CenterMangersController(IHttpContextAccessor _httpContextAccessor) 
        {
            httpContextAccessor = _httpContextAccessor;
        }
        public IEnumerable<VMarkersGpscoordinates> results { get; set; }

        public void OnGet()
        {
            results = _context.VMarkersGpscoordinates.ToList();
        }
        public void OnPost(DateTime from, DateTime To)
        {
            results = (from x in _context.VMarkersGpscoordinates where (x.CreatedDate <= @from) && (x.CreatedDate > To) select x).ToList();

        }


        // GET: CenterMangers


        public async Task<IActionResult> Index()
        {
            int RoleID = Convert.ToInt32(httpContextAccessor.HttpContext.Session.GetInt32("roleID"));


            //  filter by role id
            if ((!(RoleID == (int)RoleIDs.CenterManager)) && (!(RoleID == (int)RoleIDs.SuperAdmin)) && (!(RoleID == (int)RoleIDs.Administrator)))
            {
                return null;
            }

            CenterID = Convert.ToInt32(httpContextAccessor.HttpContext.Session.GetInt32("centerID"));
            UsersID = Convert.ToInt32(httpContextAccessor.HttpContext.Session.GetInt32("usersID"));

            //  make sure the center really exists
            var center = await _context.VCenter.Where(b => b.CenterId == CenterID).FirstOrDefaultAsync();

            if (center == null) 
            {
                return NotFound("The center does not exist");
            }

            //  check if the user is registered in the CenterManager-Center join table
            var centerManager = await _context.CenterManger.Where(b => b.UsersId == UsersID && b.CenterId == center.CenterId).FirstOrDefaultAsync();

            if (centerManager == null) 
            {
                return NotFound("You are not configured as center manager, please consult your system administrator.");
            }

            return View(await _context.VMarkersGpscoordinates.Where(b => b.CenterId == center.CenterId).OrderBy(r => r.FullName).ToListAsync());
        }

        // GET: CenterMangers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerManger = await _context.CenterManger
                .Include(c => c.Center)
                .Include(c => c.Users)
                .FirstOrDefaultAsync(m => m.CenterManagerId == id);
            if (centerManger == null)
            {
                return NotFound();
            }

            return View(centerManger);
        }

        // GET: CenterMangers/Create
        public IActionResult Create()
        {
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName");
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname");
            return View();
        }

        // POST: CenterMangers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CenterManagerId,UsersId,CenterId,CreateDate")] CenterManger centerManger)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centerManger);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", centerManger.CenterId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", centerManger.UsersId);
            return View(centerManger);
        }

        // GET: CenterMangers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerManger = await _context.CenterManger.FindAsync(id);
            if (centerManger == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", centerManger.CenterId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", centerManger.UsersId);
            return View(centerManger);
        }

        // POST: CenterMangers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CenterManagerId,UsersId,CenterId,CreateDate")] CenterManger centerManger)
        {
            if (id != centerManger.CenterManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centerManger);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterMangerExists(centerManger.CenterManagerId))
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
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", centerManger.CenterId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", centerManger.UsersId);
            return View(centerManger);
        }

        // GET: CenterMangers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerManger = await _context.CenterManger
                .Include(c => c.Center)
                .Include(c => c.Users)
                .FirstOrDefaultAsync(m => m.CenterManagerId == id);
            if (centerManger == null)
            {
                return NotFound();
            }

            return View(centerManger);
        }

        // POST: CenterMangers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centerManger = await _context.CenterManger.FindAsync(id);
            _context.CenterManger.Remove(centerManger);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterMangerExists(int id)
        {
            return _context.CenterManger.Any(e => e.CenterManagerId == id);
        }
    }
}
