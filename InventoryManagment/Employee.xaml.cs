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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InventoryManagment
{
    
    public partial class Employee : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public Employee()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            EmpRegister Dashboard = new EmpRegister();
            Dashboard.Show();
            Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            RoleScreen Dashboard = new RoleScreen();
            Dashboard.Show();
            Close();
        }

        private void EmployeeSubmit(object sender, RoutedEventArgs e)
        {

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                String query = "SELECT COUNT(1) FROM EmployeeTable WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlcon);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1 && txtUsername.Text != "" && txtPassword.Password != "")
                {
                    EmployeeDashboard dashboard = new EmployeeDashboard();
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
    }
}
