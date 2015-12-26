using System;
using System.Windows.Input;
using MessagesClientWpfApp.Model;
using MessagesClientWpfApp.ServiceReference1;
using MessagesClientWpfApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MessagesClientWpfApp.Command
{

    /// <summary>
    /// Used to sign in the user using his given login and password.
    /// </summary>
    public class SignInCommand : Page, ICommand
    {

        public bool CanExecute(object parameter)
        {
            return true;
        }

     public event EventHandler CanExecuteChanged;

        public async void Execute(object parameter)
        {
            try
            {






                SignUp signUp = parameter as SignUp;
                signUp.IsDoingBackgroundWork = Visibility.Visible;

                Service1Client serviceClient = new Service1Client("BasicHttpBinding_IService1");

                bool success=await serviceClient.LoginAsync(
                    signUp.UserModel.UserName,
                    signUp.UserModel.Password
                    );

         if (success)
         {
            
             signUp.IsDoingBackgroundWork = Visibility.Collapsed;
             signUp.CanSignIn = true;

         }

         else
         {
             signUp.IsDoingBackgroundWork = Visibility.Collapsed;
             MessageBox.Show(
                 "Incorrect Username or /and Password");
         }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}

