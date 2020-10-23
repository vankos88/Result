using System;
using System.Collections.Generic;
using System.Text;

namespace Result
{
    public class Result<T> : Result
    {
        public T Data { get; set; }
        public bool HasData => Data != null;

        #region Constructors

        public Result(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;

            if (isSuccess)
                SuccessMessage = message;
            else FailMessage = message;

            Data = data;
        }

        public Result(bool isSuccess, T data)
        {
            IsSuccess = isSuccess;
            Data = data;
        }

        public Result(Exception ex) : base(ex)
        {
        }

        public Result(Exception ex, string message) : base(ex, message)
        {
        }

        public Result(bool isSuccess) : base(isSuccess)
        {
        }

        public Result(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public Result(Result result)
        {

        }


    #endregion

        public static Result<T> Success() => new Result<T>(true);

        public static Result<T> Success(T data) => new Result<T>(true, data);

        public static Result<T> Success(string message) => new Result<T>(true, message);

        public static Result<T> Success(string message, T data) => new Result<T>(true, message, data);

        public static Result<T> Fail(string message, T data) => new Result<T>(false, message, data);
    }
}
