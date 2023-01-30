using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagment
{
    /// <summary>
    /// Interaction logic for CstmRegister.xaml
    /// </summary>
    public partial class CstmRegister : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        public CstmRegister()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)

        {
            

            if (txtUsername.Text == "" || txtUserEmail.Text == "" || txtPassword.Password == "")
            {
                System.Windows.Forms.MessageBox.Show("All fields must be filled.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPassword.Password != null)
            {

                sqlcon.Open();

               

                cm = new SqlCommand("INSERT INTO CustomerTable(Username,Password,Email,PhoneNo)VALUES(@Username,@Password,@Email,@PhoneNo)", sqlcon);
                cm.Parameters.AddWithValue("@Username", txtUsername.Text);
                cm.Parameters.AddWithValue("@Password", txtPassword.Password);
                cm.Parameters.AddWithValue("@Email", txtUserEmail.Text);
                cm.Parameters.AddWithValue("@PhoneNo", Phonetxt.Text);




                cm.ExecuteNonQuery();
                //sqlcon.Close();

                txtUsername.Text = "";
                txtPassword.Password = "";
                txtUserEmail.Text = "";
                Phonetxt.Text = "";

                System.Windows.Forms.MessageBox.Show("Your Account has been Created Successfully", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Customer Dashboard = new Customer();
                Dashboard.Show();
                Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Customer Dashboard = new Customer();
            Dashboard.Show();
            Close();
        }
    }
}
