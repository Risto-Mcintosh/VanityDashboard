using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data;

namespace VanityDashboard.Services
{
    public interface IVanityComponentService<T>
    {
        T Get(Size size);
        T Update(T component);
        IEnumerable<T> GetAll();
        public int CommitChanges();
    }
}
