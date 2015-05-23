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

        [OperationContract]
        int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin);

        [OperationContract]
        bool AddBookQuantity(int bookId, int quantity);

        [OperationContract]
        DataTable CheckOrder(string clientEmail, int orderId);

        [OperationContract]
        DataTable GetRequests();

        [OperationContract]
        bool FulfillRequest(int requestId);

        [OperationContract]
        bool DeleteRequest(int requestId);
    }
}
