using System;
using System.Collections.Generic;
using System.Text;

namespace Result
{
    public class ResultBase
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailed => !IsSuccess;
        public Exception Exception { get; protected set; }

        public bool HasSuccessMessage => !string.IsNullOrEmpty(SuccessMessage);
        public string SuccessMessage { get; protected set; }
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public string ErrorMessage { get; protected set; }
        public bool HasException => Exception != null;
    }
}
