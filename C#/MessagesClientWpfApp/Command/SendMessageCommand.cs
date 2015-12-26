using System;
using System.Windows.Input;
using MessagesClientWpfApp.Data;
using MessagesClientWpfApp.Model;
using MessagesClientWpfApp.ServiceReference1;
using System.Windows;
using MessagesClientWpfApp.ViewModels;

namespace MessagesClientWpfApp.Command
{

    /// <summary>
    /// used to send a message to one of the users.
    /// </summary>
    public class SendMessageCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        
      
        public async void Execute(object parameter)
        {
            //parameter is in type of Home
            Home home = parameter as Home;
            try
            {
                try
                {
                    var v = home.AllUsersData.SelectedUser.Contains("");

                    

                }
                catch
                {
                   
                    return;
                }

                home.IsDoingBackgroundWork = Visibility.Visible;
                Service1Client serviceClient = new Service1Client("BasicHttpBinding_IService1");


                if (!await serviceClient.SendMessageAsync(
                     

                     home.UserModel.UserName,
                    
                    home.txtNameLabel.Text,
                     home.AllUsersData.SelectedUser.ToString(),
                     home.MessageModel.Content,
                    DateTime.Now

                   
                   ))
                {
                    //error
                   
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
               

                home.IsDoingBackgroundWork = Visibility.Collapsed;
            }
        }
    }
}
