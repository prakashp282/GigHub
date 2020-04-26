using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Gig
    {
       

        public int Id { get; set; }


        //foreign key property
        [Required]
        public string ArtistId { get; set; }
        public ApplicationUser Artist { get; set; }


        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)] //limit length instead of MAX by convention
        public string Venue { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; } //foreign key
    }

    
}