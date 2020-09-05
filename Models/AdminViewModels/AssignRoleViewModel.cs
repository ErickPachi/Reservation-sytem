using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Models.AdminViewModels
{
    public class AssignRoleViewModel
    {
        [Display(Name = "Role Name")]
        [Required]
        public string RollName { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "This field is required")]
        public string UserID { get; set; }
    }
}
