using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ListaZadanBolkaILolka;

public partial class MainWindow : Window
{
    private ObservableCollection<string> _taskItems = new();
    
    public MainWindow()
    {
        InitializeComponent();
        TaskListBox.ItemsSource = _taskItems;
    }

    private void AddTaskButton_OnClick(object? sender, RoutedEventArgs e)
    {
        string selectedCharacter = CharacterSelectComboBox?.SelectionBoxItem?.ToString() ?? "";
        string taskDescription = TaskNameTextBox?.Text ?? "";
        string priority = LowPriorityRadioButton.IsChecked == true ? "Niski priorytet" :
            MidPriorityRadioButton.IsChecked == true ? "Normalny priorytet" :
            HighPriorityRadioButton.IsChecked == true ? "Wysoki priorytet" :
            "";
        
        var text = $"{selectedCharacter} - {taskDescription} [{priority}]"; // add error message for empty fields?
        _taskItems.Add(text);
    }

    private void DeleteTasksButton_OnClick(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void CharacterSelectComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}