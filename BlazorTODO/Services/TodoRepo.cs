using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTODO.Services
{
    public class TodoRepo : ITodoRepo
    {
        public List<Todo> Todos;

        public int CurrentTodoId { get; set; } = 3;

        public TodoRepo()
        {
            Todos = new List<Todo>
            {
                new Todo
                {
                    Id = 1,
                    Title = "Create Blazor Todo App",
                    NewTitle = "Create Blazor Todo App"
                },
                new Todo
                {
                    Id = 2,
                    Title = "Take over the world!",
                    NewTitle = "Take over the world!"
                },
            };
        }

        public IEnumerable<Todo> GetTodo()
        {
            return Todos;
        }

        public void AddTodo(string title)
        {
            var newItem = new Todo
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
                obj = todo;
            }
        }

        public void DeleteTodo(Todo todo)
        {
            var x = Todos.FindIndex(t => t.Id == todo.Id);
            Todos.RemoveAt(x);
        }

        public IEnumerable<Todo> FilterTodo(string filter)
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
