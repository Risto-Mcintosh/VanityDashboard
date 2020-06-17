using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanityDashboard.Data.Models;
using VanityDashboard.Services;

namespace VanityDashboard.Web.Controllers
{
    [ApiController]
    public class KanbanBoardController : ControllerBase
    {
        private readonly IKanbanBoardService kanbanBoard;

        public KanbanBoardController(IKanbanBoardService kanbanBoard)
        {
            this.kanbanBoard = kanbanBoard;
        }

        [HttpGet("api/kanban-board")]
        public ActionResult GetKanbanData()
        {
            return Ok(kanbanBoard.GetKanbanData());
        }

        [HttpPut("api/kanban-board")]
        public ActionResult UpdateColumnOrder(string[] columnOrder)
        {
            var newColumnOrder = kanbanBoard.UpdateColumnOrder(columnOrder);
            if (kanbanBoard.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(newColumnOrder);
        }

        [HttpDelete("api/kanban-board/column/{id}")]
        public ActionResult DeleteColumn(int id, string[] columnOrder)
        {
            kanbanBoard.DeleteKanbanColumn(id, columnOrder);

            if (kanbanBoard.CommitChanges() < 1)
            {
               return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
            return Ok();
        }

        [HttpPut("api/kanban-board/column/{id}")]
        public ActionResult UpdateColumn(KanbanColumn newColumn)
        {
            var updatedColumn = kanbanBoard.UpdateKanbanColumn(newColumn);
            if (kanbanBoard.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(updatedColumn);
        }

        [HttpPost("api/kanban-board/column")]
        public ActionResult CreateColumn(string columnName)
        {
            var createdColumn = kanbanBoard.CreateKanbanColumn(columnName);
            if (kanbanBoard.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(createdColumn);
        }
    }
}
