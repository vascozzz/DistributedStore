using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace StoreService
{
    [DataContract]
    public class StoreOrder
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int book_id { get; set; }

        [DataMember]
        public int quantity { get; set; }

        [DataMember]
        public float total_price { get; set; }

        [DataMember]
        public string client_name { get; set; }

        [DataMember]
        public string client_address { get; set; }

        [DataMember]
        public string client_email { get; set; }

        [DataMember]
        public string state { get; set; }

        [DataMember]
        public int state_code { get; set; }

        [DataMember]
        public int origin { get; set; }
    }
}
