using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Models;
using BeanSceneDipAssT2.Domain;


namespace BeanSceneDipAssT2.Models
{
    public class ReservationCreateModel
    {
        //Sitting
        public List<Sitting> AllSittings { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int SittingID { get; set; }
        
        //reservation
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

        //customer
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "An email address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
