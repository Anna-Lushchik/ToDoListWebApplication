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
        public List<ToDoListModel> Get()
        {
            return ToDoListStore.GetAllToDoList();
        }

        [HttpGet, Route("api/[controller]/{id}")]
        public ToDoListModel GetItem(int id)
        {
            return ToDoListStore.GetToDoListItem(id);
        }

        [HttpPost, Route("api/[controller]")]
        public ToDoListModel Post([FromBody] ToDoListModel model)
        {
            return ToDoListStore.AddToDoListItem(model);
        }

        [HttpPut, Route("api/[controller]/{id}")]
        public ToDoListModel Put([FromBody] ToDoListModel model, int id)
        {
            return ToDoListStore.UpdateToDoListItem(model, id);
        }

        [HttpDelete, Route("api/[controller]/{id}")]
        public void Delete(int id)
        {
            ToDoListStore.DeleteToDoListItem(id);
        }
    }
}
