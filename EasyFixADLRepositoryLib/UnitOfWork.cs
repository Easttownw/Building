using RepositoryPattern.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Core.Interfaces;
using BuildingADLRepositoryLib.Models;
using BuildingADLRepositoryLib.Services.ServicesCustomer;
using BuildingADLRepositoryLib.Services.ServicesTbUser;
using BuildingADLRepositoryLib.Services.ServicesLogin;

namespace RepositoryPattern.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TechnicalSupportContext _context;
        public IIssueCustomerService _IIssueCustomerService { get; private set; }


        public IServicesTbUser TbUser { get; private set; }
        public IServicesCustomer Customer { get; private set; }
        public IServicesLogin login { get; private set; }

        public UnitOfWork(TechnicalSupportContext context)
        {
            _context = context;

            _IIssueCustomerService = new IssueCustomerService(_context);
            Customer = new ServicesCustomer(_context);
            TbUser = new ServicesTbUser(_context);
            login = new ServicesLogin(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
     {
            _context.Dispose();
        }
    }
}