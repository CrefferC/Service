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
using System.IO;
using System.Data.OleDb;

namespace Сервис
{
    /// <summary>
    /// Логика взаимодействия для Window_insert.xaml
    /// </summary>
    public partial class Window_insert : Window
    {
        private SqlConnection sqlConnection = null;
        public string connection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\shapo\source\repos\Сервис\Сервис\Database4.mdb";
        public Window_insert()
        {
            InitializeComponent();
            OleDbConnection connect = new OleDbConnection(connection);
            connect.Open();
            OleDbCommand command = new OleDbCommand("SELECT * FROM Make", connect);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    txtMake.Items.Add(reader["Make"].ToString());
                }
            }
            txtYear.ItemsSource = System.IO.File.ReadAllLines(@"1.txt");
            txtModel.Items.Add("Выберите марку");
        }
        private void txtMake_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OleDbConnection connect1 = new OleDbConnection(connection);
            connect1.Open();
            OleDbCommand command1 = new OleDbCommand("SELECT * FROM[Марки и модели] WHERE Make = '" + txtMake.SelectedItem + "'", connect1);
            OleDbDataReader reader1 = command1.ExecuteReader();
            txtModel.Items.Clear();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    txtModel.Items.Add(reader1["Model"].ToString());
                }

            }
        }

        

        
        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if((string.IsNullOrEmpty(txtFirstName.Text)) || ((string.IsNullOrEmpty(txtLastName.Text))) || ((string.IsNullOrEmpty(txtMake.Text))) || ((string.IsNullOrEmpty(txtModel.Text))) || ((string.IsNullOrEmpty(txtYear.Text))) || ((string.IsNullOrEmpty(txtWorks.Text))) || ((string.IsNullOrEmpty(txtSumma.Text)))) MessageBox.Show("Данные не введены");
            else
            {
                if (!re.IsMatch(txtFirstName.Text) || !re.IsMatch(txtFirstName.Text) || !re.IsMatch(txtLastName.Text) || re.IsMatch(txtSumma.Text)) MessageBox.Show("Введите корректные данные");
                else
                {
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"Insert into [Dannie](First_Name, Last_Name,Make,Model,Year,Works,Summa) Values (@First_Name, @Last_Name, @Make, @Model, @Year, @Works, @Summa)", sqlConnection); ;
                    command.Parameters.AddWithValue("First_Name", txtFirstName.Text);
                    command.Parameters.AddWithValue("Last_Name", txtLastName.Text);
                    command.Parameters.AddWithValue("Make", txtMake.Text);
                    command.Parameters.AddWithValue("Model", txtModel.Text);
                    command.Parameters.AddWithValue("Year", txtYear.Text);
                    command.Parameters.AddWithValue("Works", txtWorks.Text);
                    command.Parameters.AddWithValue("Summa", txtSumma.Text);
                    int a = command.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Данные записаны");
                    }
                    txtFirstName.Clear(); txtLastName.Clear(); txtMake.Text = null; txtModel.Text = null; txtYear.Text = null; txtWorks.Clear(); txtSumma.Clear();
                }
            }
        }

        private void previewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            
            if (!re.IsMatch(e.Text))
            { 
                txtFirstName.BorderBrush = Brushes.Red;
            }
        }
        private void PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (!re.IsMatch(e.Text))
            {
                txtLastName.BorderBrush = Brushes.Red;
            }
        }
        private void PreviewTextInput3(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[a-zA-Zа-яА-Я]+");
            if (re.IsMatch(e.Text))
            {
                txtSumma.BorderBrush = Brushes.Red;
            }

        }
    }
}
