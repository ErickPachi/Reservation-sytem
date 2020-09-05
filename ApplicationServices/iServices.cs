using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.Domain;
using BeanSceneDipAssT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeanSceneDipAssT2.ApplicationServices
{
    public interface iServices
    {
        //-----------------------------------------------------------CREATE
        void AddReservationOnly(ReservationCreateModel command);                     // Creates a new Reservation
        void AddCustomerReservation(ReservationCreateModel command);                 // Creates a new Reservation and a new Customer
        void AddTable(int ReservationID, int TableID);                               // Sets a Table to Reservation

        //-----------------------------------------------------------REMOVE           
        void DeleteReservationById(int id);                                          // Delete a reservation
        void DeleteCustomerById(int id);                                             // Delete a Customer
        void RemoveTable(int ReservationID, int TableID);                            // Removes a Table (T_R)
        void UnAssignUser(string UserID, string RollID);                             // UnAssign User
        void DeleteRole(string RollID);                                              // Delete Role

        //-----------------------------------------------------------UPDATE
        void UpdateReservation(ReservationDeteailsViewModel model);                  // Update reservations Details
        public void UpdateSittingsDuration(EditSittingViewModel command);            // Update Siitings Start and end Time

        //-----------------------------------------------------------GET by ID
        Sitting GetSittingById(int id);                                              // Get a Sitting 
        Reservation GetReservationById(int id);                                      // Get a Reservation
        Customer GetCustomerById(int id);                                            // Get a Customer
        string GetAreaByID(int ReservationID);                                       // Get the area of a reservation (using ReservationId)
        Table_Reservation GetTable_ReservationById(int ReservationID);               // Get one T_R from a resevation (using ReservationId)
        Table_Reservation GetTable_ReservationById(int ReservationID, int TableID);  // Get an especific T_R (using ReservationId & TableID)
        Table GetTableByID(int TableID);                                             // Get a table (based om its ID)

        //----------------------------------------------------------GET by NAME
        Sitting GetSittingByName(string SittingName);                                // Get Sitting by its name

        //----------------------------------------------------------GET by Email 
        Customer GetCustomerByEmail(string Email);                                   // Get Customer by email

        //----------------------------------------------------------GET LISTS
        List<Reservation> GetListReservationByEmail(string Email);                   // Get all the reservations of one customer (based om his Email)
        List<Reservation> GetReservationListByCustomerId(int Customerid);            // Get all the reservations of one customer (based om his ID)
        List<Table_Reservation> GetTRList_byReservationID(int ReservationID);        // Get a list of all tables in a specific reservation
        List<Table_Reservation> GetListTable(DateTime date, DateTime startTime);     // Get a list of tables that are unavailable (during the same period)
        List<Sitting> GetListSitting();                                              // Get ALL Sittings
        List<Reservation> GetAllReservation();                                       // Get ALL reaservations
        List<Customer> GetAllRCustomers();                                           // Get ALL Customers


                                                                    //Search
        //object BinarySearchDisplay(int[] arr, int key);                            //search for a key value in a array (not being used)
    }
}
