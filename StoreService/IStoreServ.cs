using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;

namespace StoreService
{
    [ServiceContract]
    public interface IStoreServ
    {
        [OperationContract]
        DataTable GetBooks();
    }
}
