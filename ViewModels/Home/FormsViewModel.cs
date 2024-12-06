using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TODOApp.Database.ToDoItem;
using TODOApp.Models.ToDoItem;
using TODOApp.Services;

namespace TODOApp.ViewModels.Home
{
    public class FormsViewModel : INotifyPropertyChanged
    {
        private ToDoItemModel _toDoItem;
        private string _title;

        public FormsViewModel()
        {
            var context = NavigationService.GetData<ToDoItemModel>("Forms");
            ToDoItem = context ?? new ToDoItemModel();
            UpdateTitle(); 

            SaveCommand = new Command(OnSaveOrEdit);
            BackCommand = new Command(BackCommandFunction);
        }

        public void Initialize(ToDoItemModel data)
        {
            ToDoItem = data ?? new ToDoItemModel();
        }


        public ToDoItemModel ToDoItem
        {
            get => _toDoItem;
            set
            {
                if (_toDoItem != value)
                {
                    _toDoItem = value;
                    OnPropertyChanged();
                    UpdateTitle();
                }
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand BackCommand { get; }

        private async void OnSaveOrEdit()
        {
            if (ToDoItem != null)
            {
                ToDoItem.Done = false;

                ToDoItemDatabase db = await ToDoItemDatabase.instance;

                await db.SaveItemAsync(ToDoItem);
                try
                {
                    await Shell.Current.GoToAsync("///HomePage");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Erro ao navegar: {ex.Message}");
                }
            }
        }

        private async void BackCommandFunction()
        {
            try
            {
                await Shell.Current.GoToAsync("///HomePage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Erro ao navegar: {ex.Message}");
            }
    
        }

        private void UpdateTitle()
        {
            Title = ToDoItem.Id != 0 ? "Editar" : "Cadastrar";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
