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
    /// Логика взаимодействия для CreateTest_Page.xaml
    /// </summary>
    public partial class CreateTest_Page : Page
    {
        public Windows.Teahcer_Win teahcer;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        public CreateTest_Page()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable table = connectClass.table;
            table.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT NameSubject FROM AdemicSubject WHERE Teacher ='{teahcer.id_teacher}'", MySqlConnectClass.sqlCon);
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count;)
            {
                ChangeAcademicSubject_combox.Items.Add(table.Rows[i][0]);
                i++;
            }
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            teahcer.MainFrame.Content = new Pages.Tests_Page() { teahcer = this.teahcer };
        }

        private void CreateTest_button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();
            DataTable dataTable = connectClass.table;
            dataTable.Clear();

            SqlCommand command = new SqlCommand("Select MAX(id) From TestTable",MySqlConnectClass.sqlCon);
            int id = 0;
            if (Convert.ToInt32(command.ExecuteScalar()) == 0)
            {
                id = 1;
            }
            else if (Convert.ToInt32(command.ExecuteScalar()) >= 1)
            {
                id = Convert.ToInt32(command.ExecuteScalar()) + 1;
            }

            //MessageBox.Show($"{id}");
            SqlCommand comm = new SqlCommand($"Select id from AdemicSubject where NameSubject = N'{ChangeAcademicSubject_combox.Text}'", MySqlConnectClass.sqlCon);
            //MessageBox.Show($"{id}");
            teahcer.MainFrame.Content = new Pages.FullCreateTest() { teahcer = this.teahcer,nameTest = Name_tb.Text,academicSubject = Convert.ToInt32(comm.ExecuteScalar()),idTest = id };
        }
    }
}
