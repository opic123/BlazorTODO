using BlazorTODO.Data;
using BlazorTODO.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTODO.Services
{
    public class SQLTodoRepo : ITodoRepo
    {
        private readonly TodoDbContext _context;

        public SQLTodoRepo(TodoDbContext context)
        {
            _context = context;
        }

        public Todo AddTodo(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
            return todo;
        }

        public void CheckAll(bool comp)
        {
            var todos = _context.Todos.ToList();
            todos.ForEach(todo => {
                todo.Completed = comp;
            });
            _context.SaveChanges();
        }

        public void ClearCompleted()
        {
            var todos = _context.Todos.Where(todo => todo.Completed).ToList();
            _context.Todos.RemoveRange(todos);
            _context.SaveChanges();
        }

        public int CountRemainingTodos()
        {
            return _context.Todos.Where(todo => !todo.Completed).ToList().Count();
        }

        public void DeleteTodo(int id)
        {
            var del = _context.Todos.FirstOrDefault(t => t.Id == id);
            _context.Todos.Remove(del);
            _context.SaveChanges();
        }

        public IEnumerable<Todo> FilterTodo(bool comp)
        {
            var todos = _context.Todos.Where(todo => todo.Completed == comp).ToList();
            return todos;
        }

        public IEnumerable<Todo> GetTodo()
        {
            return _context.Todos;

        }

        public void UpdateTodo(Todo todo)
        {
            _context.Attach(todo);
            _context.Entry(todo).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
