using MessagesClientWpfApp.ServiceReference1;
using System;
using System.Windows;
using System.Windows.Input;
using MessagesClientWpfApp.ViewModels;
using System.Windows.Controls;
using MessagesClientWpfApp.Model;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MessagesClientWpfApp.Command
{

    /// <summary>
    /// Used to sign up the user using his given login and password.
    /// </summary>
    public class SignUpCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;


        //private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
        //                            System.Drawing.Imaging.ImageFormat formatOfImage)
        //{
        //    byte[] Ret;
        //    try
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            imageToConvert.Save(ms, formatOfImage);
        //            Ret = ms.ToArray();
        //        }
        //    }
        //    catch (Exception) { throw; }
        //    return Ret;
        //}


        //public byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource imageSource)
        //{
        //    byte[] bytes = null;
        //    var bitmapSource = imageSource as BitmapSource;

        //    if (bitmapSource != null)
        //    {
        //        encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

        //        using (var stream = new MemoryStream())
        //        {

        //            encoder.Save(stream);
        //            bytes = stream.ToArray();
        //        }
        //    }

        //    return bytes;
        //}



        public async void Execute(object parameter)
        {
           
           
            


           

               Register signUp = parameter as Register;
               
                signUp.IsDoingBackgroundWork = Visibility.Visible;
                Service1Client serviceClient = new Service1Client("BasicHttpBinding_IService1");

                
                
                    //signUp.IsDoingBackgroundWork = Visibility.Collapsed;
                    //MessageBox.Show(
                    //    "User already exists, choose different one");


             

              bool  success=   await serviceClient.SignUpAsync(
                         signUp.UserModel.Name,
                         signUp.UserModel.UserName,
                         signUp.UserModel.Password,
                         signUp.UserModel.Email
                         
                        
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
                      "User already exists, choose different one or Login");
                  signUp.IsDoingBackgroundWork = Visibility.Collapsed;
                  signUp.CanSignIn = false;

              }
                
           
        }


    }
}
