using BeanSceneDipAssT2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Models
{
    public class ReportViewModel
    {
        public int Clients { get; set; }
        public int Reservations { get; set; }
        //source
        public int Website { get; set; }
        public int Mobile { get; set; }
        public int InPErson { get; set; }
        //sitting
        public int Breakfast { get; set; }
        public int Lunch { get; set; }
        public int Dinner { get; set; }
        //Area
        public int MainRoom { get; set; }
        public int Balcony { get; set; }
        public int OutSide { get; set; }

        //for sittings
        public int SittingID { get; set; }
        public List<Sitting> AllSittings { get; set; }
    }
}
