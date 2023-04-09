

//using EasyFixADLRepositoryLib.Models; 


using BuildingADLRepositoryLib.Services.ServicesCustomer;
using BuildingADLRepositoryLib.Services.ServicesLogin;
using BuildingADLRepositoryLib.Services.ServicesTbUser;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Core.Interfaces;
//using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core
{
    public interface IUnitOfWork : IDisposable
    {

        // IRebuildingService Rebuilding { get; }
        IIssueCustomerService _IIssueCustomerService { get; }
        IServicesCustomer Customer { get; }
        IServicesTbUser TbUser { get; }
        IServicesLogin login { get; }   

        int Complete();
    }
}