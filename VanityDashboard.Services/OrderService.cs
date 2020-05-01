using Microsoft.EntityFrameworkCore;
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

        public Order CreateOrder(Order order)
        {
            db.Add(order);
            db.SaveChanges();
            return order;
        }

        public void DeleteOrder(int id)
        {
            var order = db.Orders.Find(id);
            if (order != null)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public Order GetOrder(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return db.Orders;
        }

        public Order UpdateOrder(Order order)
        {
            var entity = db.Orders.Attach(order);
            entity.State = EntityState.Modified;
            return order;
        }
    }
}
