using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

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
        string selectedCharacter = CharacterSelectComboBox?.SelectionBoxItem?.ToString() ?? "Nie wybrano postaci";
        string taskDescription = TaskNameTextBox?.Text ?? "Brak opisu";
        string priority = LowPriorityRadioButton.IsChecked == true ? "Niski priorytet" :
            MidPriorityRadioButton.IsChecked == true ? "Normalny priorytet" :
            HighPriorityRadioButton.IsChecked == true ? "Wysoki priorytet" :
            "Bez priorytetu";

        var infoList = new List<string>();

        if (OutdoorsTask.IsChecked == true) infoList.Add("Zadanie na dworzu");
        if (RequiredToolsTask.IsChecked == true) infoList.Add("Zadanie wymagające sprzętu");
        if (TeamTask.IsChecked == true) infoList.Add("Zadanie drużynowe");

        var additionalInfo = string.Join(", ", infoList);

        var text = $"{selectedCharacter} - {taskDescription} [{priority}]. Dodatkowe Info: {additionalInfo}"; // add error message for empty fields?
        _taskItems.Add(text);
    }

    private void DeleteTasksButton_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var itemsToRemove = TaskListBox?.SelectedItems?.Cast<string>().ToList();
            foreach (var item in itemsToRemove)
            {
                _taskItems.Remove(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        
    }

    private void CharacterSelectComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var selectedCharacter = CharacterSelectComboBox?.SelectionBoxItem?.ToString();
        CharacterShowTextBlock.Text = selectedCharacter;
        switch (selectedCharacter)
        {
            case "Bolek":
            {
                try
                {
                    using var stream = AssetLoader.Open(new Uri("avares://ListaZadanBolkaILolka/Images/Bolek.jpg"));
                    CharacterShowImage.Source = new Bitmap(stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            }
            case "Lolek":
            {
                try
                {
                    using var stream = AssetLoader.Open(new Uri("avares://ListaZadanBolkaILolka/Images/Lolek.jpg"));
                    CharacterShowImage.Source = new Bitmap(stream);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            }
        }
    }
}