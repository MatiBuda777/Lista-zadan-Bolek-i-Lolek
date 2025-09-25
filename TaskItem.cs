using System;

namespace ListaZadanBolkaILolka;

public class TaskItem
{
    public string Text { get; set; }
    public DateTime Date { get; set; }

    public TaskItem(string text, DateTime date)
    {
        Text = text;
        Date = date;
    }
    public TaskItem(string text)
    {
        Text = text;
    }

    public override string ToString()
    {
        return Text;
    }
}