using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace StoreService
{
    class StoreServ : IStoreServ
    {
        public DataTable GetBooks()
        {
            return DatabaseLayer.GetBooks();
        }
    }
}
