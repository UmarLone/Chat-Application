
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using MessagesClientWpfApp.Command;
using MessagesClientWpfApp.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace MessagesClientWpfApp.ViewModels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUp : Window, INotifyPropertyChanged
    {

        public SignUp()
        {
            this.InitializeComponent();

            this.DataContext = this;
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

        

        public SignInCommand SignInCommand
        {
            get { return new SignInCommand(); }
        }

        private bool _canSignIn = false;
        /// <summary>
        /// used by the SignInCommand to tell that signing up
        /// succeeded, so that it could navigate to the next page.
        /// </summary>
        public bool CanSignIn
        {
            get { return _canSignIn; }
            set
            {
                _canSignIn = value;
                if (_canSignIn)
                {
                    Uri uri = new Uri("ViewModels/Home.xaml", UriKind.Relative);
                    Home Home = new Home();
                    Home.Show();
                    this.Close();
                }
            }
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("ViewModels/Register.xaml", UriKind.Relative);
            Register Register = new Register();
            Register.Show();
            this.Close();
        }
    }
}
