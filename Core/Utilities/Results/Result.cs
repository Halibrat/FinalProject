using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
    public class Result : IResult
    {
       

        public Result(bool success, string message):this(success)//redonlyler constructor için de set edilebilir. :this(success) yapmamızın sebebi 17.satırında çalısmasını sağlamak için.Yani alttaki resultı tetiklemek.
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
