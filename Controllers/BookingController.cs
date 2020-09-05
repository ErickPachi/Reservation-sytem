using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BeanSceneDipAssT2.ApplicationServices;
using BeanSceneDipAssT2.Areas.Identity.Data;
using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.Domain;
using BeanSceneDipAssT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BeanSceneDipAssT2.Controllers
{
    [Authorize(Roles = "Staff,Manager")]
    public class BookingController : Controller
    {
        //enable Iservces(CRUD) & database(DATA) access
        private readonly BeanSceneDBContext _context;
        private readonly iServices _services;
        public BookingController(BeanSceneDBContext beanSceneDBContext,
            iServices services
            )
        {
            _context = beanSceneDBContext;
            _services = services;
        }

        // List of ALL reservations (Staff Page)    ========    BookingController -> [HttpGet] -> Index
        [HttpGet]
        public IActionResult Index()
        {
            //put all the reservation from the database in a model list
            List<BookingDetailModel> ALLreservations = _context.Reservations.Select(r => new BookingDetailModel()
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
                Source = r.Source,

                //Customer
                CustomerId = r.Customer.CustomerID,
                FirstName = r.Customer.FirstName,

                //tables
                NumberOfTables = r.Table_Reservation.Count
            //order it based on its date
            }).OrderByDescending(r => r.Date).ToList(); 

            //set the area for each reservation
            foreach (var reservation in ALLreservations)
            {
                //get the area name based on the reservation ID
                reservation.Area = _services.GetAreaByID(reservation.ReservationID); 
            }
            //send the list model with data to the View
            return View(ALLreservations); 
        }

        // Reservation Details (Details Page)   ========    BookingController -> [HttpGet] -> Detail / Overload (adding error message) 
        [HttpGet]
        public IActionResult Detail(int id, string errormessage)
        {
            //get the reservation data from the database
            Reservation r = _services.GetReservationById(id);
            //get the Customer Data from the database
            Customer c = _services.GetCustomerById(r.CustomerID);
            //get the Sitting Data from the database
            Sitting s = _services.GetSittingById(r.SittingID);
            //get the Tables List of this reservation from the database
            List<Table_Reservation> tds = _services.GetTRList_byReservationID(r.ReservationID);
            //get the Area Name from the database
            string MyArea = _services.GetAreaByID(id);                                               

            ReservationDeteailsViewModel model = new ReservationDeteailsViewModel()
            {
                //Sitting
                SittingID = s.SittingID,
                SittingName = s.SittingName,

                //Reservation
                ReservationID = r.ReservationID,
                NumberOfGuests = r.NumberOfGuests,
                AdditionalRequirements = r.AdditionalRequirements,
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Status = r.Status,
                Source = r.Source,

                //Customer
                CustomerId = c.CustomerID,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,

                //tables
                NumberOfTables = tds.Count,
                MyTR = tds,
                Area = MyArea
            };
            //setting new error message
            model.Errormessage = errormessage; 
            return View(model);
        }

        //Update Rservation data in the Database    ========    BookingController -> [HttpPost] -> Detail (UPDATE RESERVATION)
        [HttpPost]
        public IActionResult Detail(ReservationDeteailsViewModel m)
        {
            if (ModelState.IsValid)
            {
                // getting the New sitting ID based on its name
                Sitting s = _services.GetSittingByName(m.SittingName);
                // setting it to the model
                m.SittingID = s.SittingID;
                // using the model data to update the DB
                _services.UpdateReservation(m);
                // return to the Staf Page (Reservations list)
                return RedirectToAction("Index");                               
            }
            // stay in the details page if modelState is not valid
            return View(m.ReservationID);                                       


        }

        //set new table_reservation in the database     ========    BookingController -> [HttpPost] -> Detail (ADD NEW TABLE)
        [HttpPost]
        public IActionResult AddNewTable(ReservationDeteailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //getting list of tables that are booked in the same period that the current reservation
                    List<Table_Reservation> Unavailabe_Tables = _services.GetListTable(model.Date, model.StartTime);                                       
                    foreach (var table in Unavailabe_Tables)
                    {
                        //check if the choosen table is not in the list of Unavailabe_Tables
                        if (table.TableID == model.TableID)                                                                                                
                        {
                            model.Errormessage = "Sorry this table is already booked during that period";
                            //(if it is) return detailspage with an error message
                            return RedirectToAction("Detail", new { id = model.ReservationID, errormessage = model.Errormessage });                           
                        }
                    }
                    model.Errormessage = "The table was added";
                    //(if NOT) set new table to the resrvation
                    _services.AddTable(model.ReservationID, model.TableID);                                                                                  
                }
                catch
                {
                    model.Errormessage = "You havent choosen any table";
                    //if an error happens return, no tables were selected
                    return RedirectToAction("Detail", new { id = model.ReservationID, errormessage = model.Errormessage });                                  
                }
            }
            //if modelstate is not valid return detail page
            return RedirectToAction("Detail", new { id = model.ReservationID });                                                                             
        }

        //Delete a table_reservation in the database    ========    BookingController -> [HttpPost] -> Detail (REMOVE TABLE)
        [HttpPost]
        public IActionResult RemoveTable(ReservationDeteailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                //check if a table were choose and if the reservation has any table
                if (model.TableID != 0 && model.NumberOfTables > 0)                                                                                               
                {
                    try
                    {
                        _services.RemoveTable(model.ReservationID, model.TableID);
                        _services.UpdateReservation(model);
                        model.Errormessage = "The table was Removed";

                    }
                    catch (Exception)
                    {                
                        model.Errormessage = "You cannot delete a table that has not been assigned"; 
                        return RedirectToAction("Detail", new { id = model.ReservationID, errormessage = model.Errormessage });
                    }

                }
                //(if NOT) return details page with an error message
                model.Errormessage = "There have been no tables selected.";                                                                                  
                return RedirectToAction("Detail", new { id = model.ReservationID, errormessage = model.Errormessage });
            }
            return RedirectToAction("Detail", new { id = model.ReservationID });                                 
        }
    }
}


/* testing binary search algorithm... (In here for a future release... )
public IActionResult SearchByID(int USerID)
{
    var Arr = _context.Reservations.Select(r => r.ReservationID).OrderBy(id => id).ToArray();
    var r_id = _services.BinarySearchDisplay(Arr, USerID);
    if (r_id.ToString() == "None") { return RedirectToAction("Index"); }
    return RedirectToAction("Detail", new { id = r_id });
}*/
