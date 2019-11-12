using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTODO.Services
{
    interface ITodoRepo
    {
        IEnumerable<Todo> GetTodo();

        public void AddTodo(string title);

        public void UpdateTodo(Todo todo);

        public void DeleteTodo(Todo todo);

        public IEnumerable<Todo> FilterTodo(string filter);

        public int CountRemainingTodos();

        public void CheckAll(bool selected);

        public void ClearCompleted();
    }
}
