using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace StoreService
{
    [DataContract]
    public class StoreRequest
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int book_id { get; set; }

        [DataMember]
        public int quantity { get; set; }

        [DataMember]
        public int fulfilled { get; set; }
    }
}
