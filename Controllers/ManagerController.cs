using BeanSceneDipAssT2.ApplicationServices;
using BeanSceneDipAssT2.Areas.Identity.Data;
using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.Domain;
using BeanSceneDipAssT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BeanSceneDipAssT2.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        //enable iServices(CRUD) & database(data) access (+ default Identity services)
        private readonly BeanSceneDBContext _context;
        private readonly iServices _services;
        public ManagerController(BeanSceneDBContext beanSceneDBContext,
            iServices services
            )
        {
            _context = beanSceneDBContext;
            _services = services;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Sittings = _services.GetListSitting();
            EditSittingViewModel model = new EditSittingViewModel()
            {
                AllSittings = Sittings,
                SittingID = Sittings[0].SittingID
            };
            return View(model);
        }

        public IActionResult MReservations()
        {
            var Customers = _context.Customers.ToList();
            var Reservations = _context.Reservations.ToList();
            var Table_Reservationsoles = _context.Table_Reservations.ToList();
            var tables = _context.Tables.ToList();
            var Sittings = _context.Sittings.ToList();
            //Getting all the reservations from the database in a model list.
            List<BookingDetailModel> items = _context.Reservations.Select(r => new BookingDetailModel()
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
                Status = r.Status, //Pending, confirmed, seated, completed, cancelled
                Source = r.Source, //Website, phone, in person, email etc...

                //Customer
                CustomerId = r.Customer.CustomerID,
                FirstName = r.Customer.FirstName,

                //tables
                NumberOfTables = r.Table_Reservation.Count,
                //ordering the list by Date in descending order.
            }).OrderByDescending(r => r.Date).ToList();

            //Setting the area for the reservations.
            foreach (var i in items)
            {
                //Getting the area name based on the ReservationID
                i.Area = _services.GetAreaByID(i.ReservationID);
            }
            //Sending the populated model to the view
            return View(items);
        }
        //just Remove one...
        public IActionResult DeleteReservation(int id)
        {
            //Check if the MReservation ModelState is valid
            if (ModelState.IsValid)
            {
                //Passing the id to the DeleteReservationById method
                _services.DeleteReservationById(id);
            }
            //Return the MReservations View.
            return RedirectToAction("MReservations");
        }

        //edit the start and ending time of periods
        [HttpGet]
        public IActionResult EditSitting(int id)
        {
            try
            {
                Sitting s = _services.GetSittingById(id);
                EditSittingViewModel Smodel = new EditSittingViewModel()
                {
                    SittingID = s.SittingID,
                    SittingName = s.SittingName,
                    Sitting_EndTime = s.Sitting_EndTime,
                    Sitting_StartTime = s.Sitting_StartTime
                };
                return View(Smodel);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        //update the sitting using the UpdateSittingDuration method
        [HttpPost]
        public IActionResult EditSitting(EditSittingViewModel s)
        {
            _services.UpdateSittingsDuration(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Report()
        {
            try
            {
                List<Sitting> s = _services.GetListSitting();
                List<Reservation> Rs = _services.GetAllReservation();
                ReportViewModel model = new ReportViewModel();
                int cs = 0;
                foreach (Reservation r in Rs)
                {
                    Table_Reservation td = _services.GetTable_ReservationById(r.ReservationID);
                    if(td != null)
                    {
                        Table t = _services.GetTableByID(td.TableID);
                        //area
                        if (t.Area == "Main Room")
                        {
                            model.MainRoom++;
                        }
                        if (t.Area == "Balcony")
                        {
                            model.Balcony++;
                        }
                        if (t.Area == "Outside")
                        {
                            model.OutSide++;
                        }
                    }
                    cs = cs + r.NumberOfGuests;
                    //source
                    if (r.Source == "WebSite")
                    { model.Website++; }
                    if (r.Source == "Mobile")
                    { model.Mobile++; }
                    if (r.Source == "Walk in")
                    { model.InPErson++; }
                    //sitting
                    if (r.SittingID == s[0].SittingID)
                    { model.Breakfast++; }
                    if (r.SittingID == s[1].SittingID)
                    { model.Lunch++; }
                    if (r.SittingID == s[2].SittingID)
                    { model.Dinner++; }
                }
                model.Reservations = Rs.Count();
                model.Clients = cs;
                return View(model);
            }
            catch { return RedirectToAction("Error", "Home"); }
        }
    }
}
