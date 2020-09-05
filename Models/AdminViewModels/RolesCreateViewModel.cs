using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Models.AdminViewModels
{
    public class RolesCreateViewModel
    {
        [Display(Name = "Role Name")]
        [Required]
        public string RollName { get; set; }
    }
}
