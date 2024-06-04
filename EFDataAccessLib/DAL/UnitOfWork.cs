using EFDataAccessLib.DAL.Repositories;
using EFDataAccessLib.DAL.Repositories.People;
using EFDataAccessLib.DAL.Repositories.People.Interfaces;
using EFDataAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLib.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly PeopleContext _context;
        private bool disposed = false;

        public UnitOfWork(PeopleContext context)
        {
            _context = context;
        }

        #region IRepositoryList_Lazy_approach

        #region People
        private IAccountRepository _AccountRepository;
        public IAccountRepository AccountRepository => _AccountRepository ?? new AccountRepository(_context);
        
        private IPeopleRepository _PeopleRepository;
        public IPeopleRepository PeopleRepository => _PeopleRepository ?? new PeopleRepository(_context);
        
        private IAddressRepository _AddressRepository;
        public IAddressRepository AddressRepository => _AddressRepository ?? new AddressRepository(_context);

        private IEmailRepository _EmailRepository;
        public IEmailRepository IEmailRepository => _EmailRepository ?? new EmailRepository(_context);
        #endregion

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork() { Dispose(false); }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
