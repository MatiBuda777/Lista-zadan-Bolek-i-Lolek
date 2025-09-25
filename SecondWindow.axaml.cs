using System;
using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ListaZadanBolkaILolka;

public partial class SecondWindow : Window
{
    private ObservableCollection<string> _taskItems = new();

    public ObservableCollection<string> TaskItems
    {
        get => _taskItems;
        set => _taskItems = value ?? throw new ArgumentNullException(nameof(value));
    }

    public SecondWindow()
    {
        InitializeComponent();
        TodayTaskListBox.ItemsSource = _taskItems;
    }
}