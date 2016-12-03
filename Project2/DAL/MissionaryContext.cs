using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2.DAL
{
    public class MissionaryContext : DbContext
    {
        public MissionaryContext()
            : base("MissionaryContext")
        {

        }

        public System.Data.Entity.DbSet<Project2.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<Project2.Models.Missions> Missions { get; set; }

        public System.Data.Entity.DbSet<Project2.Models.MissionQuestions> MissionQuestions { get; set; }

    }
}