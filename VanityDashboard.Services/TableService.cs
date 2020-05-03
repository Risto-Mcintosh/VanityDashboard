using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VanityDashboard.Data;

namespace VanityDashboard.Servies
{
    public class TableService : ITableService
    {
        private readonly AppDbContext db;

        public TableService(AppDbContext db)
        {
            this.db = db;
        }
 

        public Table GetTable(Sizes size)
        {
            return db.Tables.FirstOrDefault(t => t.Size == size);
        }

        public IEnumerable<Table> GetTables()
        {
            return db.Tables;
        }

        public Table UpdateTable(Table table)
        {
            var entity = db.Tables.Attach(table);
            entity.State = EntityState.Modified;
            return table;
        }

        public int CommitChanges()
        {
            return db.SaveChanges();
        }
    }
}
