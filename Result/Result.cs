using System;

namespace Result
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailed => !IsSuccess;
        public Exception Exception { get; protected set; }

        public bool HasSuccessMessage => !string.IsNullOrEmpty(SuccessMessage);
        public string SuccessMessage { get; protected set; }
        public bool HasFailMessage => !string.IsNullOrEmpty(FailMessage);
        public string FailMessage { get; protected set; }
        public bool HasException => Exception != null;

        #region Constructors

        public Result()
        {
        }

        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            if (isSuccess)
                SuccessMessage = message;
            else FailMessage = message;
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
            FailMessage = message;
        }

        #endregion

        public static implicit operator bool(Result result) => result.IsSuccess;

        public static Result Success() => new Result(true);

        public static Result Success(string message) => new Result(true, message);

        public static Result Fail() => new Result(false);

        public static Result Fail(string message) => new Result(false, message);

        public static Result Fail(Exception ex) => new Result(ex);

        public static Result Fail(Exception ex, string message) => new Result(ex, message);
    }
}
