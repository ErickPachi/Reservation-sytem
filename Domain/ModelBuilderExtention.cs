using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BeanSceneDipAssT2.DataAccess;
using BeanSceneDipAssT2.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BeanSceneDipAssT2.Domain
{
    public static class ModelBuilderExtetion
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Sitting>().HasData(
                    new Sitting
                    {
                        SittingID = 1,
                        SittingName = "Breakfast",
                        Sitting_StartTime = DateTime.Parse("0001/01/01 06:00 am"),
                        Sitting_EndTime = DateTime.Parse("0001/01/01 12:00 pm")
                    },
                    new Sitting
                    {
                        SittingID = 2,
                        SittingName = "Lunch",
                        Sitting_StartTime = DateTime.Parse("0001/01/01 12:00 pm"),
                        Sitting_EndTime = DateTime.Parse("0001/01/01 06:00 pm")
                    },
                    new Sitting
                    {
                        SittingID = 3,
                        SittingName = "Dinner",
                        Sitting_StartTime = DateTime.Parse("0001/01/01 18:00 pm"),
                        Sitting_EndTime = DateTime.Parse("0001/01/01 11:00 pm")
                    }
                );

            //--------------------------------Tables
            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<Table>().HasData(
                    new Table
                    {
                        TableID = i,
                        TableName = "M" + i,
                        Area = "Main"
                    }
                );
            }
            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<Table>().HasData(
                    new Table
                    {
                        TableID = i + 10,
                        TableName = "B" + i,
                        Area = "Balcony"
                    }
                );
            }
            for (int i = 1; i <= 10; i++)
            {
                builder.Entity<Table>().HasData(
                    new Table
                    {
                        TableID = i + 20,
                        TableName = "O" + i,
                        Area = "Outside"
                    }
                );
            }
        }
    }
}
