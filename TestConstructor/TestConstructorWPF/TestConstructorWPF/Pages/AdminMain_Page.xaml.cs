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

namespace TestConstructorWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminMain_Page.xaml
    /// </summary>
    public partial class AdminMain_Page : Page
    {
       public Windows.Admin_Win admin;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        public AdminMain_Page()
        {
            InitializeComponent();
            connectClass.LoadTable("Select Login,Password,Type From UserTable", dataGridView_Users);
            
        }

        private void addPerson_button_Click(object sender, RoutedEventArgs e)
        {
            admin.MainFrame.Content = new Pages.AddUser_Page() { admin = this.admin };
        }

        private void backToAuthorization_button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            admin.Close();
        }
    }
}
