using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Domain;

namespace BeanSceneDipAssT2.Models
{
    public class EditSittingViewModel
    {
        //Sitting
        [Required(ErrorMessage = "This field is required")]
        public int SittingID { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string SittingName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime Sitting_StartTime { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime Sitting_EndTime { get; set; }
        public List<Sitting> AllSittings { get; set; }
    }
}