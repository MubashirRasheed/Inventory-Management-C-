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
    /// Interaction logic for AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();

        public AddProducts()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManagerDashboard Dashboard = new ManagerDashboard();
            Dashboard.Show();
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (ProductNametxt.Text == "" || ProductIDtxt.Text == "" || Pricetxt.Text == "" || Quantitytxt.Text == "" || Categorytxt.Text == "" )
            {
                System.Windows.Forms.MessageBox.Show("Product Name and ID fields are empty", "Adding Product Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (ProductNametxt.Text != null)
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();
                
               

                cm = new SqlCommand("INSERT INTO AddProductTable(ProductName,ProductID,ProductPrice,ProductQuantity,ProductCategory,ProductImage)VALUES(@ProductName,@ProductID,@ProductPrice,@ProductQuantity,@ProductCategory,@ProductImage)", sqlcon);
                cm.Parameters.AddWithValue("@ProductName", ProductNametxt.Text);
                cm.Parameters.AddWithValue("@ProductID", ProductIDtxt.Text);
                cm.Parameters.AddWithValue("@ProductPrice", Pricetxt.Text);
                cm.Parameters.AddWithValue("@ProductQuantity", Quantitytxt.Text);
                cm.Parameters.AddWithValue("@ProductCategory", Categorytxt.Text);
                cm.Parameters.AddWithValue("@ProductImage", Imagetxt.Text);




                cm.ExecuteNonQuery();
                //sqlcon.Close();

                ProductNametxt.Text = "";
                ProductIDtxt.Text = "";
                Pricetxt.Text = "";
                Quantitytxt.Text = "";
                Categorytxt.Text = "";
                Imagetxt.Text = "";

                System.Windows.Forms.MessageBox.Show("Your Product has been Added Successfully", "Addition Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please Re-enter", "Product Addition Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
