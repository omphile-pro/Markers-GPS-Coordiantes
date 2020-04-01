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
    public class MarkersGpscoordinatesController : Controller
    {

        dbsMarkersContext _context = new dbsMarkersContext();
        IHttpContextAccessor _sessionAccessor;
        int roleID = 0;

        public MarkersGpscoordinatesController(IHttpContextAccessor sessionAccessor)
        {
            _sessionAccessor = sessionAccessor;
        }

        // GET: MarkersGpscoordinates
        public async Task<IActionResult> Index()
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

            var dbsMarkersContext = _context.MarkersGpscoordinates.Include(m => m.Center).Include(m => m.SubjectNavigation).Include(m => m.Users);
            return View(await dbsMarkersContext.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Index(string markerssearch)

        {
            ViewData["GetMarkersDetails"] = markerssearch;

            var markerquery = from x in _context.MarkersGpscoordinates select x;
            if (!String.IsNullOrEmpty(markerssearch))
            {
                markerquery = markerquery.Where(x => x.FullName.Contains(markerssearch) || x.CentreNumber.Contains(markerssearch));
            }
            return View(await markerquery.AsNoTracking().ToListAsync());
        }


        // GET: MarkersGpscoordinates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK


            if (id == null)
            {
                return NotFound();
            }

            var markersGpscoordinates = await _context.MarkersGpscoordinates
                .Include(m => m.Center)
                .Include(m => m.SubjectNavigation)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.MarkersId == id);
            if (markersGpscoordinates == null)
            {
                return NotFound();
            }

            return View(markersGpscoordinates);
        }

        // GET: MarkersGpscoordinates/Create
        public IActionResult Create()
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK


            ViewData["CenterId"] = new SelectList(_context.Center.OrderBy(j => j.CenterName), "CenterId", "CenterName");
            ViewData["SubjectId"] = new SelectList(_context.Subject.OrderBy(i => i.SubjectName), "SubjectId", "SubjectName");
            ViewData["UsersId"] = new SelectList(_context.Users.OrderBy(g => g.Firstname), "UsersId", "Loginname");
            return View();
        }

        // POST: MarkersGpscoordinates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,CenterId,UsersId,CentreNumber,CentreName,FullName,Gender,Race,IdNumber,Subject,Paper,Position,PhysicalAddress,PostalCode,PersalNumber,WorkTelephone,HomeTelephone,Cellphone,Latitude,Longitude,CreatedDate,CreatedByUsersId")] MarkersGpscoordinates markersGpscoordinates)
        {
            //  CHECK PERMISSIONS  -- ADD THIS TO ALL PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK


            if (ModelState.IsValid)
            {
                //markersGpscoordinates.MarkersId = null;
                _context.Add(markersGpscoordinates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", markersGpscoordinates.CenterId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", markersGpscoordinates.SubjectId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", markersGpscoordinates.UsersId);
            return View(markersGpscoordinates);
        }

        // GET: MarkersGpscoordinates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

            if (id == null)
            {
                return NotFound();
            }

            var markersGpscoordinates = await _context.MarkersGpscoordinates.FindAsync(id);
            if (markersGpscoordinates == null)
            {
                return NotFound();
            }
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", markersGpscoordinates.CenterId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", markersGpscoordinates.SubjectId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", markersGpscoordinates.UsersId);
            return View(markersGpscoordinates);
        }

        // POST: MarkersGpscoordinates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkersId,SubjectId,CenterId,UsersId,CentreNumber,CentreName,FullName,Gender,Race,IdNumber,Subject,Paper,Position,PhysicalAddress,PostalCode,PersalNumber,WorkTelephone,HomeTelephone,Cellphone,Latitude,Longitude,CreatedDate,CreatedByUsersId")] MarkersGpscoordinates markersGpscoordinates)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

            if (id != markersGpscoordinates.MarkersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markersGpscoordinates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkersGpscoordinatesExists(markersGpscoordinates.MarkersId))
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
            ViewData["CenterId"] = new SelectList(_context.Center, "CenterId", "CenterName", markersGpscoordinates.CenterId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SubjectName", markersGpscoordinates.SubjectId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", markersGpscoordinates.UsersId);
            return View(markersGpscoordinates);
        }

        // GET: MarkersGpscoordinates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

            if (id == null)
            {
                return NotFound();
            }

            var markersGpscoordinates = await _context.MarkersGpscoordinates
                .Include(m => m.Center)
                .Include(m => m.SubjectNavigation)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.MarkersId == id);
            if (markersGpscoordinates == null)
            {
                return NotFound();
            }

            return View(markersGpscoordinates);
        }

        // POST: MarkersGpscoordinates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //  CHECK PERMISSIONS  -- ADD THIS CODE TO ALL YOUR PROTECTED ACTIONS
            roleID = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("roleID"));
            if (roleID <= 0)
            {
                return Unauthorized("You are not signed in.");          //  write better message
            }
            if (roleID != (int)RoleIDs.Administrator && roleID != (int)RoleIDs.SuperAdmin)
            {
                return Unauthorized("You don't have permission to perform this operation.");  //  write better message
            }
            //  END OF SECURITY CHECK

            var markersGpscoordinates = await _context.MarkersGpscoordinates.FindAsync(id);
            _context.MarkersGpscoordinates.Remove(markersGpscoordinates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkersGpscoordinatesExists(int id)
        {
            return _context.MarkersGpscoordinates.Any(e => e.MarkersId == id);
        }
    }
}
