using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApp.StoreService;
using System.ServiceModel;

namespace StoreApp
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    class StoreServCallback : IStoreServCallback
    {
        private Main form;

        public StoreServCallback(Main form)
        {
            this.form = form;
        }

        public void OnAddRequest(int id, int book_id, int quantity)
        {
            form.AddRequest(new StoreRequest { id = id, book_id = book_id, quantity = quantity, fulfilled = 0});
        }

        public void OnFulfillRequest(int id)
        {
            form.FulfillRequest(id);
        }

        public void OnUpdateBookQuantity(int bookId, int newQuantity)
        {
            form.UpdateBookQuantity(bookId, newQuantity);
        }
    }
}
