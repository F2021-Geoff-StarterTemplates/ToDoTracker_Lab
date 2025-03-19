using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoTracker_Lab.Models;

namespace ToDoTracker_Lab.ViewModels
{
    public class ToDoViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ToDoItem> _items;
        public ObservableCollection<ToDoItem> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ToDoViewModel()
        {
            Items = new ObservableCollection<ToDoItem>();
        }

        public void AddItem(string title, DateTime dueDate, string priority)
        {
            if (IsDueDateValid(dueDate) && IsPriorityValid(priority))
            {
                Items.Add(new ToDoItem { Title = title, IsCompleted = false, DueDate = dueDate, Priority = priority });
            }
            else
            {
                throw new ArgumentException("Invalid due date or priority.");
            }
        }

        public bool IsDueDateValid(DateTime dueDate)
        {
            return dueDate >= DateTime.Now.Date;
        }

        public bool IsPriorityValid(string priority)
        {
            var validPriorities = new[] { "High", "Medium", "Low" };
            return validPriorities.Contains(priority);
        }

        public void RemoveItem(ToDoItem item)
        {
            Items.Remove(item);
        }

        public void MarkItemAsCompleted(ToDoItem item)
        {
            var todoItem = Items.FirstOrDefault(i => i == item);
            if (todoItem != null)
            {
                todoItem.IsCompleted = true;
                OnPropertyChanged(nameof(Items));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
