﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.DAL
{
    public interface IUnitOfWork<out TContext> where TContext: DbContext, new()
    {
        TContext Context { get; }

        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
