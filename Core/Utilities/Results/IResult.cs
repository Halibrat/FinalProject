using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Resluts
{
   public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
