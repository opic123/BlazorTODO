using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTODO.Data;
using BlazorTODO.ViewModel;

namespace BlazorTODO.Services
{
    public class MockTodoRepo
    {
        public List<TodoViewModel> Todos;

        public int CurrentTodoId { get; set; } = 3;

        public MockTodoRepo()
        {
            Todos = new List<TodoViewModel>
            {
                new TodoViewModel
                {
                    Id = 1,
                    Title = "Create Blazor Todo App",
                    Completed = false,
                    NewTitle = "Create Blazor Todo App"
                },
                new TodoViewModel
                {
                    Id = 2,
                    Title = "Take over the world!",
                    Completed = false,
                    NewTitle = "Take over the world!"
                },
            };
        }

        public IEnumerable<TodoViewModel> GetTodo()
        {
            return Todos;
        }

        public void AddTodo(string title)
        {
            var newItem = new TodoViewModel
            {
                Id = CurrentTodoId++,
                Title = title,
                NewTitle = title
            };
            Todos.Add(newItem);
        }

        public void UpdateTodo(Todo todo)
        {
            var obj = Todos.Find(t => t.Id == todo.Id);
            if (obj != null)
            {
                // obj = todo;
            }
        }

        public void DeleteTodo(Todo todo)
        {
            var x = Todos.FindIndex(t => t.Id == todo.Id);
            Todos.RemoveAt(x);
        }

        public IEnumerable<TodoViewModel> FilterTodo(string filter)
        {
            if (filter == "Active")
            {
                return Todos.Where(todo => !todo.Completed).ToList();
            }
            else if (filter == "Completed")
            {
                return Todos.Where(todo => todo.Completed).ToList();
            }
            else
            {
                // All
                return Todos;
            }
        }

        public int CountRemainingTodos()
        {
            var count = (Todos.Where(todo => !todo.Completed)).ToList().Count;
            return count;
        }

        public void CheckAll(bool selected)
        {
            Todos.ForEach(todo => todo.Completed = selected);
        }

        public void ClearCompleted()
        {
            Todos = Todos.Where(todo => !todo.Completed).ToList();
        }

        
    }
}
