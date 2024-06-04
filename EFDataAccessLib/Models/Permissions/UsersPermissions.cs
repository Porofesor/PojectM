using EFDataAccessLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.Models.Permissions
{
    public class UsersPermissions : DbEntityObject
    {
        public string PermissionName { get; set; }
        public int PermissionNumber { get; set; }
    }
}
