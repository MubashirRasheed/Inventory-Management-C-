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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryManagment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class RoleScreen : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        
        public RoleScreen()
        {
            InitializeComponent();
            sqlcon.Open();
        }

        private void btn_Manager_Click(object sender, RoutedEventArgs e)
        {
            Manager Dashboard = new Manager();
            Dashboard.Show();
            Close();
        }

        private void btn_Employee_Click(object sender, RoutedEventArgs e)
        {
            Employee Dashboard = new Employee();
            Dashboard.Show();
            Close();
        }

        private void btn_Customer_Click(object sender, RoutedEventArgs e)
        {
            Customer Dashboard = new Customer();
            Dashboard.Show();
            Close();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
