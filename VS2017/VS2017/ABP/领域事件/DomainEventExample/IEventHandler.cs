using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEventExample
{

    /// <summary>
    /// 事件处理接口 事件处理程序  事件处理程序要与事件源进行绑定（https://www.jianshu.com/p/c10b7fd9bec1）
    /// 事件处理要与事件源进行绑定，所以我们再来定义一个泛型接口
    /// 领域对象的处理方法，行为：（需要让那些零散的模块重写的方法，起个听起来熟悉的名字，叫它handle吧）
    /// IEventHandler＝＞Handle
    /// </summary>
    /// <typeparam name="TEvent">继承IEvent对象的事件源对象</typeparam>
    public interface IEventHandler<TEvent> where TEvent:IEvent
    {
        /// <summary>
        /// 事件处理程序
        /// </summary>
        /// <param name="evt"></param>
        void Handle(TEvent evt);
    }
}
