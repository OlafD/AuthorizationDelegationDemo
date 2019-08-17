using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationDelegationDemo
{
    public class TokenCache
    {
        protected Hashtable _cache;

        /// <summary>
        /// Initialize a new token cache.
        /// </summary>
        public TokenCache()
        {
            _cache = new Hashtable();
        }

        /// <summary>
        /// Set an item in the token cache. If the key is already existing, the value will
        /// be updated, otherwise a new item will be added.
        /// </summary>
        /// <param name="key">object with the key</param>
        /// <param name="value">object with the value</param>
        public void SetItem(object key, object value)
        {
            if (_cache.ContainsKey(key) == true)
            {
                _cache[key] = value;
            }
            else
            {
                _cache.Add(key, value);
            }
        }

        /// <summary>
        /// Get an item from the token cache. When the key does not exist, null is returned.
        /// </summary>
        /// <param name="key">object with the key to look for</param>
        /// <returns></returns>
        public object GetItem(object key)
        {
            object result = null;

            if (_cache.ContainsKey(key) == true)
            {
                result = _cache[key];
            }

            return result;
        }
    }
}