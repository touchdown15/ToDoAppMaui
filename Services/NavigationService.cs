
namespace TODOApp.Services
{
    public class NavigationService
    {
        private static readonly Dictionary<string, object> NavigationData = new();
        public static void AddData(string key, object data) => NavigationData[key] = data;

        public static T GetData<T>(string key)
        {
            if (NavigationData.TryGetValue(key, out var data))
                return (T)data;
            return default; 
        }

        public static void ClearData(string key)
        {
            if (NavigationData.ContainsKey(key))
            {
                NavigationData.Remove(key); 
            }
        }

        // Método para limpar todos os dados
        public static void ClearAllData()
        {
            NavigationData.Clear();
        }
    }
}
