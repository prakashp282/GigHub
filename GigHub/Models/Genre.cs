using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Genre
    {
        //we will have less 255 genres
        public byte Id { get; set; }


        //overriding conventions
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}