using System;
using MessagesClientWpfApp.Common;
using MessagesClientWpfApp.Model;
using MessagesClientWpfApp.ServiceReference1;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using System.Timers;
using System.Media;


namespace MessagesClientWpfApp.Data
{

    /// <summary>
    /// This class will contain all the messages sent to the logged user,
    /// and it's responsible for updating the messages.
    /// </summary>
    public class AllReceivedMessagesData : BindableBase
    {
        /// <summary>
        /// timer is used to refresh messages every defined period of time.
        /// </summary>
        Timer timer = new Timer(1000);//5ms

        public AllReceivedMessagesData()
        {
            timer.Start();
            timer.Elapsed += timer_Elapsed;
        }

        private async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
           await UpdateMessagesAsync();
        }

         //<summary>
         //This will get the newer list of messages send to the current 
         //logged user.
         //</summary>
         //<returns></returns>
        public async Task UpdateMessagesAsync()
        {
            try
            {
                UserModel _userModel = new UserModel();

                Service1Client serviceClient = new Service1Client(
                    "BasicHttpBinding_IService1");

              
        var Messages =  await serviceClient.GetMyMessagesAsync(
                    _userModel.UserName,
                    _userModel.Password
                    );

                string aux = string.Empty;
                foreach (string item in  Messages)
                {
                    aux += item;
                }
                Msgs = aux;
               
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private String _msgs = "";
         
        /// <summary>
        /// Contains the messages in form of String.
        /// </summary>
        public String Msgs
        {
            get { return _msgs; }
            set { this.SetProperty(ref _msgs, value); }
        }

        private List<String> _messages = new List<string>();

        /// <summary>
        /// Contains the messages in form of List<String>.
        /// </summary>
        public List<String> Messages
        {
            get { return _messages; }
            set { this.SetProperty(ref _messages, value); }
        }
    }
}