using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //SuccessDataResult'ı nasıl olumlu dönüşler için yazdıysak o yapının aynısının olumsuzu için de ErrorDataResult yazıyoruz.Tabi Trueları burda false çekiyoruz burası önemli !!!
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
