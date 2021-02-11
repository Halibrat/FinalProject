using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
   public interface IResult //Teemel voidler için başlangic.Voidleri IResult yapısıyla süsleyeceğiz.
    {
        bool Success { get; } // get sasdece okunabilir !!! Sonucun başarılı olması veya başarısız olması.
        string Message { get; } // //Başarılı sonucun bilgilendirilmesi.Veya başarısz sonucun biligilendirilmesi.
    }
}
