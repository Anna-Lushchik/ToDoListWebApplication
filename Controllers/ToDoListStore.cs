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
            if (ToDoList.ContainsKey(id)) 
            { 
                return ToDoList[id];
            }
            else
            {
                return null;
            }
        }

        public static List<ToDoListModel> AddToDoList(List<ToDoListModel> model)
        {
            foreach (ToDoListModel m in model)
            {
                int newItemId = (ToDoList.Count == 0) ? 1 : ToDoList.Keys.Max() + 1;
                ToDoList.Add(newItemId, new ToDoListModel { Text = m.Text, Id = newItemId, Priority = m.Priority });
            }

            return model;
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
            if (ToDoList.ContainsKey(id))
            {
                var model = GetToDoListItem(id);
                model.Text = newModel.Text;
                model.Priority = newModel.Priority;

                return model;
            }
            else
            {
                return null;
            }
        }

        public static void DeleteToDoList()
        {
            ToDoList.Clear();
        }

        public static bool DeleteToDoListItem(int id)
        {
            return ToDoList.Remove(id);
        }
    }
}
