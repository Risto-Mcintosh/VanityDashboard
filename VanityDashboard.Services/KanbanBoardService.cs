using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VanityDashboard.Data;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Services
{
    public class KanbanBoardService : IKanbanBoardService
    {
        private readonly AppDbContext db;

        public KanbanBoardService(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<KanbanColumn> GetKanbanColumns()
        {
            return db.KanbanColumns.OrderBy(c => c.ColumnPosition);
        }

        public KanbanColumn CreateKanbanColumn(string columnName)
        {
            var LastColumn = db.KanbanColumns.First(c => c.IsCompleteColumn == true);
            KanbanColumn newColumn = new KanbanColumn() { ColumnName = columnName, ColumnPosition = LastColumn.ColumnPosition};
  
            var entity = db.KanbanColumns.Attach(LastColumn);
            LastColumn.ColumnPosition += 1;
            entity.State = EntityState.Modified;
            return db.KanbanColumns.Add(newColumn).Entity;
        }

        public void DeleteKanbanColumn(int columnId)
        {
            var column = db.KanbanColumns.Find(columnId);
            if (column != null && (column.IsStartColumn || column.IsCompleteColumn))
            {
                db.KanbanColumns.Remove(column);
            };
        }

        public KanbanColumn UpdateKanbanColumn(KanbanColumn newColumn)
        {
            var entity = db.KanbanColumns.Attach(newColumn);
            entity.State = EntityState.Modified;
            return newColumn;
        }

        public int CommitChanges()
        {
            return db.SaveChanges();
        }
    }
}
