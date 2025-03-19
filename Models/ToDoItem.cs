using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoTracker_Lab.Models
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public string Priority { get; set; }
    }
}
