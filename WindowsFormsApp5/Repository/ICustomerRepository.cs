using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.Model;

namespace WindowsFormsApp5.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);

        void SaveCustomer(int id, Customer customer);
        void AddCustomer(Customer customer);
    }
}