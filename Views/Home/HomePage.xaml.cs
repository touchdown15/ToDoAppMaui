using System.Collections.ObjectModel;
using TODOApp.Database.ToDoItem;
using TODOApp.Models.ToDoItem;
using TODOApp.Views.Home.Components;

namespace TODOApp.Views.Home;

public partial class HomePage : ContentPage
{

    public HomePage()
    {
        InitializeComponent();
    }

    public void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        Navigation.PushAsync(new Forms
        {
            BindingContext = new ToDoItemModel()
        });
    }

    public async void OnCheckItemLoaded(object sender, EventArgs e)
    {
        var checkItem = sender as CheckItem;
        if (checkItem != null)
        {
            ToDoItemDatabase database = await ToDoItemDatabase.instance;
            var items = await database.GetItemsAsync();

            // Atualizando a propriedade CheckItems diretamente
            checkItem.CheckItems.Clear();  // Limpa a coleção antes de adicionar os novos itens
            foreach (var item in items)
            {
                checkItem.CheckItems.Add(item);
            }
        }

    }

}

