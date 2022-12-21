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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Сервис
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Show taskWindow = new Show();
            taskWindow.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Window_insert taskWindow = new Window_insert();
            taskWindow.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Window_update taskWindow = new Window_update();
            taskWindow.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Window1 taskWindow = new Window1();
            taskWindow.Show();
        }        
    }
}
