using ChecklistWebApplication.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoListWebApplication.Models;

namespace ToDoListWebApplication.Controllers
{
    [ApiController]
    [ControllerName("ToDoList")]
    public class ToDoListController : ControllerBase
    {
        [HttpGet, Route("api/[controller]")]
        public ActionResult<List<ToDoListModel>> Get()
        {
            var toDoList = ToDoListStore.GetAllToDoList();

            if (toDoList.Any())
            {
                return Ok(toDoList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet, Route("api/[controller]/{id}")]
        public ActionResult<ToDoListModel> GetItem(int id)
        {
            var toDoList = ToDoListStore.GetToDoListItem(id);

            if (toDoList != null)
            {
                return Ok(toDoList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost, Route("api/[controller]")]
        public ActionResult<List<ToDoListModel>> Post([FromBody] List<ToDoListModel> model)
        {
            return Created("", ToDoListStore.AddToDoList(model));
        }

        [HttpPost, Route("api/[controller]/{id}")]
        public ActionResult<ToDoListModel> PostItem([FromBody] ToDoListModel model)
        {
            return Created("", ToDoListStore.AddToDoListItem(model));
        }

        [HttpPut, Route("api/[controller]/{id}")]
        public ActionResult<ToDoListModel> Put([FromBody] ToDoListModel model, int id)
        {
            var toDoList = ToDoListStore.UpdateToDoListItem(model, id);

            if (toDoList != null)
            {
                return Ok(toDoList);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete, Route("api/[controller]")]
        public ActionResult Delete()
        {
            ToDoListStore.DeleteToDoList();
            return NoContent();
        }

        [HttpDelete, Route("api/[controller]/{id}")]
        public ActionResult DeleteItem(int id)
        {
            if (ToDoListStore.DeleteToDoListItem(id))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
