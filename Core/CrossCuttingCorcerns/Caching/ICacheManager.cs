using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingCorcerns.Caching
{
   public interface ICacheManager
    {
        T Get<T>(string key);// T tipinde bir Get yazıyoruz ve içine hangi tiple çalıştığımızı yazıyoruz.string tipinde verdiğimiz key e bellekte karışık gelen datayı getiriyoruz yani.
        object Get(string key);// üstteki gibi generic yapmak istemezsek böyle de yazabiliriz.Bunlar tamamanen işimize yarayana göre değişir.
        void Add(string key, object value,int duration); //Cache'e ekleme işlemi.string bir key herşey olabilecek bir object value ve cache de durma süresi de duration.
        bool IsAdd(string key);//Cache var olup olmadığını kontrol ediyoruz.Varsa ordan getirmesi yoksa belleğe kaydetmesi için.
        void Remove(string key);//Cache den ıuçurmak kaldırmak için kullanıyoruz.
        void RemoveByPattern(string pattern);//Burada Pattern yapmamızın sebebi örneğin isminde Get olanları uçur veya isminde Product olanları komple uçur demek için.
    }
}
