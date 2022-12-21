using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
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

namespace Сервис
{
    /// <summary>
    /// Логика взаимодействия для Window_update.xaml
    /// </summary>
    public partial class Window_update : Window
    {
        private SqlConnection sqlConnection = null;
        public Window_update()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Dannie", sqlConnection);
            DataTable dt = new DataTable("Dannie");
            adapter.Fill(dt);
            dataGrid2.ItemsSource = dt.DefaultView;
        }
        private void show()
        {
            txtFirstName_up.Visibility = Visibility.Visible;
            txtLastName_up.Visibility = Visibility.Visible;
            txtMake_up.Visibility = Visibility.Visible;
            txtModel_up.Visibility = Visibility.Visible;
            txtYear_up.Visibility = Visibility.Visible;
            txtWorks_up.Visibility = Visibility.Visible;
            txtUpdate.Visibility = Visibility.Visible;
            txtSumma_up.Visibility = Visibility.Visible; 
            l1.Visibility = Visibility.Visible; 
            l2.Visibility = Visibility.Visible; 
            l3.Visibility = Visibility.Visible; 
            l4.Visibility = Visibility.Visible; 
            l5.Visibility = Visibility.Visible; 
            l6.Visibility = Visibility.Visible; 
            l7.Visibility = Visibility.Visible;
            l8.Visibility = Visibility.Visible;
        }
        private void no_show()
        {
            txtFirstName_up.Visibility = Visibility.Hidden;
            txtLastName_up.Visibility = Visibility.Hidden;
            txtMake_up.Visibility = Visibility.Hidden;
            txtModel_up.Visibility = Visibility.Hidden;
            txtYear_up.Visibility = Visibility.Hidden;
            txtWorks_up.Visibility = Visibility.Hidden;
            txtUpdate.Visibility = Visibility.Hidden;
            txtSumma_up.Visibility = Visibility.Hidden;
            l1.Visibility = Visibility.Hidden;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
            l5.Visibility = Visibility.Hidden;
            l6.Visibility = Visibility.Hidden;
            l7.Visibility = Visibility.Hidden;
            l8.Visibility = Visibility.Hidden;
        }
        private void cleaning()
        {
            txtUpdate.Clear(); txtFirstName_up.Clear(); txtLastName_up.Clear(); txtMake_up.Clear(); txtModel_up.Clear(); txtYear_up.Clear(); txtWorks_up.Clear(); txtSumma_up.Clear();

        }

        private void btn_Show1_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Dannie", sqlConnection);
            DataTable dt = new DataTable("Dannie");
            adapter.Fill(dt);
            dataGrid2.ItemsSource = dt.DefaultView;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
        }

        private void btn_Delite_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM  [Dannie] where [Id]= '"+((DataRowView)dataGrid2.SelectedItem).Row[0].ToString()+ "'", sqlConnection);
            command.ExecuteNonQuery();
            sqlConnection.Close();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Dannie", sqlConnection);
            DataTable dt = new DataTable("Dannie");
            adapter.Fill(dt);
            dataGrid2.ItemsSource = dt.DefaultView;
            MessageBox.Show("Данные удалены");

        }
        
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            show();
            txtUpdate.Text = ((DataRowView)dataGrid2.SelectedItem).Row[0].ToString();
            txtFirstName_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[1].ToString();
            txtLastName_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[2].ToString();
            txtMake_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[3].ToString();
            txtModel_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[4].ToString();
            txtYear_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[5].ToString();
            txtWorks_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[6].ToString();
            txtSumma_up.Text = ((DataRowView)dataGrid2.SelectedItem).Row[7].ToString();
        }
        private void Update_save_Click(object sender, RoutedEventArgs e)
        {
            
                if (((string.IsNullOrEmpty(txtFirstName_up.Text))) || ((string.IsNullOrEmpty(txtLastName_up.Text))) || ((string.IsNullOrEmpty(txtMake_up.Text))) || ((string.IsNullOrEmpty(txtModel_up.Text))) || ((string.IsNullOrEmpty(txtYear_up.Text))) || ((string.IsNullOrEmpty(txtWorks_up.Text))) || ((string.IsNullOrEmpty(txtSumma_up.Text)))) MessageBox.Show("Данные не введены");
                else
                {
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand("UPDATE [Dannie] set First_Name = @First_Name,  Last_Name = @Last_Name, Make =@Make, Model =@Model, Year = @Year, Works =@Works, Summa =@Summa where [Id] = '" + txtUpdate.Text + "'", sqlConnection);
                    command.Parameters.AddWithValue("@First_Name", txtFirstName_up.Text);
                    command.Parameters.AddWithValue("@Last_Name", txtLastName_up.Text);
                    command.Parameters.AddWithValue("@Make", txtMake_up.Text);
                    command.Parameters.AddWithValue("@Model", txtModel_up.Text);
                    command.Parameters.AddWithValue("@Year", txtYear_up.Text);
                    command.Parameters.AddWithValue("@Works", txtWorks_up.Text);
                    command.Parameters.AddWithValue("@Summa", txtSumma_up.Text);
                    command.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * From Dannie", sqlConnection);
                    DataTable dt = new DataTable("Dannie");
                    adapter.Fill(dt);
                    dataGrid2.ItemsSource = dt.DefaultView;
                    MessageBox.Show("Данные изменены");
                    cleaning();
                    no_show();
                }
            
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("UPDATE [Dannie] set First_Name = @First_Name,  Last_Name = @Last_Name, Make =@Make, Model =@Model, Year = @Year, Works =@Works, Summa =@Summa where [Id] = '" + txtUpdate.Text + "'", sqlConnection);
        }

        private void previewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");

            if (!re.IsMatch(e.Text))
            {
                txtFirstName_up.Background = Brushes.Red;
            }
            else
            {

                txtFirstName_up.Background = Brushes.White;
            }

        }
        private void PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (!re.IsMatch(e.Text))
            {
                txtLastName_up.Background = Brushes.Red;
            }
            else
            {
                txtLastName_up.Background = Brushes.White;
            }

        }
        private void PreviewTextInput3(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtSumma_up.Background = Brushes.Red;
            }
            else
            {
                txtSumma_up.Background = Brushes.White;
            }

        }

        private void PreviewTextInput1(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtYear_up.Background = Brushes.Red;
            }
            else
            {
                txtYear_up.Background = Brushes.White;
            }

        }
    }
}
