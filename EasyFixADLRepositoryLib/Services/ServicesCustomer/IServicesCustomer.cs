using BuildingADLRepositoryLib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BuildingADLRepositoryLib.Services.ServicesCustomer.ServicesCustomer;

namespace BuildingADLRepositoryLib.Services.ServicesCustomer
{
    public interface IServicesCustomer
    {
        public List<Customer> GetALL();
        public Customer GetbyID(int id); 
        public IEnumerable PostCustomer(CustomerList customerList);
        public IEnumerable UpdateCustomer(CustomerList customerList);
        public IEnumerable DeleteCustomer(int id);
    }
}
