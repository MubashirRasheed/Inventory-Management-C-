using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Addproducts.xaml
    /// </summary>
    public partial class ManageStock : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public ManageStock()
        {
            InitializeComponent();
            fill_combo();

            SqlCommand cmd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            ProductsDataGrid.ItemsSource = dd.DefaultView;

        }

        void fill_combo()
        {
            try
            {
                sqlcon.Open();
                string Query = "select * from AddProductTable";
                SqlCommand createcommand = new SqlCommand(Query, sqlcon);
                SqlDataReader dr = createcommand.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(5);
                    if (CategoryComboBox.Items.Contains(name))
                    {

                    }
                    else
                        CategoryComboBox.Items.Add(name);
                }
                sqlcon.Close();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Error.");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard dashboard = new EmployeeDashboard();
            dashboard.Show();
            Close();
        }

        private void Click_Update(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True"))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("UPDATE AddProductTable SET ProductQuantity=@ProductQuantity" + " WHERE ProductName=@ProductName"
                           , sqlcon))
                    {

                   
                        cmd.Parameters.AddWithValue("@ProductQuantity", Stocktxt.Text);
                        cmd.Parameters.AddWithValue("@ProductName", ProductNametxt.Text);
                        
                        cmd.ExecuteNonQuery();
                        sqlcon.Close();
                        System.Windows.Forms.MessageBox.Show("Stock has been Updated Successfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand asd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
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
                System.Windows.Forms.MessageBox.Show("Update Failed Please check the entries!", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            DataRowView dr = ProductsDataGrid.SelectedItem as DataRowView;
            if (dr != null)
            {
                Stocktxt.Text = dr["ProductQuantity"].ToString();
                ProductNametxt.Text = dr["ProductName"].ToString();
                try
                {
                    if (dr["ProductImage"].ToString() != "")
                    {
                        string pic = dr["ProductImage"].ToString();
                        Uri i = new Uri(pic);
                        ImageSource s = new BitmapImage(i);
                        ProductImageBox.Source = s;
                    }
                    else
                    {

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Invalid Image");
                }              

            }  

        }

        private void Categorytxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (CategoryComboBox.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
                DataTable dd = new DataTable();
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dd.Load(sdr);
                sqlcon.Close();
                ProductsDataGrid.ItemsSource = dd.DefaultView;
            }
            else
            {
                sqlcon.Open();
                string selected = CategoryComboBox.SelectedItem.ToString();
                SqlCommand cmd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable WHERE ProductCategory=@cat", sqlcon);
                cmd.Parameters.Add("@cat", SqlDbType.VarChar);
                cmd.Parameters["@cat"].Value = selected;
                DataTable dd = new DataTable();

                SqlDataReader sdr = cmd.ExecuteReader();
                dd.Load(sdr);
                sqlcon.Close();
                ProductsDataGrid.ItemsSource = dd.DefaultView;

            }


        }

        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {

            SqlCommand cmd = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            ProductsDataGrid.ItemsSource = dd.DefaultView;
        }
    }

}
