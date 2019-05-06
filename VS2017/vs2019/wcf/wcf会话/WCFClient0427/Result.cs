using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient0427
{
    public class Result : IResult
    {
        public int Code { get; set; }

        public string Msg { get; set; }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result Create(int code, string msg = null)
        {
            return new Result
            {
                Code = code,
                Msg = msg
            };
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result Create(bool success, string msg = null)
        {
            return new Result
            {
                Code = 0,
                Msg = msg
            };
        }

        /// <summary>
        /// 创建一个 Result<T>
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> Create<T>(int code, T data = default(T), string msg = null)
        {
            return new Result<T>
            {
                Code = code,
                Data = data,
                Msg = msg
            };
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result CreateError(string msg = null)
        {
            return new Result();
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result CreateError(int code, string msg = null)
        {
            return Create(code, msg);
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result CreateSuccess(string msg = null)
        {
            return new Result();
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result CreateSuccess(int code, string msg = null)
        {
            return Create(code, msg);
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> CreateError<T>(string msg = null)
        {
            return new Result<T>();
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> CreateError<T>(T data, string msg = null)
        {
            return new Result<T>();
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> CreateError<T>(int code, string msg = null)
        {
            return Create(code, default(T), msg);
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> CreateSuccess<T>(T data, string msg = null)
        {
            return new Result<T>();
        }

        /// <summary>
        /// 创建一个 Result
        /// </summary>
        /// <param name="code"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> CreateSuccess<T>(int code, T data, string msg = null)
        {
            return Create(code, data, msg);
        }

        public override string ToString()
        {

                return "success";

        }
    }

    /// <summary>
    /// IResult<T> 实现
    /// </summary>
    public class Result<T> : Result, IResult<T>
    {
        public T Data { get; set; }

        public override string ToString()
        {
            return "success";
        }
    }

}
