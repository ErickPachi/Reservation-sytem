using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Domain
{
    //normalization
    public class Table_Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Table_ReservationID { get; set; }
        [ForeignKey("Table")]
        public int TableID { get; set; }
        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }
        public Table Table { get; set; }
    }
}