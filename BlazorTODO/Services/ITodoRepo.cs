using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTODO.Data;
using BlazorTODO.ViewModel;

namespace BlazorTODO.Services
{
    // <Generic> generic interface
    public interface ITodoRepo
    {
        public IEnumerable<Todo> GetTodo();

        public Todo AddTodo(Todo todo);

        public void UpdateTodo(Todo todo);

        public void DeleteTodo(int id);

        public IEnumerable<Todo> FilterTodo(bool comp);

        public int CountRemainingTodos();

        public void CheckAll(bool comp);

        public void ClearCompleted();
    }
}
