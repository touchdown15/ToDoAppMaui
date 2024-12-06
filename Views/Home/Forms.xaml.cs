using TODOApp.Models.ToDoItem;
using TODOApp.Services;
using TODOApp.ViewModels.Home;

namespace TODOApp.Views.Home;

public partial class Forms : ContentPage
{
    private readonly FormsViewModel _viewModel;
    public Forms()
    {
        InitializeComponent();
        _viewModel = new FormsViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        var data = NavigationService.GetData<ToDoItemModel>("Forms");
        _viewModel.Initialize(data);
    }

}