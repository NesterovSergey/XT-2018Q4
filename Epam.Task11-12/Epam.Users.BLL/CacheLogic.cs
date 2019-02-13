using System.Collections.Generic;
using Epam.Users.BLL.Interface;

namespace Epam.Users.BLL
{
    public class CacheLogic : ICacheLogic
    {
        private static Dictionary<string, object> data = new Dictionary<string, object>();

        public bool Add<T>(string key, T value)
        {
            if (data.ContainsKey(key))
            {
                return false;
            }

            data.Add(key, value);

            return true;
        }

        public T Get<T>(string key)
        {
            if (!data.ContainsKey(key))
            {
                return default(T);
            }

            return (T)data[key];
        }

        public bool Delete(string key)
        {
            return data.Remove(key);
        }
    }
}
