﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreApp.StoreService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StoreBook", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
    [System.SerializableAttribute()]
    public partial class StoreBook : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float priceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string titleField;
        
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
        public float price {
            get {
                return this.priceField;
            }
            set {
                if ((this.priceField.Equals(value) != true)) {
                    this.priceField = value;
                    this.RaisePropertyChanged("price");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string title {
            get {
                return this.titleField;
            }
            set {
                if ((object.ReferenceEquals(this.titleField, value) != true)) {
                    this.titleField = value;
                    this.RaisePropertyChanged("title");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StoreOrder", Namespace="http://schemas.datacontract.org/2004/07/StoreService")]
    [System.SerializableAttribute()]
    public partial class StoreOrder : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int book_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string client_addressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string client_emailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string client_nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int originField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int quantityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string stateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int state_codeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float total_priceField;
        
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
        public string client_address {
            get {
                return this.client_addressField;
            }
            set {
                if ((object.ReferenceEquals(this.client_addressField, value) != true)) {
                    this.client_addressField = value;
                    this.RaisePropertyChanged("client_address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string client_email {
            get {
                return this.client_emailField;
            }
            set {
                if ((object.ReferenceEquals(this.client_emailField, value) != true)) {
                    this.client_emailField = value;
                    this.RaisePropertyChanged("client_email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string client_name {
            get {
                return this.client_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.client_nameField, value) != true)) {
                    this.client_nameField = value;
                    this.RaisePropertyChanged("client_name");
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
        public int origin {
            get {
                return this.originField;
            }
            set {
                if ((this.originField.Equals(value) != true)) {
                    this.originField = value;
                    this.RaisePropertyChanged("origin");
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string state {
            get {
                return this.stateField;
            }
            set {
                if ((object.ReferenceEquals(this.stateField, value) != true)) {
                    this.stateField = value;
                    this.RaisePropertyChanged("state");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int state_code {
            get {
                return this.state_codeField;
            }
            set {
                if ((this.state_codeField.Equals(value) != true)) {
                    this.state_codeField = value;
                    this.RaisePropertyChanged("state_code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float total_price {
            get {
                return this.total_priceField;
            }
            set {
                if ((this.total_priceField.Equals(value) != true)) {
                    this.total_priceField = value;
                    this.RaisePropertyChanged("total_price");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StoreService.IStoreServ", CallbackContract=typeof(StoreApp.StoreService.IStoreServCallback))]
    public interface IStoreServ {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/Subscribe", ReplyAction="http://tempuri.org/IStoreServ/SubscribeResponse")]
        System.Guid Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/Subscribe", ReplyAction="http://tempuri.org/IStoreServ/SubscribeResponse")]
        System.Threading.Tasks.Task<System.Guid> SubscribeAsync();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStoreServ/Unsubscribe")]
        void Unsubscribe(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IStoreServ/Unsubscribe")]
        System.Threading.Tasks.Task UnsubscribeAsync(System.Guid clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetBooks", ReplyAction="http://tempuri.org/IStoreServ/GetBooksResponse")]
        StoreApp.StoreService.StoreBook[] GetBooks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetBooks", ReplyAction="http://tempuri.org/IStoreServ/GetBooksResponse")]
        System.Threading.Tasks.Task<StoreApp.StoreService.StoreBook[]> GetBooksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddOrder", ReplyAction="http://tempuri.org/IStoreServ/AddOrderResponse")]
        int AddOrder(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddOrder", ReplyAction="http://tempuri.org/IStoreServ/AddOrderResponse")]
        System.Threading.Tasks.Task<int> AddOrderAsync(int bookId, int quantity, string clientName, string clientAddress, string clientEmail, int origin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddBookQuantity", ReplyAction="http://tempuri.org/IStoreServ/AddBookQuantityResponse")]
        bool AddBookQuantity(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/AddBookQuantity", ReplyAction="http://tempuri.org/IStoreServ/AddBookQuantityResponse")]
        System.Threading.Tasks.Task<bool> AddBookQuantityAsync(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetOrder", ReplyAction="http://tempuri.org/IStoreServ/GetOrderResponse")]
        StoreApp.StoreService.StoreOrder GetOrder(string clientEmail, int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetOrder", ReplyAction="http://tempuri.org/IStoreServ/GetOrderResponse")]
        System.Threading.Tasks.Task<StoreApp.StoreService.StoreOrder> GetOrderAsync(string clientEmail, int orderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/addRequest", ReplyAction="http://tempuri.org/IStoreServ/addRequestResponse")]
        int addRequest(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/addRequest", ReplyAction="http://tempuri.org/IStoreServ/addRequestResponse")]
        System.Threading.Tasks.Task<int> addRequestAsync(int bookId, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetRequests", ReplyAction="http://tempuri.org/IStoreServ/GetRequestsResponse")]
        StoreApp.StoreService.StoreRequest[] GetRequests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/GetRequests", ReplyAction="http://tempuri.org/IStoreServ/GetRequestsResponse")]
        System.Threading.Tasks.Task<StoreApp.StoreService.StoreRequest[]> GetRequestsAsync();
        
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
    public interface IStoreServCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/OnAddRequest", ReplyAction="http://tempuri.org/IStoreServ/OnAddRequestResponse")]
        void OnAddRequest(int id, int book_id, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/OnFulfillRequest", ReplyAction="http://tempuri.org/IStoreServ/OnFulfillRequestResponse")]
        void OnFulfillRequest(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IStoreServ/OnUpdateBookQuantity", ReplyAction="http://tempuri.org/IStoreServ/OnUpdateBookQuantityResponse")]
        void OnUpdateBookQuantity(int bookId, int newQuantity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IStoreServChannel : StoreApp.StoreService.IStoreServ, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StoreServClient : System.ServiceModel.DuplexClientBase<StoreApp.StoreService.IStoreServ>, StoreApp.StoreService.IStoreServ {
        
        public StoreServClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public StoreServClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public StoreServClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public StoreServClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public System.Guid Subscribe() {
            return base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task<System.Guid> SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
        
        public void Unsubscribe(System.Guid clientId) {
            base.Channel.Unsubscribe(clientId);
        }
        
        public System.Threading.Tasks.Task UnsubscribeAsync(System.Guid clientId) {
            return base.Channel.UnsubscribeAsync(clientId);
        }
        
        public StoreApp.StoreService.StoreBook[] GetBooks() {
            return base.Channel.GetBooks();
        }
        
        public System.Threading.Tasks.Task<StoreApp.StoreService.StoreBook[]> GetBooksAsync() {
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
        
        public StoreApp.StoreService.StoreOrder GetOrder(string clientEmail, int orderId) {
            return base.Channel.GetOrder(clientEmail, orderId);
        }
        
        public System.Threading.Tasks.Task<StoreApp.StoreService.StoreOrder> GetOrderAsync(string clientEmail, int orderId) {
            return base.Channel.GetOrderAsync(clientEmail, orderId);
        }
        
        public int addRequest(int bookId, int quantity) {
            return base.Channel.addRequest(bookId, quantity);
        }
        
        public System.Threading.Tasks.Task<int> addRequestAsync(int bookId, int quantity) {
            return base.Channel.addRequestAsync(bookId, quantity);
        }
        
        public StoreApp.StoreService.StoreRequest[] GetRequests() {
            return base.Channel.GetRequests();
        }
        
        public System.Threading.Tasks.Task<StoreApp.StoreService.StoreRequest[]> GetRequestsAsync() {
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
