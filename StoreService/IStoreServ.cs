using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace StoreService
{
    [ServiceContract]
    public interface IStoreServ
    {
        [OperationContract]
        float Add(float n1, float n2);

        [OperationContract]
        float Multiply(float n1, float n2);
    }
}
