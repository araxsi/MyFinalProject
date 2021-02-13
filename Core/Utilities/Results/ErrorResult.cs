using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
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
