using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    //Temel voidler için kullanılacaktır.
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
