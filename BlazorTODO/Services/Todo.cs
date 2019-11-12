using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTODO.Services
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string NewTitle { get; set; } = "";

        public bool Completed { get; set; } = false;
        public bool Editing { get; set; } = false;
    }
}
