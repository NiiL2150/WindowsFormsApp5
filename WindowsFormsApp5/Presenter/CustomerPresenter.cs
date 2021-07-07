using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp5.View;
using WindowsFormsApp5.Repository;
using WindowsFormsApp5.Model;

namespace WindowsFormsApp5.Presenter
{
    public class CustomerPresenter
    {
        ICustomerRepository repository;
        ICustomerView view;

        public CustomerPresenter(ICustomerView customerform, ICustomerRepository repository)
        {
            this.view = customerform;
            customerform.customerPresenter = this;
            this.repository = repository;
            UpdateCustomerListView();
        }

        public void UpdateCustomerView(int id)
        {
            Customer customer = repository.GetCustomerById(id);
            view.FullName = customer.Fullname;
            view.Address = customer.Address;
            view.Email = customer.Email;
            view.Citizenship = customer.Citizenship;
        }

        public void SaveCustomer()
        {
            Customer customer = new Customer(view.FullName, view.Address, view.Email, view.Citizenship);
            repository.SaveCustomer(view.SelectedCustomer, customer);
            UpdateCustomerListView();
        }

        public void AddCustomer()
        {
            Customer customer = new Customer(view.FullName, view.Address, view.Email, view.Citizenship);
            repository.AddCustomer(customer);
            UpdateCustomerListView();
        }

        private void UpdateCustomerListView()
        {
            var customerNames = repository.GetAllCustomers().Select(x => x.Fullname);
            int selectedCustomer = view.SelectedCustomer >= 0 ? view.SelectedCustomer : 0;
            view.CustomerList = customerNames.ToList();
            view.SelectedCustomer = selectedCustomer;
        }
    }
}
