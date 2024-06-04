using EFDataAccessLib.Models.People;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext() { }
        public PeopleContext(DbContextOptions options) : base(options) { }

        #region Models
        public virtual DbSet<UserAccount> Account { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        #endregion
    }
}
