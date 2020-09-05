using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeanSceneDipAssT2.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.ApplicationServices;
using BeanSceneDipAssT2.Models;
using BeanSceneDipAssT2.Domain;

namespace BeanSceneDipAssT2.Areas.Identity.Pages.Account.Manage
{
    public class ReservationsHistoryModel : PageModel
    {
        //enable Iservces(CRUD) & database(DATA) access
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<PersonalDataModel> _logger;
        private readonly BeanSceneDBContext _context;
        private readonly iServices _services;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReservationsHistoryModel(BeanSceneDBContext beanSceneDBContext,
            iServices services,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager, ILogger<PersonalDataModel> logger
            )
        {
            _context = beanSceneDBContext;
            _services = services;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _userManager = userManager;
        }
        //This is the Reservation History View Model
        public List<ReservationModel> MyReservations { get; set; }

        public class ReservationModel
        {
            //Sitting
            public int SittingID { get; set; }
            public string SittingName { get; set; }

            //reservation
            public int ReservationID { get; set; }
            public int NumberOfGuests { get; set; }
            public DateTime Date { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string AdditionalRequirements { get; set; }
            public string Status { get; set; }

            //Tables
            public int TableID { get; set; }
            public string Area { get; set; }
            public int NumberOfTables { get; set; }

            //customer
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public IEnumerable<Reservation> Reservations { get; set; }
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            Customer c = _services.GetCustomerByEmail(user.Email);
            MyReservations = _context.Reservations.Select(r => new ReservationModel()
            {
                //Sitting
                SittingID = r.SittingID,
                SittingName = r.Sitting.SittingName,

                //Reservation
                ReservationID = r.ReservationID,
                NumberOfGuests = r.NumberOfGuests,
                AdditionalRequirements = r.AdditionalRequirements,
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Status = r.Status,

                //Customer
                CustomerId = r.Customer.CustomerID,
                FirstName = r.Customer.FirstName,
                LastName = r.Customer.LastName,

                //tables
                NumberOfTables = r.Table_Reservation.Count,
            }).Where(r => r.CustomerId == c.CustomerID).OrderByDescending(r => r.Date).ToList();

            foreach (var i in MyReservations)
            {
                i.Area = _services.GetAreaByID(i.ReservationID);
            }
            return Page();
        }
    }
}