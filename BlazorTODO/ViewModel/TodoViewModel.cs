using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorTODO.Data;

namespace BlazorTODO.ViewModel
{
    public class TodoViewModel : Todo
    {
        public string NewTitle { get; set; } = "";

        public bool Editing { get; set; } = false;
    }
}
