using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using BeanSceneDipAssT2.ApplicationServices;
using BeanSceneDipAssT2.Areas.Identity.Data;
using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.Models;
using BeanSceneDipAssT2.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BeanSceneDipAssT2.Controllers
{

    public class ReservationController : Controller
    {
        //Enable iServices (CRUD operations) & database access
        private readonly IHttpContextAccessor _httpContextAccessor; //checking user is logged on
        private readonly BeanSceneDBContext _context; //access the db
        private readonly iServices _reservationServices; //access the crud functions
        private readonly UserManager<AppUser> _userManager; //access the identity users
        public ReservationController(BeanSceneDBContext beanSceneDBContext,
            iServices reservationServices,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = beanSceneDBContext;
            _reservationServices = reservationServices;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Reservation()
        {
            //Getting a list of sittings from the db
            List<Sitting> s = _reservationServices.GetListSitting();
            //checking UserID
            var UserID = _userManager.GetUserId(HttpContext.User);
            //If the UserID is not null, in other words if the user is logged in.
            if (UserID != null)
            {
                //We assign the User based on their Id to the "user" variable
                var user = _context.Users.Where(r => r.Id == UserID).FirstOrDefault();
                //putting the data in the "m" viewmodel
                ReservationCreateModel m = new ReservationCreateModel
                {
                    //customer details
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    //sittings details
                    AllSittings = s
                };
                //Return the view with the data from the view model.
                return View(m);
            }
            else
            {
                //Otherwise we only return the sittings
                ReservationCreateModel model = new ReservationCreateModel { AllSittings = s };
                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reservation(ReservationCreateModel model)
        {
            if (ModelState.IsValid)
            {
                //setting default values for reservation
                ReservationCreateModel m = model;
                m.Status = "Pending";
                m.Source = "WebSite";
                m.EndTime = model.StartTime.AddHours(1);

                Customer c = _reservationServices.GetCustomerByEmail(model.Email);
                List<Customer> Cs = _reservationServices.GetAllRCustomers();

                if (Cs.Contains(c))
                {
                    model.CustomerID = c.CustomerID;
                    _reservationServices.AddReservationOnly(m);
                    return RedirectToAction("Done");
                }
                else {
                    _reservationServices.AddCustomerReservation(m);
                    return RedirectToAction("Done");
                }

            }
            else
            {
                return View(model);
            }          
        }

        //3.Done//
        [HttpGet]
        public IActionResult Done()
        {
            return View();
        }
    }
}