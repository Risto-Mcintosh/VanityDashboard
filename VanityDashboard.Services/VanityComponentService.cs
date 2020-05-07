using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VanityDashboard.Data;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Services
{
    public class VanityComponentService<T> : IVanityComponentService<T> where T : VanityComponent
    {
        private readonly AppDbContext db;

        public VanityComponentService(AppDbContext db)
        {
            this.db = db;
        }
        int IVanityComponentService<T>.CommitChanges()
        {
            return db.SaveChanges();
        }

        T IVanityComponentService<T>.Get(Size size)
        {
            return db.Set<T>().FirstOrDefault( vc => vc.Size == size);
        }

        IEnumerable<T> IVanityComponentService<T>.GetAll()
        {
            return db.Set<T>();
        }

        T IVanityComponentService<T>.Update(T component)
        {
            var entity = db.Set<T>().Attach(component);
            entity.State = EntityState.Modified;
            return component;
        }
    }
}
