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
    /// Логика взаимодействия для AddUser_Page.xaml
    /// </summary>
    public partial class AddUser_Page : Page
    {
        public Windows.Admin_Win admin;
        public AddUser_Page()
        {
            InitializeComponent();
        }

        private void backToMainMenu_button_Click(object sender, RoutedEventArgs e)
        {
            admin.MainFrame.Content = new Pages.AdminMain_Page() { admin = this.admin };
        }

        private void adminAddNewPerson_button_Click(object sender, RoutedEventArgs e)
        {
            if (login_textbox.Text == String.Empty || login_textbox.Text == String.Empty)
            {
                MessageBox.Show("Одна из строчек пуста!", "Ошибка");
            }
            else
            {
                MySqlConnectClass.SqlConnect();

                SqlCommand sqlCommand = new SqlCommand("INSERT INTO UserTable (Login,Password,Type,UserName,Surname,Secondname) VALUES (@Login,@Password,@Type,@UserName,@Surname,@Secondname)", MySqlConnectClass.sqlCon);

                sqlCommand.Parameters.AddWithValue("@Login", login_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@Password", Password_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@Type", TypeUser_comboBox.Text);
                sqlCommand.Parameters.AddWithValue("@UserName", name_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@Surname", surname_textbox.Text);
                sqlCommand.Parameters.AddWithValue("@Secondname", secondname_textbox.Text);



                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Пользователь добавлен!", "Сообщение");
            }
        }

        private void TypeUser_comboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
