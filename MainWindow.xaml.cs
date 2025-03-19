using System.Windows;
using System.Windows.Controls;
using ToDoTracker_Lab.Models;
using ToDoTracker_Lab.ViewModels;

namespace ToDoTracker_Lab;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void AddItemButton_Click(object sender, RoutedEventArgs e)
    {
        var viewModel = (ToDoViewModel)DataContext;
        var selectedPriority = (PriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
        try
        {
            viewModel.AddItem(NewItemTextBox.Text, DueDatePicker.SelectedDate ?? DateTime.Now, selectedPriority);
            NewItemTextBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityComboBox.SelectedIndex = -1;
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
    {
        var item = (sender as FrameworkElement).DataContext as ToDoItem;
        var viewModel = (ToDoViewModel)DataContext;
        viewModel.RemoveItem(item);
    }

    private void CompleteItemButton_Click(object sender, RoutedEventArgs e)
    {
        var item = (sender as FrameworkElement).DataContext as ToDoItem;
        var viewModel = (ToDoViewModel)DataContext;
        viewModel.MarkItemAsCompleted(item);
    }
}