using System;
using System.Collections.Generic;
using System.Text;

namespace netcoretest1
{
    public class Operation : IOperationSingleton, IOperationTransient, IOperationScope
    {
        private Guid _guid;
        public Operation()
        {
            _guid = Guid.NewGuid();
        }
        public Operation(Guid guid)
        {
            _guid = guid;
        }
        public Guid OperationId
        {
            get { return _guid; }
        }

    }
}
