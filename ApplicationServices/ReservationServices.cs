using BeanSceneDipAssT2.Areas.Identity.Data;
using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.Domain;
using BeanSceneDipAssT2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.ApplicationServices
{
    public class ReservationServices : iServices
    {
        private readonly BeanSceneDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ReservationServices(BeanSceneDBContext context,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor

            )
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }

        public IQueryable<Sitting> Sitting
        {
            get
            {
                return _context.Sittings.AsQueryable();
            }
        }

        //----------------------------------------------------------------------------- CREATE Section:

        public void AddReservationOnly(ReservationCreateModel command)                  // creates a new Reservation
        {
            Reservation Reservation = new Reservation()
            {
                NumberOfGuests = command.NumberOfGuests,
                AdditionalRequirements = command.AdditionalRequirements,
                Date = command.Date,
                StartTime = command.StartTime,
                EndTime = command.EndTime,
                Status = command.Status,
                Source = command.Source,
                //Customer
                CustomerID = command.CustomerID,
                //sitting
                SittingID = command.SittingID
            };
            _context.Reservations.Add(Reservation);
            _context.SaveChanges();
        }

        public void AddCustomerReservation(ReservationCreateModel command)          // creates a new Reservation and a new Customer
        {
            Customer Customer = new Customer()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                PhoneNumber = command.PhoneNumber,
                Email = command.Email
            };
            Reservation Reservation = new Reservation()
            {
                NumberOfGuests = command.NumberOfGuests,
                AdditionalRequirements = command.AdditionalRequirements,
                Date = command.Date,
                StartTime = command.StartTime,
                EndTime = command.EndTime,
                Status = command.Status,
                Source = command.Source,
                //Customer
                CustomerID = Customer.CustomerID,
                Customer = Customer,
                //sitting
                SittingID = command.SittingID
            };
            _context.Reservations.Add(Reservation);
            _context.SaveChanges();
        }

        public void AddTable(int ReservationID, int TableID)                            //set a Table to Reservation
        {
            Table_Reservation table_Reservation = new Table_Reservation()
            {
                TableID = TableID,
                ReservationID = ReservationID,
            };
            _context.Table_Reservations.Add(table_Reservation);
            _context.SaveChanges();
        }
        //----------------------------------------------------------------------------- REMOVE Section:

        public void DeleteReservationById(int id)                                       //delete a reservation
        {
            Reservation r = GetReservationById(id);
            _context.Reservations.Remove(r);
            _context.SaveChanges();
        }
        public void DeleteCustomerById(int id)                                          //delete a Customer
        {
            Customer c = GetCustomerById(id);
            _context.Customers.Remove(c);
            _context.SaveChanges();
        }
        public void RemoveTable(int ReservationID, int TableID)                         //Remove Table (TR)
        {
            Table_Reservation table_Reservation = GetTable_ReservationById(ReservationID, TableID);
            _context.Table_Reservations.Remove(table_Reservation);
            _context.SaveChanges();
        }
        public void UnAssignUser(string UserID, string RollID)                          //Unassign User
        {
            var ur = _context.UserRoles.Select(r => r).Where(r => r.UserId == UserID && r.RoleId == RollID).FirstOrDefault();
            var result = _context.UserRoles.Remove(ur);
            _context.SaveChanges();
        }
        public void DeleteRole(string RollID)                                           //Delete role
        {
            var ur = _context.Roles.Select(r => r).Where(r => r.Id == RollID).FirstOrDefault();
            var result = _context.Roles.Remove(ur);
            _context.SaveChanges();
        }
        //----------------------------------------------------------------------------- UPDATE Section:

        public void UpdateReservation(ReservationDeteailsViewModel command)              // Update reservations Details
        {
            Reservation r = GetReservationById(command.ReservationID); 

            //reservation
            r.NumberOfGuests = command.NumberOfGuests;
            r.AdditionalRequirements = command.AdditionalRequirements;
            r.Status = command.Status;
            r.Source = command.Source;
            r.Date = command.Date;
            r.StartTime = command.StartTime;
            r.EndTime = command.EndTime;
            r.CustomerID = command.CustomerId;
            r.SittingID = command.SittingID;

            //update Database
            _context.SaveChanges();
        }
        public void UpdateSittingsDuration(EditSittingViewModel command)              //Update Sittings start and end time
        {
            Sitting s = GetSittingById(command.SittingID);

            s.Sitting_StartTime = command.Sitting_StartTime;
            s.Sitting_EndTime = command.Sitting_EndTime;

            //update Database
            _context.SaveChanges();
        }

        //---------------------------------------------------------------------------- GET section: 

        //-----------------------------------------------------------GET by ID

        public Sitting GetSittingById(int id)                                           //Get a Sitting 
        {
            return _context.Sittings.FirstOrDefault(s => s.SittingID == id);
        }
        public Reservation GetReservationById(int id)                                   //Get a Reservation
        {
            return _context.Reservations.FirstOrDefault(r => r.ReservationID == id);
        }
        public Customer GetCustomerById(int id)                                         //Get a Customer
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerID == id);
        }
        public string GetAreaByID(int ReservationID)                                    // Get the area of a reservation (using 
        {
            try
            {
                Table_Reservation td = GetTable_ReservationById(ReservationID);
                Table t = GetTableByID(td.TableID);
                return t.Area;
            }
            catch { return ""; }
        }
        public Table_Reservation GetTable_ReservationById(int ReservationID)             //get table_reservation from a resevation (using ReservationId)
        {
            return _context.Table_Reservations.FirstOrDefault(td => td.ReservationID == ReservationID);
        }
        public Table_Reservation GetTable_ReservationById(int ReservationID, int TableID) //get an especific table_reservation (using ReservationId & TableID)
        {
            return _context.Table_Reservations.FirstOrDefault(td => td.ReservationID == ReservationID && td.TableID == TableID);
        }
        public Table GetTableByID(int TableID)                                           //get table
        {
            return _context.Tables.FirstOrDefault(t => t.TableID == TableID);
        }

        //----------------------------------------------------------GET by NAME
        public Sitting GetSittingByName(string SittingName)                             // get Sitting by its name
        {
            return _context.Sittings.FirstOrDefault(s => s.SittingName == SittingName);
        }

        //----------------------------------------------------------GET by Email 
        public Customer GetCustomerByEmail(string Email)                                //Customer by Email
        {
            return _context.Customers.FirstOrDefault(c => c.Email == Email);
        }

        //----------------------------------------------------------GET LISTS
        public List<Reservation> GetListReservationByEmail(string Email)                //get all the reservations of one customer (based om his Email)
        {
            return _context.Reservations.Select(r => r).Where(r => r.Customer.Email == Email).ToList();
        }
        public List<Reservation> GetReservationListByCustomerId(int Customerid)         //get all the reservations of one customer (based om his ID)
        {
            return _context.Reservations.Select(r => r).Where(r => r.Customer.CustomerID == Customerid).ToList();
        }
        public List<Table_Reservation> GetTRList_byReservationID(int id)                //get a list of all tables in a specific reservation
        {
            return _context.Table_Reservations.Select(r => r).Where(r => r.ReservationID == id && r.TableID == r.Table.TableID).OrderBy(r => r.TableID).ToList();
        }
        public List<Table_Reservation> GetListTable(DateTime date, DateTime startTime)  //get a list of tables that are unavailable
        {
            return _context.Table_Reservations.Select(r => r).Where(r => r.Reservation.Date == date && r.Reservation.StartTime <= startTime && startTime <= r.Reservation.EndTime).ToList();
        }

        public List<Reservation> GetAllReservation()                                    //Get ALL Siitings
        {
            return _context.Reservations.ToList();
        }
        public List<Sitting> GetListSitting()                                           //Get ALL Siitings
        {
            return _context.Sittings.ToList();
        }
        public List<Customer> GetAllRCustomers()                                        //Get ALL Customes
        {
            return _context.Customers.ToList();
        }

        /* testing binary search algorithm... (In here for a future release... )
        public object BinarySearchDisplay(int[] arr, int key)
        {
            int minNum = 0;
            int maxNum = arr.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (key == arr[mid])
                {
                    return ++mid;
                }
                else if (key < arr[mid])
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return "None";
        }*/
    }
}
