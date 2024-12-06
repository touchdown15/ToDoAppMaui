using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOApp.Utils
{
    public class Util
    {
        public static bool IsNullOrDefault<T>(T obj)
        {
            return obj == null || EqualityComparer<T>.Default.Equals(obj, default(T));
        }
    }
}
