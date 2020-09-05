using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Areas.Identity.Data;
using BeanSceneDipAssT2.Models.AdminViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BeanSceneDipAssT2.DataAccess;
using Microsoft.AspNetCore.Authorization;
using BeanSceneDipAssT2.ApplicationServices;


namespace BeanSceneDipAssT2.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AdminController : Controller
    {
        //enable Iservces(CRUD) & database(DATA) access (+ Deafault Identity Services)
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly BeanSceneDBContext _context;
        private readonly iServices _services;

        public AdminController(BeanSceneDBContext beanSceneDBContext,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            iServices services)
        {
            _services = services;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = beanSceneDBContext;
        }

        // List of ALL Roles (Manage Roles Page)    ========    AdminController -> [HttpGet] -> Index
        [HttpGet]
        public IActionResult RolesIndex()
        {
            //get all the roles from the DB & set the data to a model
            var result = _roleManager.Roles.Select(r => new RolesIndexViewModel()                      
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();
            //send the model with the data to the RoleIndex View (Manage Roles Page)
            return View(result);                                                                       
        }

        // Create role page    ========    AdminController -> [HttpGet] -> RolesCreate
        [HttpGet]
        public IActionResult RolesCreate()
        {
            return View();
        }

        // Create a new role    ========    AdminController -> [HttpPost] -> RolesCreate (CREATE ROLE)
        [HttpPost]
        public async Task<IActionResult> RolesCreate(RolesCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //set the data to a model
                var role = new IdentityRole() { Name = model.RollName };
                //create a new role using the model data
                var result = await _roleManager.CreateAsync(role);                                     
                if (result.Succeeded)
                {
                    //if the the role creation works, retruen rolesindex page
                    return RedirectToAction("RolesIndex");                                             
                }
                foreach (var error in result.Errors)
                {
                    //if not, return error
                    ModelState.AddModelError(String.Empty, error.Description);                         
                }
            }
            //return view
            return View(model);                                                                        
        }

        // get the Assign role page     ========    AdminController -> [HttpGet] -> RolesAssign
        [HttpGet]
        public IActionResult RolesAssign(string Rolename)
        {

            if (Rolename != null)
            {
                //if the a role as chosen, set the data to a model.
                AssignRoleViewModel ar = new AssignRoleViewModel()                                      
                {
                    RollName = Rolename,                                                
                };
                //send the model with the data. So the RoleName input will be auto filled
                return View(ar);                                                                        
            }
            else
            {
                //if not just send a empty model
                AssignRoleViewModel model = new AssignRoleViewModel();                                  
                return View(model);
            }
        }

        // Assign role to a user    ========    AdminController -> [HttpPost] -> RolesAssign (ASSIGN ROLE)
        [HttpPost]
        public async Task<IActionResult> RolesAssign(AssignRoleViewModel AR)
        {
            try
            {
                //get user by ID
                var user = await _userManager.FindByIdAsync(AR.UserID);
                //Assign a role to this user
                var result = await _userManager.AddToRoleAsync(user, AR.RollName);                       
                if (result.Succeeded)
                {
                    //if Succeeded, go to Staff list (Role Detail)
                    return RedirectToAction("RolesDetails");                                             
                }
                return BadRequest();
            }
            catch (Exception)
            {
                //if not return bad request
                return BadRequest();                                                                        
            }
        }

        // Unassign role to a user  ========    AdminController -> [HttpPost] -> UnAssignRole (UNASSIGN ROLE)
        [HttpPost]
        public async Task<IActionResult> UnAssignRole(AssignRoleViewModel AR)
        {
            //get user by ID
            var user = await _userManager.FindByIdAsync(AR.UserID);
            //Assign a role to this user
            var result = await _userManager.RemoveFromRoleAsync(user, AR.RollName);                     
            if (result.Succeeded)
            {
                //if Succeeded, go to Staff list (Role Detail)
                return RedirectToAction("RolesDetails");                                            
            }
            //if not return bad request
            return BadRequest();                                                                        
        }

        // Delete a role    ========    AdminController -> [HttpPost] -> DeleteRole (Delete ROLE)
        [HttpPost]
        public IActionResult DeleteRole(string id)
        {
            try
            {
                //delete Role by ID
                _services.DeleteRole(id);
                //go to Roleindex page
                return RedirectToAction("RolesIndex");                                                  
            }
            catch (Exception)
            {
                //if not return bad request
                return BadRequest();                                                                    
            }
        }

        // Get list of all "Employees" (Manahers, staffs)   ========    AdminController -> [HttpGet] -> RolesDetails
        [HttpGet]
        public IActionResult RolesDetails()
        {
            //get ALL registerd Users
            var users = _context.Users.ToList();
            //get ALL Normalizations (Users that have a role)
            var user_roles = _context.UserRoles.ToList();
            //get ALL Roles in the DB
            var roles = _context.Roles.ToList();

            //Join
            //create a list of All Employees, using a JOIN to connect  ALL the Lists above
            var List_of_Employees = from u in users                                                     
                        join ur in user_roles on u.Id equals ur.UserId into table1
                        from ur in table1.ToList()
                        join r in roles on ur.RoleId equals r.Id into table2
                        from r in table2.ToList()
                        //set the data in a model
                        select new RolesDetailsViewModel                                                 
                        {
                            UserID = u.Id,
                            FisrtName = u.FirstName,
                            LastName = u.LastName,
                            Email = u.Email,
                            RollID = r.Id,
                            RollName = r.Name
                        };
            //send the model with the data to the RoleIndex View (Manage Roles Page)
            return View(List_of_Employees);                                                              
        }
    }
}
