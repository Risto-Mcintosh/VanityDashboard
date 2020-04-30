using System;
using System.Collections.Generic;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext db;

        public OrderService(AppDbContext db)
        {
            this.db = db;
        }
        public Order CreateOrder()
        {
           throw new NotImplementedException();
        }

        public void DeleteOrder()
        {
            throw new NotImplementedException();
        }

        public Order GetOrder()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Order UpdateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
