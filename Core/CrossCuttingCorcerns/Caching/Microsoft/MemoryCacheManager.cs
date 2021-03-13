using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using System.Linq;

namespace Core.CrossCuttingCorcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter Pattern burada uyguladuğımız yapının adı.Sistemi kendimize göre adapte ediyoruz.
        IMemoryCache _memoryCache;
        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();//Burada CoreModule de yazdığımız serviceCollection.AddMemoryCache(); yapısının karşılığını bana ver diyoruz.
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));//Set ile Cacahe'e değer ekliyoruz.TimeSpan.FromMunite bellekten ne zaman uçuracağının zamanını verdiğimiz yapı.
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key); //T türünde key e göre bize Get işlemi yap.
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);//key e göre bize Get işlemi yap.
        }

        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key,out _);//Bellekte böyle bir cache olup olmadığına bakıyor.key i veriyoruz ama yanına ki paramaetre bize döndüredebilirim diye naskı yapıyor.Bi< döndürme işlemi yapmak istemedimiz için out keywrodunu kullandık. out _ yapısı c# da kullanılan bir yönlendirme yapısı.
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);//Bellekten uçurma işlemi.
        }

        public void RemoveByPattern(string pattern)//Çalışma anında bellekten silmeye yarıyor.Bunu da reflection ile yapabildiğimizi zaten öğrenmiştik.
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);//Bellekte MemoryCache türünde olan EntriesColection(cache datalarının tutulduğu yer) ı bul.
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic; //Definition ı _memoryCache olanları bul.
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)//herbir cache elemanını geziyoruz.
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);//Gezilen her bir cache elamanında bu kurala uyanlar.
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();//Kuralana uyanlar verdiğimiz değer uygunsa listeleniyor.

            foreach (var key in keysToRemove)//keyleri uyanları bulup remove ediyoruz.
            {
                _memoryCache.Remove(key);
            }
        }

       
    }
}
