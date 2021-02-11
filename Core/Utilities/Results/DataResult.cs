using Core.Utilities.Resluts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //DataResult'a <T> diyerek tipini çalışırken söyleyeceğiz dedik. :Result ile aynı zamanda bir Resultsın dedik ve verdiğiniz <T> için de IDataResult implementasyonusun dedik.
        public DataResult(T data,bool success,string message):base(success,message) //T tipinde data verdik,işlem sonucu verdik ve mesaj verik. base e de success ve mesajında yollanmasını sağladık.
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success) //Mesajsız data döndürmek istiyorsak da kullandığımız yapı burası.Tıpkı Resultta olduğu gibi aslında burada sadece Datayı dahil etmek durumundayız. 
        {
            Data = data;
        }
        public T Data { get; } //IDataResultımızdan implemente ettik.
    }
}
