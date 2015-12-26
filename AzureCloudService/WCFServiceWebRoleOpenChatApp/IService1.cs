using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace WCFServiceWebRoleOpenChatApp
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool SignUp(string Name, string userName, string Password, string Email);

        [OperationContract]
        bool IsUserNameExist(string userName);

        [OperationContract]
        List<string> GetAllUsers();

        [OperationContract]
        bool Login(string userName, string password);

        [OperationContract]
        bool SendMessage(string from, string name, string to, string message, DateTime dateTime);

        [OperationContract]
        List<String> GetMyMessages(string userName, string password);


        [OperationContract]
        String getName(string userName);
    }
}
