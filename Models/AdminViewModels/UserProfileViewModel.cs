using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.Models.AdminViewModels
{
    public class UserProfileViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> CurrentRoles { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
