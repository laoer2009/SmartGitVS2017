using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEventExample2
{
    //领域模型对象：为了实现某个业务，而创建的实体类，它里面有事件所需要的数据，它继承了IEvent
    /// <summary>
    ///  事件源
    /// 某个领域对象：为了实现某个业务，而创建的实体类，它里面有事件所需要的数据，它继承了IEvent
    /// </summary>
    public class UserGenerator:IEvent
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Guid UserId { get; set; }
    }
}
