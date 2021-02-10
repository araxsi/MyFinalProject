using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(string mesage) : base(true, mesage)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }    

}
