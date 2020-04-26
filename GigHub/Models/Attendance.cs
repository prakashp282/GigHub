using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GigHub.Models
{
    //intermediary class between user and gigs in the many to many relation
    public class Attendance
    {
        //navigation properties
        public Gig Gig { get; set; }
        public ApplicationUser Attendee  { get; set; }

        //foreign keys for optimization to not load new gig objects 
        [Key]//composite primary key to represent attendance
        [Column(Order = 1)]
        public int GigId { get; set; }

        [Key]//composite primary key to represent attendance
        [Column(Order = 2)]
        public string AttendeeId { get; set; } //id is string applicationUser
    }

}