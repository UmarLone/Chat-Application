using System;
using System.Collections.Generic;
using MessagesClientWpfApp.Common;
using MessagesClientWpfApp.ServiceReference1;
using System.Windows;
using System.Timers;
using System.Threading.Tasks;

namespace MessagesClientWpfApp.Data
{

    /// <summary>
    /// This class will contain all the subscribed users,
    /// and it's responsible for updating that list
    /// to add any new subscriber.
    /// </summary>
    public class AllUsersData : BindableBase
    {

        /// <summary>
        /// used to update the list of users.
        /// </summary>
        Timer timer = new Timer(1000);

        public AllUsersData()
        {
            timer.Start();
            timer.Elapsed += timer_Elapsed;
        }


       

        private async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await SetAllUsersAsync();
        }






       

        private List<String> _allUsers = new List<string>();

        /// <summary>
        /// The list of all the subscribed users.
        /// </summary>
        public List<String> AllUsers
        {
            get
            {
                return _allUsers;
            }
            set
            {
                this.SetProperty(ref _allUsers, value);
            }
        }

        private static String _selectedUser;

        /// <summary>
        /// The selected user from the List in the Home page.
        /// </summary>
        public String SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                this.SetProperty(ref _selectedUser, value);
            }
        }

        /// <summary>
        /// Will update the list of users.
        /// </summary>
        /// <returns></returns>
        /// 

        




        private async Task SetAllUsersAsync()
        {
            try
            {
                Service1Client serviceClient = new Service1Client("BasicHttpBinding_IService1");

                var res = await serviceClient.GetAllUsersAsync();

                //convertion from String[] to List<String>
                AllUsers = new List<string>(res);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
