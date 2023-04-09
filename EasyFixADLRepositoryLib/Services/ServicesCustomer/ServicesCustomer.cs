using BuildingADLRepositoryLib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingADLRepositoryLib.Services.ServicesCustomer
{
    public class ServicesCustomer: IServicesCustomer
    {
        private readonly TechnicalSupportContext _context;
        public ServicesCustomer(TechnicalSupportContext context)
        {
            _context = context;
        }

        public IEnumerable DeleteCustomer(int id)
        {
            try
            {
                Customer customer = _context.Find<Customer>(id);
                if (customer != null)
                {
                    _context.Remove<Customer>(customer);
                    _context.SaveChanges();
                    return ("1");
                }
                return ("0");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Customer>    GetALL()
        {
            List<Customer> Customer;
            try
            {
                Customer = _context.Set<Customer>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Customer;
        }

        public Customer GetbyID(int id)
        {
            Customer customer;
            try
            {
                customer = _context.Find<Customer>(id);
                
                
            }
            catch (Exception)
            {

                throw;
            }
            return customer;
        }

        public IEnumerable PostCustomer(CustomerList customerList)
        {
            try
            {
                Customer customer = new Customer();
                customer.Address = customerList.Address;
                customer.CustomerName = customerList.CustomerName;
                customer.Notes = customerList.Notes;
                customer.Responsabilty = customerList.Responsabilty;
                customer.Tel = customerList.Tel;
                customer.Email = customerList.Email;
                _context.Add<Customer>(customer);
                _context.SaveChanges();
                var ListCustomer = (from a in _context.Customers
                                    where a.CustomerID == customer.CustomerID 
                                    select a)
                                   .ToList();
                return ListCustomer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable UpdateCustomer(CustomerList customerList)
        {
            try
            {
                Customer customer =_context.Find<Customer>(customerList.CustomerID);
                if (customer is not null)
                {
                    customer.Address = customerList.Address;
                    customer.CustomerName = customerList.CustomerName;
                    customer.Notes = customerList.Notes;
                    customer.Responsabilty = customerList.Responsabilty;
                    customer.Tel = customerList.Tel;
                    customer.Email = customerList.Email;
                    _context.Update<Customer>(customer);
                }
                
                _context.SaveChanges();
                var ListCustomer = (from a in _context.Customers
                                    where a.CustomerID == customer.CustomerID select a)
                                   .ToList();
                return ListCustomer;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public class CustomerList
        {
            public int CustomerID { get; set; }

            public string CustomerName { get; set; } = null!;

            public string? Tel { get; set; }

            public string? Address { get; set; }

            public string Responsabilty { get; set; } = null!;

            public string? Notes { get; set; }
            public string? Email { get; set; }

        }
    }
}
