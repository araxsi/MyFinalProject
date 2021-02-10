using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class ErrorResult:Result
    {
        public ErrorResult(string mesage) : base(false, mesage)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
