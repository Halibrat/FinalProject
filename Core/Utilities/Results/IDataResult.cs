using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
    //IResult yapımız void işlemlerimiz için geçerli olduğu için Datalarımızı da döndüren generic bir yapıya ihtiyacımız vardır.Bunun için IDataResult interface ini olusturmaktayız.
    //Burada IDataResult'ı IResulttan kalıtmamızın sebebi, IResultta yaptığımız True veya False,Mesajlı veya Mesajsız dönen yapıları tekrar yazmayıp direkt IResult dan kullanmak istememizdir.
   public interface IDataResult<T>:IResult
    {
        T Data { get; } //IResulttan gelen ture veya false ve mesajla beraber birde data gelebilmesi için yazdık.
    }
}
