using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BeanSceneDipAssT2.Areas.Identity.Data;
using BeanSceneDipAssT2.Models.AdminViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BeanSceneDipAssT2.DataAccess;

namespace BeanSceneDipAssT2.Models.AdminViewModels
{
    public class RolesDetailsViewModel
    {
        [Display(Name = "Role Name")]
        [Required]
        public string RollName { get; set; }
        public string RollID { get; set; }
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "This field is required")]
        public string UserID { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<RolesIndexViewModel> ALLroles { get; set; }
    }
}
