
using Microsoft.Win32;
using System;
using MessagesClientWpfApp.Command;
using MessagesClientWpfApp.Model;
using MessagesClientWpfApp.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MessagesClientWpfApp.ViewModels
{
    /// <summary>
    /// Interaction logic for Choosepic.xaml
    /// </summary>
    public partial class Choosepic : Window
    {
        public Choosepic()
        {
            InitializeComponent();
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
             ImagePic.Source = new BitmapImage(new Uri(op.FileName));
             txtfilepath.Text = op.FileName;
            }


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection();
            try
            {

                connection.ConnectionString = "Data Source=IBM-MACHINE;Initial Catalog=CasaNetwork;Integrated Security=True";
                Home h = new Home();
                string insert = "INSERT INTO dbo.UserDetails (ProImage)VALUES (@ProImage) from dbo.UserDetails where dbo.UserDetails.UserName='" +h.UserModel.UserName  + "'";

               

                FileStream fs = new FileStream(txtfilepath.Text, FileMode.Open,
                FileAccess.Read);

                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

                fs.Close();

                SqlCommand command = new SqlCommand(insert, connection);

                connection.Open();




                command.Parameters.AddWithValue("@ProImage", data);

                command.ExecuteNonQuery();


                Uri uri = new Uri("ViewModels/Home.xaml", UriKind.Relative);
                Home Home = new Home();
                Home.Show();
                this.Close();


            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

            finally
            {

                connection.Close();

            }





        }





    }
}
