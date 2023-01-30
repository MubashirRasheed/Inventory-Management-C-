using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace InventoryManagment
{

    public partial class ManageProduct : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        

        public ManageProduct()
        {
            InitializeComponent();
            fill_combo();

            SqlCommand cmd = new SqlCommand("SELECT ProductID,ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            ManageProductsDataGrid.ItemsSource = dd.DefaultView;



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
            ManagerDashboard Dashboard = new ManagerDashboard();
            Dashboard.Show();
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ManageProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



            DataRowView dr = ManageProductsDataGrid.SelectedItem as DataRowView;
            if (dr != null)
            {
                ProductNametxt.Text = dr["ProductName"].ToString();
                ProductIDtxt.Text = dr["ProductID"].ToString();
                Pricetxt.Text = dr["ProductPrice"].ToString();
                Quantitytxt.Text = dr["ProductQuantity"].ToString();
                Categorytxt.Text = dr["ProductCategory"].ToString();
                Imagetxt.Text = dr["ProductImage"].ToString();

            }

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
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Image");
            }



        }

        private void Refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT ProductID,ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            ManageProductsDataGrid.ItemsSource = dd.DefaultView;




        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True"))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("UPDATE AddProductTable SET ProductName=@ProductName,ProductID=@ProID, ProductPrice=@ProductPrice,ProductQuantity=@ProductQuantity,ProductCategory=@ProductCategory,ProductImage=@ProductImage" + " WHERE ProductID=@ProID OR ProductName=@ProductName"
                           , sqlcon))
                    {

                        cmd.Parameters.AddWithValue("@ProductName", ProductNametxt.Text);
                        cmd.Parameters.AddWithValue("@ProID", ProductIDtxt.Text);
                        cmd.Parameters.AddWithValue("@ProductQuantity", Quantitytxt.Text);
                        cmd.Parameters.AddWithValue("@ProductPrice", Pricetxt.Text);
                        cmd.Parameters.AddWithValue("@ProductCategory", Categorytxt.Text);
                        cmd.Parameters.AddWithValue("@ProductImage", Imagetxt.Text);
                        int rows = cmd.ExecuteNonQuery();
                        sqlcon.Close();
                        System.Windows.Forms.MessageBox.Show("Product has been Updated Successfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand asd = new SqlCommand("SELECT ProductID,ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
                        DataTable dd = new DataTable();
                        sqlcon.Open();
                        SqlDataReader sdr = asd.ExecuteReader();
                        dd.Load(sdr);
                        sqlcon.Close();
                        ManageProductsDataGrid.ItemsSource = dd.DefaultView;

                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Update Failed Please check the entries!", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Deletebtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Are you sure to delete the selected Product?",
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
                            new SqlCommand("DELETE AddProductTable WHERE ProductID=@ProID"
                               , sqlcon))
                        {

                            cmd.Parameters.AddWithValue("@ProID", ProductIDtxt.Text);

                            int rows = cmd.ExecuteNonQuery();
                            sqlcon.Close();
                            System.Windows.Forms.MessageBox.Show("Product has been Deleted Successfully", "Deleted Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SqlCommand asd = new SqlCommand("SELECT ProductID,ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
                            DataTable dd = new DataTable();
                            sqlcon.Open();
                            SqlDataReader sdr = asd.ExecuteReader();
                            dd.Load(sdr);
                            sqlcon.Close();
                            ManageProductsDataGrid.ItemsSource = dd.DefaultView;
                        }
                    }
                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Delete Failed Please check the entries!", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Categorytxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryComboBox.SelectedIndex == 0)
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductID, ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
                DataTable dd = new DataTable();
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dd.Load(sdr);
                sqlcon.Close();
                ManageProductsDataGrid.ItemsSource = dd.DefaultView;
            }
            else
            {
                sqlcon.Open();
                string selected = CategoryComboBox.SelectedItem.ToString();
                SqlCommand cmd = new SqlCommand("SELECT ProductID, ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable WHERE ProductCategory=@cat", sqlcon);
                cmd.Parameters.Add("@cat", SqlDbType.VarChar);
                cmd.Parameters["@cat"].Value = selected;
                DataTable dd = new DataTable();

                SqlDataReader sdr = cmd.ExecuteReader();
                dd.Load(sdr);
                sqlcon.Close();
                ManageProductsDataGrid.ItemsSource = dd.DefaultView;

            }
        }
    }
}
