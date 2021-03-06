﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MessagesClientWpfApp.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SignUp", ReplyAction="http://tempuri.org/IService1/SignUpResponse")]
        bool SignUp(string Name, string userName, string Password, string Email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SignUp", ReplyAction="http://tempuri.org/IService1/SignUpResponse")]
        System.Threading.Tasks.Task<bool> SignUpAsync(string Name, string userName, string Password, string Email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsUserNameExist", ReplyAction="http://tempuri.org/IService1/IsUserNameExistResponse")]
        bool IsUserNameExist(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/IsUserNameExist", ReplyAction="http://tempuri.org/IService1/IsUserNameExistResponse")]
        System.Threading.Tasks.Task<bool> IsUserNameExistAsync(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllUsers", ReplyAction="http://tempuri.org/IService1/GetAllUsersResponse")]
        string[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllUsers", ReplyAction="http://tempuri.org/IService1/GetAllUsersResponse")]
        System.Threading.Tasks.Task<string[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        bool Login(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendMessage", ReplyAction="http://tempuri.org/IService1/SendMessageResponse")]
        bool SendMessage(string from, string name, string to, string message, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SendMessage", ReplyAction="http://tempuri.org/IService1/SendMessageResponse")]
        System.Threading.Tasks.Task<bool> SendMessageAsync(string from, string name, string to, string message, System.DateTime dateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMyMessages", ReplyAction="http://tempuri.org/IService1/GetMyMessagesResponse")]
        string[] GetMyMessages(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetMyMessages", ReplyAction="http://tempuri.org/IService1/GetMyMessagesResponse")]
        System.Threading.Tasks.Task<string[]> GetMyMessagesAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getName", ReplyAction="http://tempuri.org/IService1/getNameResponse")]
        string getName(string userName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getName", ReplyAction="http://tempuri.org/IService1/getNameResponse")]
        System.Threading.Tasks.Task<string> getNameAsync(string userName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : MessagesClientWpfApp.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<MessagesClientWpfApp.ServiceReference1.IService1>, MessagesClientWpfApp.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool SignUp(string Name, string userName, string Password, string Email) {
            return base.Channel.SignUp(Name, userName, Password, Email);
        }
        
        public System.Threading.Tasks.Task<bool> SignUpAsync(string Name, string userName, string Password, string Email) {
            return base.Channel.SignUpAsync(Name, userName, Password, Email);
        }
        
        public bool IsUserNameExist(string userName) {
            return base.Channel.IsUserNameExist(userName);
        }
        
        public System.Threading.Tasks.Task<bool> IsUserNameExistAsync(string userName) {
            return base.Channel.IsUserNameExistAsync(userName);
        }
        
        public string[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<string[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public bool Login(string userName, string password) {
            return base.Channel.Login(userName, password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string userName, string password) {
            return base.Channel.LoginAsync(userName, password);
        }
        
        public bool SendMessage(string from, string name, string to, string message, System.DateTime dateTime) {
            return base.Channel.SendMessage(from, name, to, message, dateTime);
        }
        
        public System.Threading.Tasks.Task<bool> SendMessageAsync(string from, string name, string to, string message, System.DateTime dateTime) {
            return base.Channel.SendMessageAsync(from, name, to, message, dateTime);
        }
        
        public string[] GetMyMessages(string userName, string password) {
            return base.Channel.GetMyMessages(userName, password);
        }
        
        public System.Threading.Tasks.Task<string[]> GetMyMessagesAsync(string userName, string password) {
            return base.Channel.GetMyMessagesAsync(userName, password);
        }
        
        public string getName(string userName) {
            return base.Channel.getName(userName);
        }
        
        public System.Threading.Tasks.Task<string> getNameAsync(string userName) {
            return base.Channel.getNameAsync(userName);
        }
    }
}
