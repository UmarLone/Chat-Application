using MessagesClientWpfApp.Command;
using MessagesClientWpfApp.Data;
using MessagesClientWpfApp.Model;
using System.ComponentModel;
using System.Windows;

using MessagesClientWpfApp.ServiceReference1;
using System.Media;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;


namespace MessagesClientWpfApp.ViewModels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Window, INotifyPropertyChanged
    {
        public Home()
        {
            this.InitializeComponent();

            this.DataContext = this;

       
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            UserModel m = new Model.UserModel();
            Service1Client serviceClient = new Service1Client("BasicHttpBinding_IService1");

            string r = serviceClient.getName(m.UserName);

            txtNameLabel.Text = r;
            string path = Path.GetTempPath();
            var uri = new Uri(path + "\\ProfileImage.jpg");
          NewProImage.Source = new BitmapImage(uri);
           
            
           

           


        }





        private UserModel _userModel = new UserModel();
        public UserModel UserModel
        {
            get { return _userModel; }
            set
            {
                _userModel = value;
            }
        }




        private MessageModel _messageModel = new MessageModel();
        public MessageModel MessageModel
        {
            get { return _messageModel; }
        }





        private   UserModel _name = new UserModel();

        public UserModel name
        {

            get { return _name; }
        }



        private AllUsersData _allUsersData = new AllUsersData();

      








        public AllUsersData AllUsersData
        {
            get { return _allUsersData; }
        }

        private AllReceivedMessagesData _allReceivedMessagesData = new AllReceivedMessagesData();
        public AllReceivedMessagesData AllReceivedMessagesData
        {
            get
            {
                return _allReceivedMessagesData;
            }
        }

        private SendMessageCommand _sendMessageCommand = new SendMessageCommand();
        public SendMessageCommand SendMessageCommand
        {
            get { return _sendMessageCommand; }
        }

        private Visibility _isDoingBackgroundWork = Visibility.Collapsed;
        public Visibility IsDoingBackgroundWork
        {
            get { return _isDoingBackgroundWork; }
            set
            {
                _isDoingBackgroundWork = value;
                OnPropertyChanged("IsDoingBackgroundWork");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// It's invoked whenever a given property is changed.
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Meclick_Click(object sender, RoutedEventArgs e)
        {
            if (AllUsersData.SelectedUser==null)
            {
                MessageBox.Show("Select a user to send him this message, please!");
                
                return;
            }
            else
            {
             
           upmsg.AppendText(" I wrote :  " + textBoxContent.Text+"\n");
            new SoundPlayer(Properties.Resources.bell_ringing_05).Play();
         textBoxContent.Clear();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

               Uri uri = new Uri("ViewModels/SignUp.xaml", UriKind.Relative);

                SignUp SignUp = new SignUp();
                SignUp.Show();



                this.Close();
            }


        

       
       
    }
}
