using System;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventoryManagment
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
       
        public Register()
        {
            InitializeComponent();
        }
  

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsernameManager.Text == "" || txtPasswordManager.Password == "" || txtUserEmailManager.Text == "" || Convert.ToString( txtUserNumberManager.Text)=="")
            {
                System.Windows.Forms.MessageBox.Show("All fields must be filled.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtPasswordManager.Password != null)
            {
               
               sqlcon.Open();

                var item = (ComboBoxItem)preNumber.SelectedValue;
                var contact = (string)item.Content + txtUserNumberManager.Text;

                cm = new SqlCommand("INSERT INTO ManagerTable(Username,Password,Email,PhoneNo)VALUES(@Username,@Password,@Email,@PhoneNo)", sqlcon);
                cm.Parameters.AddWithValue("@Username", txtUsernameManager.Text);
                cm.Parameters.AddWithValue("@Password", txtPasswordManager.Password);
                cm.Parameters.AddWithValue("@Email", txtUserEmailManager.Text);
                cm.Parameters.AddWithValue("@PhoneNo",contact);
                



                cm.ExecuteNonQuery();
                //sqlcon.Close();

                txtUsernameManager.Text = "";
                txtPasswordManager.Password = "";
                txtUserEmailManager.Text = "";
                txtUserNumberManager.Text = "";

                System.Windows.Forms.MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Manager sc = new Manager();
                sc.Show();
                Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager Dashboard = new Manager();
            Dashboard.Show();
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

       
    }
}
