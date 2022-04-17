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

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {
            connectClass.LoadTable("Select Login,Password,Type From UserTable", dataGridView_Users);
        }

        private void deletePerson_button_Click(object sender, RoutedEventArgs e)
        {
            int r = dataGridView_Users.SelectedIndex;

            string login = null;
            string password = null;

            for (int i = 0; i < 2;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = dataGridView_Users.Columns[i].GetCellContent(dataGridView_Users.Items[r]) as TextBlock;
                        login = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = dataGridView_Users.Columns[i].GetCellContent(dataGridView_Users.Items[r]) as TextBlock;
                        password = itemP.Text;
                        break;
                }
                i++;
            }
            MySqlConnectClass.SqlConnect();
            SqlCommand command = new SqlCommand($"DELETE FROM UserTable WHERE Login = N'{login}' and Password ='{password}'", MySqlConnectClass.sqlCon);
            command.ExecuteNonQuery();
            MessageBox.Show("Пользователь удалён!");
        }
    }
}
