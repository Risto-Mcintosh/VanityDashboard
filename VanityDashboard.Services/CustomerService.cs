using Microsoft.EntityFrameworkCore;
using System;
using VanityDashboard.Data;

namespace VanityDashboard.Services
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
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer;
        }

        public Customer GetCustomer(int id)
        {
            return db.Customers.Find(id);
        }

        public Customer UpdateCustomer(Customer updatedCustomer)
        {
            var entity = db.Customers.Attach(updatedCustomer);
            entity.State = EntityState.Modified;
            return updatedCustomer;
        }
    }
}
