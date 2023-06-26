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
        public List<ToDoListModel> Post([FromBody] List<ToDoListModel> model)
        {
            return ToDoListStore.AddToDoList(model);
        }

        [HttpPost, Route("api/[controller]/{id}")]
        public ToDoListModel PostItem([FromBody] ToDoListModel model, int id)
        {
            return ToDoListStore.AddToDoListItem(model);
        }

        [HttpPut, Route("api/[controller]/{id}")]
        public ToDoListModel Put([FromBody] ToDoListModel model, int id)
        {
            return ToDoListStore.UpdateToDoListItem(model, id);
        }

        [HttpDelete, Route("api/[controller]")]
        public void Delete()
        {
            ToDoListStore.DeleteToDoList();
        }

        [HttpDelete, Route("api/[controller]/{id}")]
        public void DeleteItem(int id)
        {
            ToDoListStore.DeleteToDoListItem(id);
        }
    }
}
