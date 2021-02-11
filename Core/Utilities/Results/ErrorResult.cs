using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
   public class ErrorResult:Result
    {
        //SuccessResultta yaptığımız olumlu geri dönüşün,olumusuz halidir!!!!! Messagelı ve messagesiz ErrorResult'un açıklamaları da yine SuccessResult'un açıklamaları gibidir.
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
