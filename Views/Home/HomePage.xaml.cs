using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;
using TODOApp.Database.ToDoItem;
using TODOApp.Models.ToDoItem;
using TODOApp.Services;
using TODOApp.Views.Home.Components;

namespace TODOApp.Views.Home;

public partial class HomePage : ContentPage
{
    private readonly TODOApiService _fakeApiService;
    public HomePage(TODOApiService fakeApiService)
    {
        InitializeComponent();
        _fakeApiService = fakeApiService;
    }

    public async void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
    {
        
        try
        {
            NavigationService.ClearData("Forms");
            await Shell.Current.GoToAsync("///Forms");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Erro ao navegar: {ex.Message}");
        }
    }

    public async void OnCheckItemLoaded(object sender, EventArgs e)
    {
        var checkItem = sender as CheckItem;
        if (checkItem != null)
        {
            ToDoItemDatabase database = await ToDoItemDatabase.instance;
            var items = await database.GetItemsAsync();

            checkItem.CheckItems.Clear();  
            foreach (var item in items)
            {
                checkItem.CheckItems.Add(item);
            }
        }

    }

    public async void OnClickGetApi(object sender, EventArgs e)
    {
        var items = await _fakeApiService.GetItemsAsync();
        checkItem.CheckItems.Clear();
        foreach (var item in items)
        {
            checkItem.CheckItems.Add(item);
        }
    }

    public async void OnClickGetError(object sender, EventArgs e)
    {
        try { 
            var items = await _fakeApiService.GetError();
        }
        catch(Exception ex)
        {
            await Toast.Make($"Erro: {ex.Message}").Show();
        }

    }

}

