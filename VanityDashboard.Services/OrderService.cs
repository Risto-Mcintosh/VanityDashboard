﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VanityDashboard.Data;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Services
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
            var mirror = GetComponent<Mirror>(newOrder.Vanity.Mirror);
            var table = GetComponent<Table>(newOrder.Vanity.Table);
            var baseMaterial = GetComponent<BaseMaterial>(newOrder.Vanity.BaseMaterial);

            newOrder.Customer = GetCustomer(newOrder);
            newOrder.Vanity.Mirror = mirror;
            newOrder.Vanity.Table = table;
            newOrder.Vanity.BaseMaterial = baseMaterial;
            newOrder.Vanity.MirrorPP = mirror.Price;
            newOrder.Vanity.TablePP = table.Price;
            newOrder.Vanity.BaseMaterialPP = baseMaterial.Price;
            newOrder.Total = CalulateTotal(newOrder.Vanity);
            newOrder.OrderedOn = DateTime.Now;
            newOrder.OrderStatus = OrderStatus.New;
            newOrder.KanbanColumn = db.KanbanColumns.Find(1);
            
            db.Orders.Add(newOrder);
            return newOrder;
        }

        private static decimal CalulateTotal(Vanity vanity)
        {
            return vanity.BaseMaterial.Price + vanity.Mirror.Price + vanity.Table.Price;
        }

        private T GetComponent<T> (VanityComponent component) where T : VanityComponent
        {
            return db.Set<T>().First(vc => vc.Size == component.Size);
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
            }
        }

        public Order GetOrder(int id)
        {
            return db.Orders
                .Where(o => o.Id == id)
                .Include(o => o.Customer)
                .Include(o => o.Vanity)
                .Include(o => o.KanbanColumn)
                .FirstOrDefault();
        }

        public IQueryable<Order> GetOrders()
        {
            return db.Orders
                .Include(o => o.Vanity)
                .Include(o => o.KanbanColumn)
                .Include(o => o.Customer);
        }

        public void UpdateOrder(Order order)
        {
            var oldOrder = db.Orders.Find(order.Id);
            var entity2 = db.Entry(oldOrder);
            entity2.CurrentValues.SetValues(order);

            /*var entity = db.Orders.Attach(oldOrder);
            entity.State = EntityState.Modified;*/
        }

        public int CommitChanges()
        {
            return db.SaveChanges();
        }
    }
}
