using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTODO.Data;
using BlazorTODO.Services;
using BlazorTODO.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorTODO.Controllers
{
    //ControllerBase
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TodosController : Controller
    {
        private readonly ITodoRepo _repo;

        public TodosController(ITodoRepo repo)
        {
            _repo = repo;
        }

        // GET api/todos
        [HttpGet]
        public ActionResult Index()
        {
            var todos = _repo.GetTodo().ToList();

            List<TodoViewModel> todosViewModel = new List<TodoViewModel>();

            foreach (var todo in todos)
            {
                todosViewModel.Add(SetUpTodoViewModel(todo));
            }

            return Ok(todosViewModel);
        }

        // POST api/todos
        [HttpPost]
        public ActionResult Store([FromBody] Todo todo)
        {
            // no need to use ModelState.IsValid
            // automatic validation of required fields same as FormRequest of laravel
            _repo.AddTodo(todo);

            return Ok(SetUpTodoViewModel(todo));
           
        }

        // by default ASP NET CORE will not allow multiple post method
        // to fix this we have to declare Route attribute and include the action reference
        // PUT api/todos/CheckAll
        [Route("[action]")]
        [HttpPost]
        public ActionResult CheckAll(TodoFilters todoFilters)
        {
            _repo.CheckAll(todoFilters.completed);
            return Ok("Updated Succesfully");
        }

        // by default ASP NET CORE will not allow multiple post method
        // to fix this we have to declare Route attribute and include the action reference
        // PUT api/todos/CheckAll
        [Route("[action]")]
        [HttpDelete]
        public ActionResult ClearCompleted()
        {
            _repo.ClearCompleted();
            return Ok("Updated Succesfully");
        }

        // by default ASP NET CORE will not allow multiple post method
        // to fix this we have to declare Route attribute and include the action reference
        // PUT api/todos/Edit
        [Route("[action]")]
        [HttpPost]
        public ActionResult Edit([FromBody] Todo todo)
        {
            _repo.UpdateTodo(todo);
            return Ok(SetUpTodoViewModel(todo));
        }

        // by default ASP NET CORE will not allow multiple post method
        // to fix this we have to declare Route attribute and include the action reference
        // PUT api/todos/FilterTodos
        [Route("[action]")]
        [HttpGet]
        public ActionResult FilterTodos(bool completed)
        {
            List<TodoViewModel> todoViewModels = new List<TodoViewModel>();
            var todos = _repo.FilterTodo(completed);
            foreach (var todo in todos)
            {
                todoViewModels.Add(SetUpTodoViewModel(todo));
            }
           
            return Ok(todoViewModels);
        }

        // by default ASP NET CORE will not allow multiple post method
        // to fix this we have to declare Route attribute and include the action reference
        // PUT api/todos/Remaining
        [Route("[action]")]
        [HttpGet]
        public ActionResult RemainingTodos()
        {
            return Ok(_repo.CountRemainingTodos());
        }

        // by default ASP NET CORE will not allow multiple post method
        // to fix this we have to declare Route attribute and include the action reference
        // Delete api/todos/Delete
        [Route("[action]")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _repo.DeleteTodo(id);
            return Ok("Deleted Succesfully");
        }


        public TodoViewModel SetUpTodoViewModel(Todo todo)
        {

            TodoViewModel todoViewModel = new TodoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                NewTitle = todo.Title,
                Completed = todo.Completed,
                Editing = false
            };

            return todoViewModel;

        }
    }
}