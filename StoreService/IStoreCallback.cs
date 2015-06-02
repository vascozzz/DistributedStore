using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace StoreService
{
    interface IStoreCallback
    {
        [OperationContract]
        void OnAddRequest(int id, int book_id, int quantity);

        [OperationContract]
        void OnFulfillRequest(int id);

        [OperationContract]
        void OnUpdateBookQuantity(int bookId, int newQuantity);
    }
}
