using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    
    public partial class ManagerDashboard : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\VisualStudio\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Manager Dashboard = new Manager();
            Dashboard.Show();
            Close();
        }

        private void Add_Products(object sender, RoutedEventArgs e)
        {
            AddProducts Dashboard = new AddProducts();
            Dashboard.Show();
            Close();
        }

        private void ManagePro_Click(object sender, RoutedEventArgs e)
        {
            ManageProduct Dashboard = new ManageProduct();
            Dashboard.Show();
            Close();
        }

        private void ManageEmp_Click(object sender, RoutedEventArgs e)
        {
            ManageEmployees Dashboard = new ManageEmployees();
            Dashboard.Show();
            Close();
        }
    }
}
