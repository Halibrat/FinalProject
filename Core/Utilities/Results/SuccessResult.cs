using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
   public class SuccessResult:Result
    {
        
        public SuccessResult(string message) : base(true, message)
        {
            // :base yapmamızın sebei miras aldığımız yapıyla irtibat kurmak için.Success true ile beraber mesaj yollamak için bu metodu kullanacağız. 
        }
        public SuccessResult() : base(true)
        {
            //sadece Success true ile mesajsız çalışmak istedğimizde nu metodu kullanacağız.
        }
    }
}
