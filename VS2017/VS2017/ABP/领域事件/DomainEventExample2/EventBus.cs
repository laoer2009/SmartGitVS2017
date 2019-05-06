using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEventExample2
{
    //https://www.cnblogs.com/tiancai/p/7266858.html
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus
    {
        /// <summary>
        /// 事件总线对象
        /// </summary>
        private static EventBus _eventBus = null;

        /// <summary>
        /// 领域模型事件句柄字典，用于存储领域模型的句柄
        /// </summary>
        private static Dictionary<Type, List<object>> _dicEventHandler = new Dictionary<Type, List<object>>();

        /// <summary>
        /// 附加领域模型处理句柄时，锁住
        /// </summary>
        private readonly object _syncObject = new object();

        /// <summary>
        /// 单例事件总线
        /// </summary>
        public static EventBus Instance
        {
            get
            {
                return _eventBus ?? (_eventBus = new EventBus());
            }
        }

        private readonly Func<object, object, bool> _eventHandlerEquals = (o1, o2) =>
        {
            return true;
        };

        #region 订阅事件
        /// <summary>
        ///  订阅事件列表
        /// </summary>
        /// <typeparam name="TEvent">实现了IEvent的领域对象<，为了实现某个业务，而创建的实体类，它里面有事件所需要的数据/typeparam>
        /// <param name="eventHandler">某个领域对象的事件：它是一个事件处理类，它实现了IEventHandler，它所处理的事情需要在Handle里去完成</param>
        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            //同步锁
            lock (_syncObject)
            {
                //获取领域模型的类型
                var eventType = typeof(TEvent);
                //如果此领域类型在事件总线中已注册过
                if (_dicEventHandler.ContainsKey(eventType))
                {
                    var handlers = _dicEventHandler[eventType];
                    if (handlers != null)
                    {
                        handlers.Add(eventHandler);
                    }
                    else
                    {
                        handlers = new List<object>
                        {
                            eventHandler
                        };
                    }
                }
                else
                {
                    _dicEventHandler.Add(eventType, new List<object> { eventHandler });
                }
            }
        }

        #endregion

        #region 宣布事件

        public void Publish<TEvent>(TEvent tEvent, Action<TEvent, bool, Exception> callback=null) where TEvent : IEvent
        {
            var eventType = typeof(TEvent);
            if (_dicEventHandler.ContainsKey(eventType) && _dicEventHandler[eventType] != null &&
                _dicEventHandler[eventType].Count > 0)
            {
                var handlers = _dicEventHandler[eventType];
                try
                {
                    foreach (var handler in handlers)
                    {
                        var eventHandler = handler as IEventHandler<TEvent>;
                        eventHandler.Handle(tEvent);
                        if(callback!=null)
                        {
                            callback(tEvent, true, null);
                        }
                    
                    }
                }
                catch (Exception ex)
                {
                    callback(tEvent, false, ex);
                }
            }
            else
            {
                callback(tEvent, false, null);
            }
        }

        #endregion

    }
}
