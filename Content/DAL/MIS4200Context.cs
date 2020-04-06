using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team_16_Centric_Project.Models;
using System.Data.Entity;

namespace Team_16_Centric_Project.Content.DAL
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")

        {

            // this method is a 'constructor' and is called when a new context is created

            // the base attribute says which connection string to use
        }

        // Include each object here. The value inside <> is the name of the class,

        // the value outside should generally be the plural of the class name

        // and is the name used to reference the entity in code
        public DbSet<Recognition> Recognitions { get; set; }
        public DbSet<EmployeeRecognition> EmployeeRecognitions { get; set; }
        public DbSet<ValuesRecognition> ValuesRecognitions { get; set; }
        public DbSet<RecognitionDetail> RecognitionDetails { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
