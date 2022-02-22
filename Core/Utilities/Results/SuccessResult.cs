using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(List<string> message) : base(true, message)
        {

        }

        public SuccessResult():base(true)
        {

        }
    }
}
