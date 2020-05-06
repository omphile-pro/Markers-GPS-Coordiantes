using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Markers_GPS_Coordiantes.Data;
using Markers_GPS_Coordiantes.Enumerators;
using Microsoft.AspNetCore.Http;

namespace Markers_GPS_Coordiantes.Controllers
{
    public class CentersController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        private readonly IHttpContextAccessor _sessionAccessor;
        int roleID = 0;
        public CentersController(IHttpContextAccessor sessionAccessor)
        {
            _sessionAccessor = sessionAccessor;
        }
        // GET: Centers
        public async Task<IActionResult> Index()
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            var dbsMarkersContext = _context.Center.Include(c => c.City);
            return View(await dbsMarkersContext.ToListAsync());
        }

        // GET: Centers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.CenterId == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // GET: Centers/Create
        public IActionResult Create()
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityDescription");
            return View();
        }

        // POST: Centers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CenterId,CenterToken,CenterName,CenterNumber,CenterDescription,CityId,Longitude,Latitude,DeletedDate,DeletedByUsersId,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Center center)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            if (ModelState.IsValid)
            {
                _context.Add(center);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityDescription", center.CityId);
            return View(center);
        }

        // GET: Centers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {//  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityDescription", center.CityId);
            return View(center);
        }

        // POST: Centers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CenterId,CenterToken,CenterName,CenterNumber,CenterDescription,CityId,Longitude,Latitude,DeletedDate,DeletedByUsersId,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Center center)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            if (id != center.CenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(center);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterExists(center.CenterId))
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
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "CityDescription", center.CityId);
            return View(center);
        }

        // GET: Centers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetInt32("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center
                .Include(c => c.City)
                .FirstOrDefaultAsync(m => m.CenterId == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // POST: Centers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var center = await _context.Center.FindAsync(id);
            _context.Center.Remove(center);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CenterExists(int id)
        {
            return _context.Center.Any(e => e.CenterId == id);
        }
    }
}
