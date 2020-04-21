using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console006.CacheFunc
{
  class C1
  {
    public static void Execute(string[] args)
    {
      string key = "CacheTest";
      bool b1 = CacheHelper.IsKeyExists(key);
      Console.WriteLine("Key:[{0}] = [{1}]", key, b1);

      CacheHelper.Set(key, "abcd", 3);
      
      bool b2 = CacheHelper.IsKeyExists(key);
      Console.WriteLine("Key:[{0}] = [{1}]", key, b2);

      var cacheValue1 = CacheHelper.Get<string>(key);
      Console.WriteLine("cacheValue = [{0}]", cacheValue1 ?? "null");
      
      Thread.Sleep(5000);
      Console.WriteLine("After 5s...");

      bool b3 = CacheHelper.IsKeyExists(key);
      Console.WriteLine("Key:[{0}] = [{1}]", key, b3);

      var cacheValue2 = CacheHelper.Get<string>(key);
      Console.WriteLine("cacheValue = [{0}]", cacheValue2 ?? "null");

      Thread.Sleep(1000);
      CacheHelper.Set("CacheTest", "jacky", 3);
      var cacheValue3 = CacheHelper.Get<string>(key);
      Console.WriteLine("cacheValue = [{0}]", cacheValue3 ?? "null");
    }
  }

  static class CacheHelper
  {
    public static void Set(string key, object obj, int seconds = 7200)
    {
      var cache = MemoryCache.Default;

      var policy = new CacheItemPolicy
      {
        AbsoluteExpiration = DateTime.Now.AddSeconds(seconds)
      };

      cache.Set(key, obj, policy);
    }

    public static T Get<T>(string key) where T : class
    {
      var cache = MemoryCache.Default;

      try
      {
        return (T)cache[key];
      }
      catch (Exception)
      {
        return null;
      }
    }

    public static void Remove(string key)
    {
      MemoryCache.Default.Remove(key);
    }

    public static bool IsKeyExists(string key)
    {
      var cache = MemoryCache.Default;
      return cache.Contains(key);
    }
  }
}
