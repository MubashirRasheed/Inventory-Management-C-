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
    /// Interaction logic for ManageEmployees.xaml
    /// </summary>
    public partial class ManageEmployees : Window
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        InventoryDatabaseEntities db = new InventoryDatabaseEntities();

        public ManageEmployees()
        {
            InitializeComponent();
            SqlCommand cmd = new SqlCommand("SELECT UserName,Password,Email,PhoneNo,Age,Gender FROM EmployeeTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            EmployeeDataGrid.ItemsSource = dd.DefaultView;
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

        private void EmployeeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = EmployeeDataGrid.SelectedItem as DataRowView;
            if (dr != null)
            {
                Emailtxt.Text = dr["Email"].ToString();
                Numbertxt.Text = dr["PhoneNo"].ToString();

            }

        }
    

    private void Updatebtn_Click(object sender, RoutedEventArgs e)
    {
            try
            {
                using (SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\vp proj\InventoryManagment v0.5db+func\InventoryManagment v0.4db\InventoryManagment\InventoryManagment\InventoryDatabase.mdf;Integrated Security=True"))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd =
                        new SqlCommand("UPDATE EmployeeTable SET Email=@Email, PhoneNo=@phoneNum" 
                           , sqlcon))
                    {

                        cmd.Parameters.AddWithValue("@Email", Emailtxt.Text);
                        cmd.Parameters.AddWithValue("@phoneNum", Numbertxt.Text);
                        
                        int rows = cmd.ExecuteNonQuery();
                        sqlcon.Close();
                        System.Windows.Forms.MessageBox.Show("Employee has been Updated Successfully", "Update Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand asd = new SqlCommand("SELECT Username,Password,Email,PhoneNo,Age,Gender FROM EmployeeTable", sqlcon);
                        DataTable dd = new DataTable();
                        sqlcon.Open();
                        SqlDataReader sdr = asd.ExecuteReader();
                        dd.Load(sdr);
                        sqlcon.Close();
                        EmployeeDataGrid.ItemsSource = dd.DefaultView;

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
            MessageBoxResult msgBoxResult = System.Windows.MessageBox.Show("Are you sure you want to fire the selected employee?",
               "Fire Employee",
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
                            new SqlCommand("DELETE EmployeeTable WHERE Email=@Em"
                               , sqlcon))
                        {

                            cmd.Parameters.AddWithValue("@Em", Emailtxt.Text);

                            int rows = cmd.ExecuteNonQuery();
                            sqlcon.Close();
                            System.Windows.Forms.MessageBox.Show("Employee fired!", "Fired Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            SqlCommand asd = new SqlCommand("SELECT Username,Password,Email,PhoneNo,Age,Gender FROM EmployeeTable", sqlcon);
                            DataTable dd = new DataTable();
                            sqlcon.Open();
                            SqlDataReader sdr = asd.ExecuteReader();
                            dd.Load(sdr);
                            sqlcon.Close();
                            EmployeeDataGrid.ItemsSource = dd.DefaultView;
                        }
                    }
                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Firing failed, Please check the entries!", "Fire Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT UserName,Password,Email,PhoneNo,Age,Gender FROM EmployeeTable", sqlcon);
            DataTable dd = new DataTable();
            sqlcon.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dd.Load(sdr);
            sqlcon.Close();
            EmployeeDataGrid.ItemsSource = dd.DefaultView;
        }
    }
    }

