using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace InventoryManagment
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        InventoryDatabaseEntities db = new InventoryDatabaseEntities();
        public Customer()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            CstmRegister Dashboard = new CstmRegister();
            Dashboard.Show();
            Close();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                string query = "SELECT COUNT(1) FROM CustomerTable WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1 && txtUsername.Text != "" && txtPassword.Password != "")
                {
                    CustomerDashboard dashboard = new CustomerDashboard();
                    dashboard.Show();
                    this.Close();
                }
                else
                {


                    MessageBoxResult msgBoxResult = MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);

                    txtUsername.Text = "";
                    txtPassword.Password = "";
                    txtUsername.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        


    }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RoleScreen Dashboard = new RoleScreen();
            Dashboard.Show();
            Close();
        }
    }
}
