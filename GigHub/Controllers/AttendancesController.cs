using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceGto gto)
        {
            
            var userId = User.Identity.GetUserId();
            //check for duplicates
            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gto.GigId))
            {
                return BadRequest("Attendance already exists.");
            }
            var attendance = new Attendance
            {
                GigId = gto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
