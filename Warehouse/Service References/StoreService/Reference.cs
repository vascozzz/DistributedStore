﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Warehouse.StoreService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StoreRequest", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
    [System.SerializableAttribute()]
    public partial class StoreRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int book_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int fulfilledField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int book_id {
            get {
                return this.book_idField;
            }
            set {
                if ((this.book_idField.Equals(value) != true)) {
                    this.book_idField = value;
                    this.RaisePropertyChanged("book_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int fulfilled {
            get {
                return this.fulfilledField;
            }
            set {
                if ((this.fulfilledField.Equals(value) != true)) {
                    this.fulfilledField = value;
                    this.RaisePropertyChanged("fulfilled");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantity {
            get {
                return this.quantityField;
            }
            set {
                if ((this.quantityField.Equals(value) != true)) {
                    this.quantityField = value;
                    this.RaisePropertyChanged("quantity");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StoreService.IStoreServ")]
    public interface IStoreServ {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetBooks", ReplyAction="http://tempuri.org/IStoreServ/GetBooksResponse")]
        System.Data.DataTable GetBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetBooks", ReplyAction="http://tempuri.org/IStoreServ/GetBooksResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddOrder", ReplyAction="http://tempuri.org/IStoreServ/AddOrderResponse")]
        int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddOrder", ReplyAction="http://tempuri.org/IStoreServ/AddOrderResponse")]
        System.Threading.Tasks.Task<int> AddOrderAsync(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddBookQuantity", ReplyAction="http://tempuri.org/IStoreServ/AddBookQuantityResponse")]
        bool AddBookQuantity(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddBookQuantity", ReplyAction="http://tempuri.org/IStoreServ/AddBookQuantityResponse")]
        System.Threading.Tasks.Task<bool> AddBookQuantityAsync(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/CheckOrder", ReplyAction="http://tempuri.org/IStoreServ/CheckOrderResponse")]
        System.Data.DataTable CheckOrder(string clientEmail, int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/CheckOrder", ReplyAction="http://tempuri.org/IStoreServ/CheckOrderResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> CheckOrderAsync(string clientEmail, int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/addRequest", ReplyAction="http://tempuri.org/IStoreServ/addRequestResponse")]
        int addRequest(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/addRequest", ReplyAction="http://tempuri.org/IStoreServ/addRequestResponse")]
        System.Threading.Tasks.Task<int> addRequestAsync(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetRequests", ReplyAction="http://tempuri.org/IStoreServ/GetRequestsResponse")]
        Warehouse.StoreService.StoreRequest[] GetRequests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetRequests", ReplyAction="http://tempuri.org/IStoreServ/GetRequestsResponse")]
        System.Threading.Tasks.Task<Warehouse.StoreService.StoreRequest[]> GetRequestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/FulfillRequest", ReplyAction="http://tempuri.org/IStoreServ/FulfillRequestResponse")]
        bool FulfillRequest(int requestId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/FulfillRequest", ReplyAction="http://tempuri.org/IStoreServ/FulfillRequestResponse")]
        System.Threading.Tasks.Task<bool> FulfillRequestAsync(int requestId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/DeleteRequest", ReplyAction="http://tempuri.org/IStoreServ/DeleteRequestResponse")]
        bool DeleteRequest(int requestId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/DeleteRequest", ReplyAction="http://tempuri.org/IStoreServ/DeleteRequestResponse")]
        System.Threading.Tasks.Task<bool> DeleteRequestAsync(int requestId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStoreServChannel : Warehouse.StoreService.IStoreServ, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StoreServClient : System.ServiceModel.ClientBase<Warehouse.StoreService.IStoreServ>, Warehouse.StoreService.IStoreServ {
        
        public StoreServClient() {
        }
        
        public StoreServClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StoreServClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetBooks() {
            return base.Channel.GetBooks();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetBooksAsync() {
            return base.Channel.GetBooksAsync();
        }
        
        public int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin) {
            return base.Channel.AddOrder(bookId, quantity, clientName, clientAddress, clientEmail, origin);
        }
        
        public System.Threading.Tasks.Task<int> AddOrderAsync(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin) {
            return base.Channel.AddOrderAsync(bookId, quantity, clientName, clientAddress, clientEmail, origin);
        }
        
        public bool AddBookQuantity(int bookId, int quantity) {
            return base.Channel.AddBookQuantity(bookId, quantity);
        }
        
        public System.Threading.Tasks.Task<bool> AddBookQuantityAsync(int bookId, int quantity) {
            return base.Channel.AddBookQuantityAsync(bookId, quantity);
        }
        
        public System.Data.DataTable CheckOrder(string clientEmail, int orderId) {
            return base.Channel.CheckOrder(clientEmail, orderId);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> CheckOrderAsync(string clientEmail, int orderId) {
            return base.Channel.CheckOrderAsync(clientEmail, orderId);
        }
        
        public int addRequest(int bookId, int quantity) {
            return base.Channel.addRequest(bookId, quantity);
        }
        
        public System.Threading.Tasks.Task<int> addRequestAsync(int bookId, int quantity) {
            return base.Channel.addRequestAsync(bookId, quantity);
        }
        
        public Warehouse.StoreService.StoreRequest[] GetRequests() {
            return base.Channel.GetRequests();
        }
        
        public System.Threading.Tasks.Task<Warehouse.StoreService.StoreRequest[]> GetRequestsAsync() {
            return base.Channel.GetRequestsAsync();
        }
        
        public bool FulfillRequest(int requestId) {
            return base.Channel.FulfillRequest(requestId);
        }
        
        public System.Threading.Tasks.Task<bool> FulfillRequestAsync(int requestId) {
            return base.Channel.FulfillRequestAsync(requestId);
        }
        
        public bool DeleteRequest(int requestId) {
            return base.Channel.DeleteRequest(requestId);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteRequestAsync(int requestId) {
            return base.Channel.DeleteRequestAsync(requestId);
        }
    }
}