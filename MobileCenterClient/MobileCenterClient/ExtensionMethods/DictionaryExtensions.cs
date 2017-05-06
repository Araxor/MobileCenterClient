using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileCenterClient.ExtensionMethods
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, Func<TValue> createValueTask)
        {
            if (!dict.ContainsKey(key)) 
                dict[key] = createValueTask();

            return dict[key];
        }
    }
}
