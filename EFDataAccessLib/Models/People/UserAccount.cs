using EFDataAccessLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLib.Models;
using EFDataAccessLib.Models.Permissions;

namespace EFDataAccessLib.Models.People
{
    public class UserAccount : DbEntityObject
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual Person Person { get; set; }
        public virtual UsersPermissions Permissions { get; set; }
    }
}
