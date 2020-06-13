using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Services
{
    public interface IKanbanBoardService
    {
        IEnumerable<KanbanColumn> GetKanbanColumns();
        KanbanColumn CreateKanbanColumn(string columnName);
        void DeleteKanbanColumn(int columnId, string[] columnOrder);
        KanbanColumn UpdateKanbanColumn(KanbanColumn newColumn);
        public KanbanColumnOrder UpdateColumnOrder(string[] newColumnOrder);
        public int CommitChanges();
    }
}
