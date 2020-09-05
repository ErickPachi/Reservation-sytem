
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Domain
{
    public class Reservation
    {
        //resevation
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }
        public int NumberOfGuests { get; set; }
        public string AdditionalRequirements { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string Source { get; set; }

        //customer
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        //Tables
        public List<Table_Reservation> Table_Reservation { get; set; }
        //Sitting
        [ForeignKey("Sitting")]
        public int SittingID { get; set; }
        public Sitting Sitting { get; set; }
    }
}

