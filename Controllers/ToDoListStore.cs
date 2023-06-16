using ToDoListWebApplication.Models;

namespace ChecklistWebApplication.Controllers
{
    public class ToDoListStore
    {
        static IDictionary<int, ToDoListModel> ToDoList = new Dictionary<int, ToDoListModel>()
        {
            { 1, new ToDoListModel {Text = "Go to the shop", Id = 1, Priority = 2 } },
            { 2, new ToDoListModel {Text = "Сlean up the apartment", Id = 2, Priority = 2 } },
            { 3, new ToDoListModel {Text = "Сook dinner", Id = 3, Priority = 1 } }
        };

        public static List<ToDoListModel> GetAllToDoList()
        {
            return ToDoList.Values.ToList();
        }

        public static ToDoListModel GetToDoListItem(int id)
        {
            return ToDoList[id];
        }

        public static ToDoListModel AddToDoListItem(ToDoListModel model)
        {
            int newItemId = ToDoList.Keys.Max() + 1;
            var newModel = new ToDoListModel { Text = model.Text, Id = newItemId, Priority = model.Priority };
            ToDoList.Add(newItemId, newModel);

            return newModel;
        }

        public static ToDoListModel UpdateToDoListItem(ToDoListModel newModel, int id)
        {
            var model = GetToDoListItem(id);
            model.Text = newModel.Text;
            model.Priority = newModel.Priority;

            return model;
        }

        public static void DeleteToDoListItem(int id)
        {
            ToDoList.Remove(id);
        }
    }
}
