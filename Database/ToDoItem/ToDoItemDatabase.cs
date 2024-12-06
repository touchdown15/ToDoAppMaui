using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOApp.Database.Config;
using TODOApp.Models.ToDoItem;

namespace TODOApp.Database.ToDoItem
{
    public class ToDoItemDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<ToDoItemDatabase> instance =
            new AsyncLazy<ToDoItemDatabase>(async () =>
            {
                var instance = new ToDoItemDatabase();
                try
                {
                    CreateTableResult result = await Database.CreateTableAsync<ToDoItemModel>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return instance;
            });

        public ToDoItemDatabase()
        {
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        }

        public Task<List<ToDoItemModel>> GetItemsAsync()
        {
            return Database.Table<ToDoItemModel>().ToListAsync();
        }

        public Task<List<ToDoItemModel>> GetItemNotDoneAsync()
        {
            return Database.QueryAsync<ToDoItemModel>("SELECT *  FROM [ToDoItemModel] WHERE [Done] = 0");
        }

        public Task<ToDoItemModel> GetItemAsync(int id)
        {
            return Database.Table<ToDoItemModel>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(ToDoItemModel item)
        {
            if(item.Id != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task DeleteItemAsync(ToDoItemModel item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
