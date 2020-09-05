using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Domain;

namespace BeanSceneDipAssT2.Models
{
    public class ReservationDeteailsViewModel
    {
        //Sitting
        public List<Sitting> MySittings { get; set; }
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

        //t_R
        public List<Table_Reservation> MyTR { get; set; }

        //Tables
        public List<Table> TableList { get; set; }
        [Required(ErrorMessage = "Please, Choose a table first")]
        public int TableID { get; set; }
        public string TableName { get; set; }
        [Required(ErrorMessage = "Please, Choose an Area first")]
        public string Area { get; set; }
        public int NumberOfTables { get; set; }

        //customer
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "An email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        //error message
        public string Errormessage { get; set; }
    }
}
