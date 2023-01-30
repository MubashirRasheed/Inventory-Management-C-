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
using System.Data;

namespace InventoryManagment
{
    
    public partial class EmpRegister : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();

        public EmpRegister()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int age = Convert.ToInt32(txtAge.Text);
            string gender = "Male";

            if (txtUsernameEmp.Text == "" || txtPasswordEmp.Password == "" || txtUserEmailEmp.Text == "" || Convert.ToString(txtUserNumberEmp.Text) == "" || Convert.ToString(txtAge) == "")
            {
                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("All fields must be filled!", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else if (age < 18)
            {

                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Age cannot be below 18.", "Age error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            else
            {
                
                    sqlcon.Open();
                var item = (ComboBoxItem)preNumber.SelectedValue;
                var contact = (string)item.Content + txtUserNumberEmp.Text;

                if (RBFemale.IsChecked == true)
                {
                    gender = "Female";
                }



                cm = new SqlCommand("INSERT INTO EmployeeTable(Username,Password,Email,PhoneNo,Age,Gender)VALUES(@Username,@Password,@Email,@PhoneNo,@Age,@Gender)", sqlcon);
                cm.Parameters.AddWithValue("@Username", txtUsernameEmp.Text);
                cm.Parameters.AddWithValue("@Password", txtPasswordEmp.Password);
                cm.Parameters.AddWithValue("@Email", txtUserEmailEmp.Text);
                cm.Parameters.AddWithValue("@PhoneNo", contact);
                cm.Parameters.AddWithValue("@Age", txtAge.Text);
                cm.Parameters.AddWithValue("@Gender", gender);


                cm.ExecuteNonQuery();


                MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Your Account has been Created Successfully", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);

                Employee dashboard = new Employee();
                dashboard.Show();
                Close();
            }


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Employee Dashboard = new Employee();
            Dashboard.Show();
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

  
    }
}
