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
using System.Data.SqlClient;
using System.Data;

namespace TestConstructorWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для PassingTest_Page.xaml
    /// </summary>
    public partial class PassingTest_Page : Page
    {
        public Windows.Student_Win student;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        public PassingTest_Page()
        {
            InitializeComponent();
        }



        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            student.MainFrame.Content = new Pages.ChoiceDiscipline() { student = this.student };
        }
    }
}
