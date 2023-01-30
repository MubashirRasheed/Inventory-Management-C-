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
   
    public partial class Shop : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        InventoryDatabaseEntities db = new InventoryDatabaseEntities();
        public Shop()
        {
            InitializeComponent();
            fill_combo();
           
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
            catch(Exception e)
            {
                System.Windows.MessageBox.Show("Error.");
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            CustomerDashboard Dashboard = new CustomerDashboard();
            Dashboard.Show();
            Close();
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

        private void ViewCartbtn_Click(object sender, RoutedEventArgs e)
        {
            Cart Dashboard = new Cart();
            Dashboard.Show();
            Close();
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            DataRowView dr = ProductsDataGrid.SelectedItem as DataRowView;


            if (dr != null)
            {
                ProductNametxt.Text = dr["ProductName"].ToString();
            
            }

            try
            {
                string picpath = dr["ProductImage"].ToString();
                if( picpath.StartsWith("D:"))
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
            catch (NullReferenceException)
            {
                Console.WriteLine("Invalid Image");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Image");
            }
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductNametxt.Text != "")
            {

                try
                {

                    int quantity = Convert.ToInt32(Quantitytxt.Text);

                    int dbquantity;
                    int dbprice;
                    DataRowView dr = ProductsDataGrid.SelectedItem as DataRowView;
                    dbquantity = Convert.ToInt32(dr["ProductQuantity"]);
                    dbprice = Convert.ToInt32(dr["ProductPrice"]);

                    int diff = dbquantity - quantity;
                    int total = dbprice * quantity;
                    if (quantity <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Invalid Quantity", "Purchase Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (diff < 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Fuck you", "Purchase Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
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

                                    cmd.Parameters.AddWithValue("@ProductQuantity", diff);
                                    cmd.Parameters.AddWithValue("@ProductName", ProductNametxt.Text);

                                    int rows = cmd.ExecuteNonQuery();

                                    sqlcon.Close();

                                    System.Windows.Forms.MessageBox.Show("Order added to cart", "Purchase Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    if (CategoryComboBox.SelectedIndex == 0)
                                    {
                                        SqlCommand cmdw = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable", sqlcon);
                                        DataTable dd = new DataTable();
                                        sqlcon.Open();
                                        SqlDataReader sdr = cmdw.ExecuteReader();
                                        dd.Load(sdr);
                                        sqlcon.Close();
                                        ProductsDataGrid.ItemsSource = dd.DefaultView;
                                    }
                                    else
                                    {
                                        sqlcon.Open();
                                        string selected = CategoryComboBox.SelectedItem.ToString();
                                        SqlCommand cmdw = new SqlCommand("SELECT ProductName,ProductPrice,ProductQuantity,ProductCategory,ProductImage FROM AddProductTable WHERE ProductCategory=@cat", sqlcon);
                                        cmdw.Parameters.Add("@cat", SqlDbType.VarChar);
                                        cmdw.Parameters["@cat"].Value = selected;
                                        DataTable dd = new DataTable();

                                        SqlDataReader sdr = cmdw.ExecuteReader();
                                        dd.Load(sdr);
                                        sqlcon.Close();
                                        ProductsDataGrid.ItemsSource = dd.DefaultView;

                                    }

                                    if (sqlcon.State == ConnectionState.Closed)
                                        sqlcon.Open();



                                    cm = new SqlCommand("INSERT INTO CartTable(ProductName,ProductPrice,ProductQuantity,ProductCategory,TotalPrice)VALUES(@ProductName,@ProductPrice,@ProductQuantity,@ProductCategory,@TotalPrice)", sqlcon);

                                    cm.Parameters.AddWithValue("@ProductName", dr["ProductName"].ToString());
                                    cm.Parameters.AddWithValue("@ProductPrice", dr["ProductPrice"].ToString());
                                    cm.Parameters.AddWithValue("@ProductQuantity", quantity);
                                    cm.Parameters.AddWithValue("@ProductCategory", dr["ProductCategory"].ToString());
                                    cm.Parameters.AddWithValue("@TotalPrice", total);

                                    cm.ExecuteNonQuery();

                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show("Add to cart failed!", "Purchase Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception)
                {
                    System.Windows.Forms.MessageBox.Show("Quantitiy entered not available in stock", "Purchase Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please select a product first", "Purchase Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
            Quantitytxt.Text = "";



        }

}
    }

