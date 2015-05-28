using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;
using System.ComponentModel;

namespace StoreService
{
    [ServiceContract]
    public interface IStoreServ
    {
        [OperationContract]
        List<StoreBook> GetBooks();

        [OperationContract]
        int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin);

        [OperationContract]
        bool AddBookQuantity(int bookId, int quantity);

        [OperationContract]
        StoreOrder GetOrder(string clientEmail, int orderId);

        [OperationContract]
        int addRequest(int bookId, int quantity);

        [OperationContract]
        List<StoreRequest> GetRequests();

        [OperationContract]
        bool FulfillRequest(int requestId);

        [OperationContract]
        bool DeleteRequest(int requestId);
    }
}
