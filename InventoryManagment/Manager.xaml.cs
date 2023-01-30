using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryManagment
{
    /// <summary>
    /// Interaction logic for Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();

        public Manager()
        {
            InitializeComponent();
            txtUsername.Focus();
        }



        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register Dashboard = new Register();
            Dashboard.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RoleScreen Dashboard = new RoleScreen();
            Dashboard.Show();
            this.Close();
        }

        
        private void btnManagersubmit(object sender, RoutedEventArgs e)
        {





            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                String query = "SELECT COUNT(1) FROM ManagerTable WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1 && txtUsername.Text!= "" && txtPassword.Password != "")
                {
                    ManagerDashboard dashboard = new ManagerDashboard();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    
                    System.Windows.Forms.MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = "";
                    txtPassword.Password = "";
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlcon.Close();
            }
















            //string login = "SELECT * FROM ManagerTable WHERE Username= '" + txtUsername.Text + "' and Password= '" + txtPassword.Password + "'";
            //cm = new SqlCommand(login,sqlcon);
            //sqlcon.Open();
            //SqlDataReader dr = cm.ExecuteReader();

            //if (dr.Read() == true)
            //{
            //    //The Form which will appear after loggin in
            //    ManagerDashboard dashboard = new ManagerDashboard();
            //    dashboard.Show();
            //    Close();
            //}
            //else
            //{
            //    System.Windows.Forms.MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtUsername.Text = "";
            //    txtPassword.Password = "";
            //    txtUsername.Focus();
            //}











            //String username = txtUsername.Text;
            //string password = txtPassword.Password.ToString();

            //StreamReader reader = new StreamReader("ManagerData.txt");

            //String savedusername = reader.ReadLine();
            //string savedpassword = reader.ReadLine();

            //while((savedusername != null) && (savedpassword != null))
            //{
            //    if((savedusername == username) && (savedpassword == password))
            //    {
            //        ManagerDashboard dashboard = new ManagerDashboard();
            //        dashboard.Show();
            //        Close();
            //        break;
            //    }

            //    else
            //    {
            //        MessageBox.Show("Invalid username or password");
            //        txtUsername.Clear();
            //        txtPassword.Clear();
            //        break;
            //    }
            //}


        }

        private void btnManagerRegister(object sender, RoutedEventArgs e)
        {
            Register dashboard = new Register();
            dashboard.Show();
            Close();
        }

    }
}
