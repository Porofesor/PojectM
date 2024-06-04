using EFDataAccessLib.DAL.Repositories.People.Interfaces;
using EFDataAccessLib.DataAccess;
using EFDataAccessLib.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.DAL.Repositories.People
{
    public class AccountRepository : GenericRepository<UserAccount, int>, IAccountRepository
    {
        public AccountRepository(PeopleContext context) : base(context)
        {
        }
    }
}
