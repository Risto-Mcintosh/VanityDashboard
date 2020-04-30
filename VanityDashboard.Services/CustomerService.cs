using System;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext db;

        public CustomerService(AppDbContext db)
        {
            this.db = db;
        }
        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer UpdateCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
