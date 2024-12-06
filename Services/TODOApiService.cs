using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOApp.Models.ToDoItem;

namespace TODOApp.Services
{
    public class TODOApiService
    {
        private readonly List<ToDoItemModel> _mock = new()
        {
            new ToDoItemModel { Id = 1, Name = "TestAPI", Description = "Testando123" },
            new ToDoItemModel { Id = 2, Name = "TestAPI 2", Description = "OutroTest" },
        };

        public Task<List<ToDoItemModel>> GetItemsAsync()
        {
            return Task.FromResult(_mock);
        }

        public Task<List<ToDoItemModel>> GetError()
        {
            if (true)
            {
                throw new Exception("Erro ao obter itens do servidor.");
            }
        }

    }
}
