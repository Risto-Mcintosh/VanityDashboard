using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VanityDashboard.Data.Dto;
using VanityDashboard.Data.Models;
using VanityDashboard.Services;

namespace VanityDashboard.Web.Controllers
{
    [ApiController]
    public class KanbanBoardController : ControllerBase
    {
        private readonly IKanbanBoardService kanbanBoard;
        private readonly IMapper mapper;

        public KanbanBoardController(IKanbanBoardService kanbanBoard, IMapper mapper)
        {
            this.kanbanBoard = kanbanBoard;
            this.mapper = mapper;
        }

        [HttpGet("api/kanban-board")]
        public ActionResult GetKanbanData()
        {
            var kanbanData = kanbanBoard.GetKanbanData();
            if (kanbanData == null)
            {
                return BadRequest();
            }
            return Ok(mapper.Map<KanbanDataDto>(kanbanData));
        }

        [HttpPut("api/kanban-board")]
        public ActionResult UpdateColumnOrder([FromBody] string[] columnOrder)
        {
            var newColumnOrder = kanbanBoard.UpdateColumnOrder(columnOrder);
            if (kanbanBoard.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(newColumnOrder.Order);
        }

        [HttpDelete("api/kanban-board/column/{id}")]
        public ActionResult DeleteColumn(int id)
        {
            kanbanBoard.DeleteKanbanColumn(id);

            if (kanbanBoard.CommitChanges() < 1)
            {
               return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
            return Ok();
        }

        [HttpPut("api/kanban-board/column/{id}")]
        public ActionResult UpdateColumn(KanbanColumnDto newColumn)
        {
            var updatedColumn = kanbanBoard.UpdateKanbanColumn(mapper.Map<KanbanColumn>(newColumn));
            if (kanbanBoard.CommitChanges() < 1)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(mapper.Map<KanbanColumnDto>(updatedColumn));
        }

        [HttpPost("api/kanban-board/column")]
        public ActionResult CreateColumn([FromBody] string columnName)
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
