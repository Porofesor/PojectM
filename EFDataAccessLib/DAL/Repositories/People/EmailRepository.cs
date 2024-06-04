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
    public class EmailRepository : GenericRepository<Email, int>, IEmailRepository
    {
        public EmailRepository(PeopleContext context) : base(context)
        {
        }
    }
}
