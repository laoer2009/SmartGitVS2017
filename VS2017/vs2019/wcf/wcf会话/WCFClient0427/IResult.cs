using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient0427
{
    public interface IResult
    {
        /// <summary>
        /// 结果标识；
        /// 在之前的使用中，为了方便只是定义了一个 Success，觉得在使用中不是很方便；
        /// 由于功能需求较多，为了能够更快的定位某些错误或者其它问题，还是使用 Code；
        /// 这里在加两个个默认值 0 success；1 error
        /// </summary>
        int Code { get; }

        /// <summary>
        /// 返回信息，成功与否都可能有消息返回
        /// </summary>
        string Msg { get; }
    }

    /// <summary>
    /// 通用结果返回，带泛型数据；详细说明请查阅 https://www.tapd.cn/20699141/markdown_wikis/#1120699141001000159
    /// </summary>
    public interface IResult<T>
        : IResult
    {
        /// <summary>
        /// 泛型数据，默认为 defaul(T)
        /// </summary>
        T Data { get; }
    }
}
