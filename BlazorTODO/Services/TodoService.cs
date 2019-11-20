using BlazorTODO.Data;
using BlazorTODO.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTODO.Services
{
    public class TodoService
    {
        public async Task<IEnumerable<TodoViewModel>> LoadTodos()
        {
            string url = "todos";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    IEnumerable<TodoViewModel> todos = JsonConvert.DeserializeObject<List<TodoViewModel>>(jsonResponse);
                    return todos;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }


        public async Task<IEnumerable<TodoViewModel>> FilterTodos(bool completed)
        {
            string url = $"todos/FilterTodos?completed={completed}";

            // var content = new StringContent(filters.ToString());

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    IEnumerable<TodoViewModel> todos = JsonConvert.DeserializeObject<List<TodoViewModel>>(jsonResponse);
                    return todos;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }

        public async Task<string> CheckAll(Todo todo)
        {
            string url = "todos/CheckAll";

            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return jsonResponse.ToString();

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }

        public async Task<TodoViewModel> AddTodo(Todo todo)
        {
            string url = "todos";

            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    TodoViewModel todoViewModel = JsonConvert.DeserializeObject<TodoViewModel>(jsonResponse);
                    return todoViewModel;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }

        public async Task<string> DeleteTodo(Todo todo)
        {
            string url = $"todos/Delete?id={todo.Id}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return jsonResponse.ToString();

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }


        public async Task<TodoViewModel> UpdateTodo(Todo todo)
        {
            string url = "todos/edit";

            var json = JsonConvert.SerializeObject(todo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, content))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    TodoViewModel todoViewModel = JsonConvert.DeserializeObject<TodoViewModel>(jsonResponse);
                    return todoViewModel;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }

        public async Task<string> ClearCompleted()
        {
            string url = "todos/ClearCompleted";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(url))
            {

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    return jsonResponse.ToString();

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }
        }



    }
}
