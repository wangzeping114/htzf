using System;
using System.Security.Cryptography.X509Certificates;

namespace WS.HTZF.Core.HttpController
{
    public class ApiResult
    {
        public int StatusCode { get; set; } = 0;

        public string StatusMessage { get; set; } = "Success";

        public ApiResult()
        {

        }
        public ApiResult(int code, string msg) : this()
        {
            this.StatusCode = code;
            this.StatusMessage = msg;
        }

        public static ApiResult Success { get; } = new Lazy<ApiResult>(() => new ApiResult()).Value;

        public static ApiResult NotImplement { get; } = new Lazy<ApiResult>(() => new ApiResult(1000, "Not Implement")).Value;

        public static ApiResult NotFound { get; } = new Lazy<ApiResult>(() => new ApiResult(1001, "Not found")).Value;

        public static ApiResult RequestError { get; } = new Lazy<ApiResult>(() => new ApiResult(1002, "请求错误")).Value;

        public static ApiResult ServerError { get; } = new Lazy<ApiResult>(() => new ApiResult(1003, "内部请求错误")).Value;

        public static ApiResult GetNotFound(string msg = "")
        {
            return new ApiResult(1001, $"不能找到{msg}");
        }

        public static ApiResult GetNotImplement(string msg = "")
        {
            return  new ApiResult(1000,$"没有实现:{msg}");
        }

        public static ApiResult GetRequsetError(string msg = "")
        {
            return new ApiResult(1002, $"请求错误:{msg}");
        }

        public static ApiResult GetServerError(string msg)
        {
            return new ApiResult(1003, $"内部错误{msg}");
        }

        public static ApiResult GetAppTokenError(string msg = "无效的App-Token")
        {
            return new ApiResult(1004, $"App-Token错误:{msg}");
        }
        public static ApiResult GetArgumentError(string msg)
        {
            return new ApiResult(1005, $"参数错误:{msg}");
        }
    }
    public class ApiResult<T> : ApiResult
    {
        public ApiResult()
        {

        }
        public T Result { get; set; }
        public ApiResult(T result)
        {
            Result = result;
        }
    }
}
