using System;
using System.Collections.Generic;
using System.Text;
using VanityDashboard.Data;
using VanityDashboard.Data.Models;

namespace VanityDashboard.Services
{
    public interface IKanbanBoardService
    {
        KanbanData GetKanbanData();
        KanbanColumn CreateKanbanColumn(string columnName);
        void DeleteKanbanColumn(int columnId);
        KanbanColumn UpdateKanbanColumn(KanbanColumn newColumn);
        KanbanColumnOrder UpdateColumnOrder(string[] newColumnOrder);
        Order UpdateOrderPosition(Order updatedOrder, bool markComplete = false);
        int CommitChanges();
    }
}
