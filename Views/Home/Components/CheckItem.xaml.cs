using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TODOApp.Database.ToDoItem;
using TODOApp.Models.ToDoItem;
using TODOApp.Services;


namespace TODOApp.Views.Home.Components;

public partial class CheckItem : ContentView
{
    public ObservableCollection<ToDoItemModel> CheckItems { get; set; }
    public CheckItem()
	{
        InitializeComponent();
        CheckItems = new ObservableCollection<ToDoItemModel>();
        BindingContext = this;
    }
    private async void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkBox = sender as CheckBox;
        if (checkBox != null)
        {
            var item = checkBox.BindingContext as ToDoItemModel;
            if (item != null)
            {
                ToDoItemDatabase db = await ToDoItemDatabase.instance;
                await db.SaveItemAsync(item);
            }
        }
    }

    private async void OnTapGestureRecognizerTappedDelete(object sender, TappedEventArgs args)
    {
        var label = sender as Label;
        if (label != null)
        {
            var item = label.BindingContext as ToDoItemModel;
            if (item != null)
            {
                bool confirm = await Application.Current.MainPage.DisplayAlert(
                    "Confirmar Exclusão",
                    "Você tem certeza que deseja excluir esta tarefa?",
                    "Sim",
                    "Não");
                if (confirm)
                {
                    ToDoItemDatabase db = await ToDoItemDatabase.instance;
                    await db.DeleteItemAsync(item);
                    LoadingNewItems(db);
                } 
            }
        }
    }

    private async void OnTapGestureRecognizerTappedEdit(object sender, TappedEventArgs args)
    {
        var label = sender as Label;
        NavigationService.ClearData("Forms");
        if (label != null)
        {
            var item = label.BindingContext as ToDoItemModel;
            if (item != null)
            {
                NavigationService.AddData("Forms", item);
                try
                {
                    await Shell.Current.GoToAsync("///Forms");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Erro ao navegar: {ex.Message}");
                }
            }
        }
        
    }

    private async void LoadingNewItems(ToDoItemDatabase db)
    {
        var items = await db.GetItemsAsync();

        CheckItems.Clear();
        foreach (var item in items)
        {
            CheckItems.Add(item);
        }
    }

}