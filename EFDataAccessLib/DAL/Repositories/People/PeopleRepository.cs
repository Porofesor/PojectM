﻿using EFDataAccessLib.DataAccess;
using EFDataAccessLib.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.DAL.Repositories.People.Interfaces
{
    public class PeopleRepository : GenericRepository<Person, int>, IPeopleRepository
    {
        public PeopleRepository(PeopleContext context) : base(context)
        {
        }
    }
}
