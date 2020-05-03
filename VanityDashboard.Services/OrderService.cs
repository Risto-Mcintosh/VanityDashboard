using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Order CreateOrder(Order newOrder)
        {
            newOrder.Customer = GetCustomer(newOrder);
            newOrder.Mirror = GetMirror(newOrder);
            newOrder.Table = GetTable(newOrder);
            newOrder.Total = CalulateTotal(newOrder.Table.Price, newOrder.Mirror.Price);
            newOrder.OrderedOn = DateTime.Now;
            newOrder.OrderStatus = OrderStatus.New;
            
            db.Orders.Add(newOrder);
            db.SaveChanges();
            return newOrder;
        }

        private static decimal CalulateTotal(decimal price1, decimal price2)
        {
            return price1 + price2;
        }

        private Mirror GetMirror(Order newOrder)
        {
            return db.Mirrors.First(m => m.Size == newOrder.Mirror.Size);
        }

        private Table GetTable(Order newOrder)
        {
            return db.Tables.First(t => t.Size == newOrder.Table.Size);
        }

        private Customer GetCustomer(Order newOrder)
        {
            var found = db.Customers.FirstOrDefault(c => c.Email == newOrder.Customer.Email);
            if (found == null)
            {
                return db.Customers.Add(newOrder.Customer).Entity;
            }

            return found;
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
            return db.Orders.Include(o => o.Mirror).Include(o => o.Table).Include(o => o.Customer);
        }

        public Order UpdateOrder(Order order)
        {
            var entity = db.Orders.Attach(order);
            entity.State = EntityState.Modified;
            return order;
        }

        public int CommitChanges()
        {
            return db.SaveChanges();
        }
    }
}
