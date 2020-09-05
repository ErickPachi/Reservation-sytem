using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Domain
{
    public class Sitting
    {
        [Key]
        public int SittingID { get; set; }
        public string SittingName { get; set; }
        public DateTime Sitting_StartTime { get; set; }
        public DateTime Sitting_EndTime { get; set; }
        //reservation
        public List<Reservation> Reservation { get; set; }
    }
}