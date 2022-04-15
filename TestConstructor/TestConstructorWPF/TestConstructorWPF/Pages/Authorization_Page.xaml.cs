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
    /// Логика взаимодействия для Authorization_Page.xaml
    /// </summary>
    public partial class Authorization_Page : Page
    {
        public Authorization autorizationWindow;
        DataTable table = new DataTable();
        public Authorization_Page()
        {
            InitializeComponent();
        }

        private void authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();
            if (login_Textbox.Text == String.Empty || password_Textbox.Text == String.Empty)
            {
                MessageBox.Show("Одна из строчек пуста!", "Ошибка");
            }
            else
            {
                table.Clear();

                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM UserTable WHERE Login = '{login_Textbox.Text}' AND Password = '{password_Textbox.Text}'", MySqlConnectClass.sqlCon);
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0][6].ToString() == "admin")
                    {
                        Windows.Admin_Win admin = new Windows.Admin_Win();
                        admin.Show();
                    }
                    else if (table.Rows[0][6].ToString() == "teacher")
                    {
                        SqlCommand command = new SqlCommand($"SELECT id FROM UserTable WHERE Login = '{login_Textbox.Text}' AND Password = '{password_Textbox.Text}' AND Type='teacher'", MySqlConnectClass.sqlCon);
                        Windows.Teahcer_Win teahcer = new Windows.Teahcer_Win() { id_teacher = Convert.ToInt32(command.ExecuteScalar())};
                        teahcer.Show();
                    }
                    autorizationWindow.Close();
                }
                else
                {
                    MessageBox.Show("Неверный ввод данных!", "Ошибка");
                }
            }
        }
    }
}
