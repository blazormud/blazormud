using System.Collections.Generic;

namespace BlazorMUD.Shared.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Adds a key/value pair to the <see cref="IDictionary{TKey,TValue}"/> if the key does not already exist,
        /// or updates a key/value pair in the <see cref="IDictionary{TKey,TValue}"/> if the key already exists.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="this">A dictionary with keys of type <c>TKey</c> and values of type <c>TValue</c>.</param>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="value">
        /// The value of the element to add or update. The value can be <c>null</c> for reference types.
        /// </param>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> @this, TKey key, TValue value)
        {
            if (@this.ContainsKey(key)) @this[key] = value;
            else @this.Add(key, value);
        }
    }
}
