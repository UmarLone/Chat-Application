using MessagesClientWpfApp.Command;
using MessagesClientWpfApp.Model;
using MessagesClientWpfApp.ViewModels;
using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;


namespace MessagesClientWpfApp.ViewModels
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window, INotifyPropertyChanged
    {
          public Register()
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

        public SignUpCommand SignUpCommand
        {
            get { return new SignUpCommand(); }
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
                    Home home = new Home();
                   home.Show();
                    this.Close();
                }

                else
                {


                    Uri uri = new Uri("ViewModels/SignUp.xaml", UriKind.Relative);

                    SignUp SignUp = new SignUp();
                    SignUp.Show();

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




        
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
              ProImage.Source = new BitmapImage(new Uri(op.FileName));
              txtimage.Text = op.FileName;
            }
        
        }











       
        

        private void SaveImageToFloder(object sender, RoutedEventArgs e)
        {

            if (txtimage.Text =="")
            {
                MessageBox.Show("Choose a Profile Image");
            }
            else
            {
                Bitmap bitmap = new Bitmap(txtimage.Text);
                string path = Path.GetTempPath();
                bitmap.Save(path + "\\ProfileImage.jpg");
               
                bitmap.Dispose();
            }


        }
    }
}
