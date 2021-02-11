using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data,string message):base(data,true,message)//data ve mesaj yolladığımız yapı.Yani tüm bilgilerin olduğu
        {

        }
        public SuccessDataResult(T data):base(data,true)//data verip mesaj veröedğimiz yapı.
        {

        }
        public SuccessDataResult(string message):base(default,true,message)//data yı default haliyle verip mesaj yolladığımız yapı.(Default çok tercih edilmemektedir.)
        {

        }
        public SuccessDataResult():base(default,true)//default u mesajsız yolladığımız yapı.(DEfault çok tercih edilmemktedir.)
        {

        }
    }
}
