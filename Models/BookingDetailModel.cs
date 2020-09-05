using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Domain;

namespace BeanSceneDipAssT2.Models
{
    public class BookingDetailModel
    {
        //Sitting
        [Required(ErrorMessage = "This field is required")]
        public int SittingID { get; set; }
        public string SittingName { get; set; }

        //reservation
        public int ReservationID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int NumberOfGuests { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }
        public string AdditionalRequirements { get; set; }

        //Tables
        public string Area { get; set; }
        public int NumberOfTables { get; set; }
         
        //customer
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        //reservations list
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
