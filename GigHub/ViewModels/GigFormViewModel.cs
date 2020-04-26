using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    // class used to only for presentation
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        //using the following two attributes we can separate 
        //date and time in the view
        [Required]
        [FutureDate] //data annotation class defined in viewmodels.futurdate
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        //in the dropdown we need the numeric value of the genre
        [Required]
        public byte Genre { get; set; }
        //using IEnumerable IF for general simple query for view 
        //to get a list of options of genres in view
        //new SelectList(Model.Genres, "Id", "Name")
        public IEnumerable<Genre> Genres { get; set; }

        //separation of concerns, code extracted from controller as controller doesn't have to 
        //know about parsing - model becomes information expert
        public DateTime GetDateTime()
        {
            
                return DateTime.Parse(string.Format("{0} {1}", Date, Time));
            }
    }
}