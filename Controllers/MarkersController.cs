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
    public class MarkersController : Controller
    {
        dbsMarkersContext _context = new dbsMarkersContext();
        private readonly IHttpContextAccessor _sessionAccessor;

        public MarkersController(IHttpContextAccessor sessionAccessor) 
        {
            _sessionAccessor = sessionAccessor;     //  DEPENDENCY INJECTION
        }

        // GET: Markers
        public async Task<IActionResult> Index()
        {
            var dbsMarkersContext = _context.VMarker.OrderBy(g => g.Displayname);
            return View(await dbsMarkersContext.ToListAsync());
        }


        // GET: Markers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Marker
                .Include(m => m.Position)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // GET: Markers/Create
        public IActionResult Create()
        {
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription");
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription");
            ViewData["RaceId"] = new SelectList(_context.Race, "RaceId", "RaceDescription");


            return View();
        }

        // POST: Markers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VMarker marker)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //  CREATE A USER FIRST
                    var newUser = new Users()
                    {
                        Firstname = marker.Firstname,
                        Lastname = marker.Lastname,
                        EmailAddress = marker.EmailAddress,
                        MobileNo = marker.MobileNo,
                        PhysicalAddress = marker.PhysicalAddress,
                        PostalAddress = marker.PostalAddress,
                        Displayname = marker.Firstname + " " + marker.Lastname,
                        GenderId = Convert.ToInt32(marker.GenderId),      //  make sure this value required
                             //  same here
                        Loginname = marker.EmailAddress,
                        Password = "Password1",  //  you need to create a password generator
                        
                        LastModifiedByUsersId = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("usersID")),
                        CreatedByUsersId = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("usersID")),
                        Telephone = (marker.Telephone != null ? marker.Telephone : marker.MobileNo),     //  if telephone is null, use mobile number, which you should make required                
                    };

                    //  SAVE CHANGES
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    //  now create marker record
                    var newMarker = new Marker()
                    {
                        UsersId = newUser.UsersId,
                        PositionId = marker.PositionId,
                        LastModifiedByUsersId = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("usersID")),
                        CreatedByUsersId = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("usersID")),
                    };

                    //  add marker to database and save changes
                    _context.Marker.Add(newMarker);
                    await _context.SaveChangesAsync();

                    //  add role
                    var newRole = new UsersRole()
                    {
                        UsersId = newUser.UsersId,
                        RoleId = (int)RoleIDs.CenterManager,
                        CreatedByUsersId = Convert.ToInt32(_sessionAccessor.HttpContext.Session.GetString("usersID"))
                    };

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) 
                {
                    return Content(ex.ToString());
                }
            }
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription", marker.PositionId);
            ViewData["GenderId"] = new SelectList(_context.Gender, "GenderId", "GenderDescription", marker.GenderId);
            ViewData["RaceId"] = new SelectList(_context.Race, "RaceId", "RaceDescription", marker.RaceId);
            return View(marker);
        }

        // GET: Markers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //Wait 1 min
            var marker = await _context.Marker.FindAsync(id);
            if (marker == null)
            {
                return NotFound();
            }
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription", marker.PositionId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", marker.UsersId);
            return View(marker);
        }

        // POST: Markers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkerId,MarkerToken,UsersId,PositionId,DeletedDate,DeletedByUsersId,LastModifiedByUsersId,LastModifiedDate,CreatedByUsersId,CreateDate,IsDeleted")] Marker marker)
        {
            if (id != marker.MarkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkerExists(marker.MarkerId))
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
            ViewData["PositionId"] = new SelectList(_context.Position, "PositionId", "PositionDescription", marker.PositionId);
            ViewData["UsersId"] = new SelectList(_context.Users, "UsersId", "Loginname", marker.UsersId);
            return View(marker);
        }

        // GET: Markers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marker = await _context.Marker
                .Include(m => m.Position)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (marker == null)
            {
                return NotFound();
            }

            return View(marker);
        }

        // POST: Markers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marker = await _context.Marker.FindAsync(id);
            _context.Marker.Remove(marker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkerExists(int id)
        {
            return _context.Marker.Any(e => e.MarkerId == id);
        }
    }
}
