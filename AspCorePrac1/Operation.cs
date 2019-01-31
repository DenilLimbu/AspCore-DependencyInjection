using AspCorePrac1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePrac1
{
    public class Operation : IOperationTransient,
        IOperationScoped,
        IOperationSingleton,
        IOperationSingletonInstance
    {

        public Guid OperationId { get; private set; }

        public Operation() : this(Guid.NewGuid())
        {
            //defualt Constructor
        }

        public Operation(Guid id)
        {
            OperationId = id;
            //Paramerterized Constructor
        }

       
    }
}
