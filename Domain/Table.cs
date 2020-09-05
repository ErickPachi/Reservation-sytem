using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace BeanSceneDipAssT2.Domain
{
    public class Table
    {
        [Key]
        public int TableID { get; set; }//1, 2, 3 ...
        public string TableName { get; set; } //M1, B1, O1 ...
        public string Area { get; set; } //M, B, O 
        //reservation
        public List<Table_Reservation> Table_Reservation { get; set; }
    }
}