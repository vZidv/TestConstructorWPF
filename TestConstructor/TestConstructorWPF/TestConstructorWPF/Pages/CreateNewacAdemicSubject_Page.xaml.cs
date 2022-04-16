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
using System.Data;
using System.Data.SqlClient;

namespace TestConstructorWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateNewacAdemicSubject_Page.xaml
    /// </summary>
    public partial class CreateNewacAdemicSubject_Page : Page
    {
        public Windows.Teahcer_Win teahcer;
        MySqlConnectClass connectClass = new MySqlConnectClass();

        public CreateNewacAdemicSubject_Page()
        {
            InitializeComponent();
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
           teahcer.MainFrame.Content = new Pages.TeacherStartMenu_Page() { teahcer = this.teahcer };
        }

        private void addAdemicSubject_button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();

            SqlCommand command = new SqlCommand("INSERT INTO AdemicSubject (NameSubject,Description,Teacher) VALUES (@NameSubject,@Description,@Teacher)", MySqlConnectClass.sqlCon);

            command.Parameters.AddWithValue("@NameSubject", Name_tb.Text);
            command.Parameters.AddWithValue("@Description", description_tb.Text);
            command.Parameters.AddWithValue("@Teacher", teahcer.id_teacher);

            command.ExecuteNonQuery();
            MessageBox.Show("Дисциплина", "Добавлена");
        }
    }
}
