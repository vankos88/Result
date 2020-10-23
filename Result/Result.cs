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
        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public string ErrorMessage { get; protected set; }
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

        #endregion

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
