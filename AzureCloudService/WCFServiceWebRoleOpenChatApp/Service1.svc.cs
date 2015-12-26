
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;
using System.Xml;
using System.Xml.Linq;

namespace WCFServiceWebRoleOpenChatApp
{
    public class Service1 : IService1
    {

        public String appPath = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;

        public Service1()
        {
        }

        /// <summary>
        /// Sign up returns true if username is not being used,
        /// and return false otherwise.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// 


       



        public  bool SignUp(string Name ,string userName, string Password,string Email)
        {
            try
            {

               

      string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    //SqlConnection is in System.Data.SqlClient namespace
    using (SqlConnection con = new SqlConnection(CS))
    {
        SqlCommand cmd = new SqlCommand("spRegisterUser", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter name = new SqlParameter("@Name", Name);

        SqlParameter username = new SqlParameter("@UserName", userName);
        // FormsAuthentication class is in System.Web.Security namespace

       
        SqlParameter password = new SqlParameter("@Password", Password);
        SqlParameter email = new SqlParameter("@Email", Email);
       

     
           
       
       
     
        cmd.Parameters.Add(name);
        cmd.Parameters.Add(username);
        cmd.Parameters.Add(password);
        cmd.Parameters.Add(email);
     

        con.Open();
        int ReturnCode = (int)cmd.ExecuteScalar();
        if (ReturnCode == -1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }




            }
            catch (Exception exception)
            {
                //Report error to Log.txt file
                System.IO.File.WriteAllText(appPath + "\\App_Data\\Log.txt",
                    "\n" + DateTime.Now
                    + "\n" + userName
                    + "\n" + Password
                    + exception.Message
                    );

                return false;
            }
        }
      
        /// <summary>
        /// return true if username is being used,
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsUserNameExist(string userName)
        {
            try
            {
                XElement xml = XElement.Load(appPath + "\\App_Data\\Passwords.xml");

                foreach (var item in xml.Elements("user"))
                {
                    if (item.Element("name").Value == userName)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception exception)
            {
                System.IO.File.WriteAllText(appPath + "\\App_Data\\Log.txt",
                    "\n" + DateTime.Now
                    + "\n" + userName
                    + "\n" + exception.Message
                    );

                return false;
            }
        }

        /// <summary>
        /// return a list of all user's usernames.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllUsers()
        {
            try
            {


                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;
                    
                   

                    cmd.CommandText = "SELECT UserName FROM UserDetails";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();

                    reader = cmd.ExecuteReader();
                   
                   
                    // Data is accessible through the DataReader object here.

                    List<String> allUsers = new List<string>();

                    while (reader.Read())
                    {
                        allUsers.Add(reader.GetString(0));

                    }

                    return allUsers;


                   
             




                }





















               
            }
            catch (Exception exception)
            {
                System.IO.File.WriteAllText(appPath + "\\App_Data\\Log.txt",
                    "\n" + DateTime.Now
                    + "\n" + exception.Message
                     );

                return null;
            }
        }

        /// <summary>
        /// Returns true if the user could sign in
        /// using the given username and password,
        /// otherwise returns false.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName, string Password)
        {
            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection sqlConnection1 = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;

                    cmd.CommandText = "SELECT UserName,Password FROM UserDetails";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    reader = cmd.ExecuteReader();
                    // Data is accessible through the DataReader object here.



                   
                     while (reader.Read())
                        {
                            if (userName == reader.GetString(0) && Password == reader.GetString(1))
                            {

                                return true;
                            }
                        }
                    
                    sqlConnection1.Close();
                    return false;




                }



            }
            catch (Exception exception)
            {
                System.IO.File.WriteAllText(appPath + "\\App_Data\\Log.txt",
                    "\n" + DateTime.Now
                    + "\n" + userName
                    + "\n" + Password
                    + "\n" + exception.Message
                     );

                return false;
            }
        }

        /// <summary>
        /// sends a message to one of the users.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="password"></param>
        /// <param name="to"></param>
        /// <param name="message"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>



        public bool SendMessage(string from, string name, string to, string message, DateTime dateTime)
        {







            try
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection sqlConnection1 = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataReader reader;

                    cmd.CommandText = "SELECT UserName FROM UserDetails where dbo.UserDetails.UserName='"+from+"'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    reader = cmd.ExecuteReader();
                    // Data is accessible through the DataReader object here.

                    
                   

                    while (reader.Read())
                    {

                        if (from == reader[0].ToString())
                        {
                            string CS1 = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                            string insertCmd = "INSERT INTO MessageBox (Message,DateTime,FromUsername,MessageFromName,MessageToUserName)  VALUES (@Message,@DateTime,@FromUsername,@MessageFromName,@MessageToUserName)";
                   
                 

                            SqlConnection sqlConnection2 = new SqlConnection(CS1);
                            SqlCommand cmd1 = new SqlCommand(insertCmd,sqlConnection2);
                            sqlConnection2.Open();
                            SqlParameter myParam = new SqlParameter("@ProImage", SqlDbType.Image);
                           cmd1.Parameters.AddWithValue("@Message", message);
                            cmd1.Parameters.AddWithValue("@DateTime", dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            cmd1.Parameters.AddWithValue("@FromUserName", from);
                           cmd1.Parameters.AddWithValue("@MessageFromName", name);
                           cmd1.Parameters.AddWithValue("@MessageToUserName", to);
                          
                            cmd1.ExecuteNonQuery();

                            return true;

                        }
                    }

                    sqlConnection1.Close();
                    return false;




                }



            }
            catch (Exception exception)
            {
                System.IO.File.WriteAllText(appPath + "\\App_Data\\Log.txt",
                    "\n" + DateTime.Now
                    + "\n" + name
                
                    + "\n" + exception.Message
                     );

                return false;
            }

        }






















        public string getName(string username)
        {
            string CS = "Data Source=IBM-MACHINE;Initial Catalog=CasaNetwork;Integrated Security=True";
            using (SqlConnection sqlConnection1 = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT dbo.UserDetails.Name  FROM UserDetails where dbo.UserDetails.UserName='"+username+"'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.


                string gotName="";

                while (reader.Read())
                {
                 gotName=reader[0].ToString();
                    

                        
                    
                }
                return gotName;


               





            }

               





            }

        














        /// <summary>
        /// send me my messages.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<String> GetMyMessages(string userName, string password)
        {


            List<string> myMessages = new List<string>();



            string CS1 = "Data Source=IBM-MACHINE;Initial Catalog=CasaNetwork;Integrated Security=True";
            SqlConnection sqlConnection1 = new SqlConnection(CS1);



            SqlCommand cmd1 = new SqlCommand("select dbo.MessageBox.FromUserName,dbo.MessageBox. Message,cast(dbo.MessageBox.DateTime as TIME) as Time  from dbo.MessageBox where dbo.MessageBox.Messagetousername='" + userName + "'");
            SqlDataReader reader1;



            cmd1.Connection = sqlConnection1;

            sqlConnection1.Open();
            reader1 = cmd1.ExecuteReader();






            while (reader1.Read())
            {


                myMessages.Add(

                    reader1[0].ToString() +"   Wrote :  "+  "\t" + reader1[1].ToString() + "\t" + "@  "+ reader1[2].ToString()+"\n"



                    );





            }
            sqlConnection1.Close();

            return myMessages;


















        }
    }
}
