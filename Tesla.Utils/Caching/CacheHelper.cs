﻿/*******************************************************************************
 * Copyright © 2018 Tesla 版权所有
 * Author: Tony Stack


*********************************************************************************/
using System;
using System.Collections;
using System.Web;
using System.Web.Caching;


namespace Tesla.Utils
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper : ICacheHelper
    {
        private static Cache cache = HttpRuntime.Cache;

        /// <summary>
        /// 根据指定键值获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public T Get<T>(string cacheKey) where T : class
        {
            if (cache[cacheKey] != null)
            {
                return (T)cache[cacheKey];
            }
            return default(T);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        public void Set<T>(T value, string cacheKey) where T : class
        {
            cache.Insert(cacheKey, value, null, DateTime.Now.AddMinutes(10), Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="cacheKey"></param>
        /// <param name="expireTime"></param>
        public void Set<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            cache.Insert(cacheKey, value, null, expireTime, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 移除指定键值的缓存
        /// </summary>
        /// <param name="cacheKey"></param>
        public void Remove(string cacheKey)
        {
            cache.Remove(cacheKey);
        }

        /// <summary>
        /// 移除所有缓存
        /// </summary>
        public void RemoveAll()
        {
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }

        /// <summary>
        /// 获取或设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="acquire"></param>
        /// <returns></returns>
        public T GetOrSet<T>(string cacheKey, Func<T> acquire) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
