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
   
    public partial class Cart : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True ");
        SqlCommand cm = new SqlCommand();
        public Cart()
        {
            InitializeComponent();

            SqlCommand cmd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,TotalPrice FROM CartTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            ProductsDataGrid.ItemsSource = dd.DefaultView;

            try
            {
                int total = 0;
                int totalQ = 0;
                sqlcon.Open();
                string Query = "select * from CartTable";
                SqlCommand createcommand = new SqlCommand(Query, sqlcon);
                SqlDataReader dr = createcommand.ExecuteReader();
                while (dr.Read())
                {
                    string prices = dr.GetString(5);
                    total = total + Convert.ToInt32(prices);

                    string quantities = dr.GetString(3);
                    totalQ = totalQ + Convert.ToInt32(quantities);
                }

                TotalPricetxt.Text = Convert.ToString( total);
                Totaltxt.Text = Convert.ToString(totalQ);
                sqlcon.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Error.");
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Shop Dashboard = new Shop();
            Dashboard.Show();
            Close();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (ProductNametxt.Text != "") { 
               MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Are you sure to remove the selected Product?",
               "Remove Product",
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
                                new SqlCommand("DELETE CartTable WHERE ProductName=@ProductName"
                                   , sqlcon))
                            {

                                cmd.Parameters.AddWithValue("@ProductName", ProductNametxt.Text);

                                int rows = cmd.ExecuteNonQuery();
                                sqlcon.Close();
                                System.Windows.Forms.MessageBox.Show("Product has been removed Successfully", "Removed Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SqlCommand asd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,TotalPrice FROM CartTable", sqlcon);
                                DataTable dd = new DataTable();
                                sqlcon.Open();
                                SqlDataReader sdr = asd.ExecuteReader();
                                dd.Load(sdr);
                                sqlcon.Close();
                                ProductsDataGrid.ItemsSource = dd.DefaultView;
                                ProductNametxt.Text = "";
                            }
                        }
                    }

                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Delete Failed Please check the entries!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBoxResult msgBoxResult2 = System.Windows.MessageBox.Show("Invalid option.",
               "Remove Product",
               MessageBoxButton.OK,
               MessageBoxImage.Error,
               MessageBoxResult.OK);
                }
            }

            Addresstxt.Text = "";
            ProductNametxt.Text = "";
            TotalPricetxt.Text = "";
            Totaltxt.Text = "";


        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView dr = ProductsDataGrid.SelectedItem as DataRowView;
            if (dr != null)
            {
                ProductNametxt.Text = dr["ProductName"].ToString();
               

            }

        }

        private void Checkoutbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int total = 0;
                int totalQ = 0;
                string names = "";
                sqlcon.Open();
                string Query = "select * from CartTable";
                SqlCommand createcommand = new SqlCommand(Query, sqlcon);
                SqlDataReader dr = createcommand.ExecuteReader();
                while (dr.Read())
                {
                    string prices = dr.GetString(5);
                    total = total + Convert.ToInt32(prices);

                    string quantities = dr.GetString(3);
                    totalQ = totalQ + Convert.ToInt32(quantities);

                    string name = dr.GetString(1);
                    names = names  + Convert.ToString(name) + ", ";
                }

                if (Addresstxt.Text == "")
                {
                    System.Windows.Forms.MessageBox.Show("Address field is empty", "Checkout Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (sqlcon.State == ConnectionState.Closed)
                        sqlcon.Open();


                    cm = new SqlCommand("INSERT INTO OrderTable(Products,TotalPrice,TotalQuantity,Address)VALUES(@Products,@TotalPrice,@TotalQuantity,@Address)", sqlcon);
                    cm.Parameters.AddWithValue("@Products", names);
                    cm.Parameters.AddWithValue("@TotalPrice", total);
                    cm.Parameters.AddWithValue("@TotalQuantity", totalQ);
                    cm.Parameters.AddWithValue("@Address", Addresstxt.Text);

                    dr.Close();
                    cm.ExecuteNonQuery();


                    System.Windows.Forms.MessageBox.Show("Your order has been placed Successfully", "Order Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True"))
                        {
                            sqlcon.Open();
                            using (SqlCommand cmd =
                                new SqlCommand("DELETE CartTable"
                                   , sqlcon))
                            {

                                int rows = cmd.ExecuteNonQuery();
                                sqlcon.Close();

                                SqlCommand asd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,TotalPrice FROM CartTable", sqlcon);
                                DataTable dd = new DataTable();
                                sqlcon.Open();
                                SqlDataReader sdr = asd.ExecuteReader();
                                dd.Load(sdr);
                                sqlcon.Close();
                                ProductsDataGrid.ItemsSource = dd.DefaultView;
                                ProductNametxt.Text = "";
                            }
                        }
                    }

                    catch (Exception)
                    {
                        System.Windows.Forms.MessageBox.Show("Delete Failed", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    Addresstxt.Text = "";
                    ProductNametxt.Text = "";
                    TotalPricetxt.Text = "";
                    Totaltxt.Text = "";

                }

                sqlcon.Close();
        }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error.");
            }


           





        }
    }
}
