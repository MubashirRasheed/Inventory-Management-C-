using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    
    public partial class ApproveOrders : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public ApproveOrders()
        {
            InitializeComponent();

            SqlCommand cmd = new SqlCommand("SELECT Products,TotalPrice,TotalQuantity,Address FROM OrderTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            ProductsDataGrid.ItemsSource = dd.DefaultView;
           
        }
 

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard dashboard = new EmployeeDashboard();
            dashboard.Show();
            Close();
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            if (Addresstxt.Text == "")
            {
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Please select an order first",
            "Approve Order",
            MessageBoxButton.OK,
            MessageBoxImage.Error,
            MessageBoxResult.OK
            );
            }
            else
            {
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Are you sure to delete the selected Order?",
            "Delete Product",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning,
            MessageBoxResult.No
            );

                if (msgBoxResult == MessageBoxResult.Yes)
                {

                    try
                    {
                        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True"))
                        {
                            sqlcon.Open();
                            using (SqlCommand cmd =
                                new SqlCommand("DELETE Ordertable WHERE Address=@Address"
                                   , sqlcon))
                            {

                                cmd.Parameters.AddWithValue("@Address", Addresstxt.Text);

                                int rows = cmd.ExecuteNonQuery();
                                sqlcon.Close();
                                System.Windows.Forms.MessageBox.Show("Order has been Deleted Successfully", "Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SqlCommand asd = new SqlCommand("SELECT Products,TotalPrice,TotalQuantity,Address FROM OrderTable", sqlcon);
                                DataTable dd = new DataTable();
                                sqlcon.Open();
                                SqlDataReader sdr = asd.ExecuteReader();
                                dd.Load(sdr);
                                sqlcon.Close();
                                ProductsDataGrid.ItemsSource = dd.DefaultView;
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Delete Failed Please check the entries!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Addresstxt.Text = "";
        }

        private void Click_Approve(object sender, RoutedEventArgs e)
        {
            if (Addresstxt.Text == "")
            {
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Please select an order first",
            "Approve Order",
            MessageBoxButton.OK,
            MessageBoxImage.Error,
            MessageBoxResult.OK
            );
            }
            else
            {
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Are you sure to approve the selected Order?",
                "Approve Order",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No
                );

                if (msgBoxResult == MessageBoxResult.Yes)
                {


                    try
                    {
                        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True"))
                        {
                            sqlcon.Open();
                            using (SqlCommand cmd =
                                new SqlCommand("DELETE Ordertable WHERE Address=@Address"
                                   , sqlcon))
                            {

                                cmd.Parameters.AddWithValue("@Address", Addresstxt.Text);

                                int rows = cmd.ExecuteNonQuery();
                                sqlcon.Close();
                                System.Windows.Forms.MessageBox.Show("Order has been Approved Successfully", "Approved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SqlCommand asd = new SqlCommand("SELECT Products,TotalPrice,TotalQuantity,Address FROM OrderTable", sqlcon);
                                DataTable dd = new DataTable();
                                sqlcon.Open();
                                SqlDataReader sdr = asd.ExecuteReader();
                                dd.Load(sdr);
                                sqlcon.Close();
                                ProductsDataGrid.ItemsSource = dd.DefaultView;
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Delete Failed Please check the entries!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Addresstxt.Text = "";

        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = ProductsDataGrid.SelectedItem as DataRowView;
            if (dr != null)
            {
                Addresstxt.Text = dr["Address"].ToString();
              

            }
        }

    }

}
