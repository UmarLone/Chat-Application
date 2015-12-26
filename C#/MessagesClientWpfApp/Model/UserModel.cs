using System;
using MessagesClientWpfApp.Common;
using System.Threading.Tasks;
using MessagesClientWpfApp.ServiceReference1;
using System.Timers;

namespace MessagesClientWpfApp.Model
{
    /// <summary>
    /// Will act as the session between pages, 
    /// because it's attributes are static,
    /// it'll return the correct UserName and Password used to login
    /// in every time it's called.
    /// </summary>
    public class UserModel : BindableBase
    {

        private static String _Name = "";

        /// <summary>
        /// Get and Set the Username, it's value is conserved after login,
        /// because it will be called when sendind and receiving messages.
        /// </summary>
        public String Name
        {
            get { return _Name; }
            set
            {

               
                this.SetProperty(ref _Name, value);

            }
        }




        
        
        
        
        
        
        
        
        
        
        private static String _userName = "";

        /// <summary>
        /// Get and Set the Username, it's value is conserved after login,
        /// because it will be called when sendind and receiving messages.
        /// </summary>
        public String UserName
        {
            get { return _userName; }
            set
            {
                this.SetProperty(ref _userName, value);
            }
        }







        private static String _password = "";

        /// <summary>
        /// Get and Set the Password, it's value is conserved after login,
        /// because it will be called when sendind and receiving messages.
        /// </summary>
        public String Password
        {
            get { return _password; }
            set
            {
                this.SetProperty(ref _password, value);
            }
        }



        private static String _Email= "";

        /// <summary>
        /// Get and Set the Username, it's value is conserved after login,
        /// because it will be called when sendind and receiving messages.
        /// </summary>
        public String Email
        {
            get { return _Email; }
            set
            {
                this.SetProperty(ref _Email, value);
            }
        }

       












    }
}
