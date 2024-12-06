using TODOApp.Database.ToDoItem;
using TODOApp.Models.ToDoItem;

namespace TODOApp.Views.Home;

public partial class Forms : ContentPage
{
	public Forms()
	{
		InitializeComponent();
    }

    public async void OnSaveOrEdit(object sender, EventArgs e)
    {

        if (BindingContext is ToDoItemModel viewModel)
        {
            var todo = (ToDoItemModel)BindingContext;
            todo.Done = false;
            ToDoItemDatabase db = await ToDoItemDatabase.instance;
            await db.SaveItemAsync(todo);
            await Navigation.PopAsync();
        }
    }
}