using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
    public class Result : IResult
    {
        //Soyut olan IResult ı somutlastırdığımız yer.
        public Result(bool success, string message):this(success)//redonlyler constructor için de set edilebilir. :this(success) yapmamızın sebebi 16.satırında çalısmasını sağlamak için.Yani alttaki resultı tetiklemek.
          //this yapısı=this burada result a karsılık gelir.içine yazdığımız (success) ie bizi tek parametreli Result a da gönder diyoruz.Peki hangi şartta ? sadece success parametresi varsa.
        {
            Message = message;
        }
        public Result(bool success)//redonlyler constructor için de set edilebilir.
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
