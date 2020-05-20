using System;
using System.Collections.Generic;
using System.IO;
using System.Net.WebSockets;
using System.Text;

namespace Result
{
    public class Result : ResultBase
    {
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            if (isSuccess)
                SuccessMessage = message;
            else ErrorMessage = message;
        }
        public Result(Exception ex)
        {
            IsSuccess = false;
            Exception = ex;
        }

        public Result(Exception ex, string message)
        {
            IsSuccess = false;
            Exception = ex;
            ErrorMessage = message;
        }

        public static implicit operator bool(Result result)
        {
            return result.IsSuccess;
        }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Success(string message)
        {
            return new Result(true, message);
        }

        public static Result Error()
        {
            return new Result(false);
        }

        public static Result Error(string message)
        {
            return new Result(false, message);
        }

        public static Result Error(Exception ex)
        {
            return new Result(ex);
        }

        public static Result Error(Exception ex, string message)
        {
            return new Result(ex, message);
        }
    }
}
