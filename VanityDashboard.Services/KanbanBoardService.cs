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
            return db.KanbanColumns;
        }

        public KanbanColumn CreateKanbanColumn(string columnName)
        {
            
            var newColumn = db.KanbanColumns.Add(new KanbanColumn() { ColumnName = columnName }).Entity;
            var columnOrder = db.KanbanColumnOrder.Find(1);
            var columnOrderList = columnOrder.Order.ToList();
            columnOrderList.Insert(columnOrderList.Count - 1, newColumn.Id.ToString());
            columnOrder.Order = columnOrderList.ToArray();
            UpdateColumnOrder(columnOrder);
            return newColumn;
        }

        public void DeleteKanbanColumn(int columnId, string[] columnOrder)
        {

            var column = db.KanbanColumns.Find(columnId);
            if (column != null && (column.IsStartColumn || column.IsCompleteColumn))
            {
                UpdateColumnOrder(columnOrder);
                db.KanbanColumns.Remove(column);
            };
        }

        public KanbanColumn UpdateKanbanColumn(KanbanColumn newColumn)
        {
            var entity = db.KanbanColumns.Attach(newColumn);
            entity.State = EntityState.Modified;
            return newColumn;
        }

        private void UpdateColumnOrder(KanbanColumnOrder newColumnOrder)
        {
            var entity = db.KanbanColumnOrder.Attach(newColumnOrder);
            entity.State = EntityState.Modified;
        }

        public KanbanColumnOrder UpdateColumnOrder(string[] newColumnOrder)
        {
            var columnOrder = db.KanbanColumnOrder.Find(1);
            columnOrder.Order = newColumnOrder;
            var entity = db.KanbanColumnOrder.Attach(columnOrder);
            entity.State = EntityState.Modified;
            return columnOrder;
        }

        public int CommitChanges()
        {
            return db.SaveChanges();
        }
    }
}
