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

    public partial class Tests_Page : Page
    {
        public Windows.Teahcer_Win teahcer;
        MySqlConnectClass connectClass = new MySqlConnectClass();

        public Tests_Page()
        {
            MySqlConnectClass.SqlConnect();
            InitializeComponent();

        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            teahcer.MainFrame.Content = new Pages.TeacherStartMenu_Page() { teahcer = this.teahcer };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable table = connectClass.table;
            table.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Name FROM AdemicSubject WHERE Teacher ='{teahcer.id_teacher}'", MySqlConnectClass.sqlCon);
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count;)
            {
                ChangeAcademicSubject_combox.Items.Add(table.Rows[i][0]);
                i++;
            }
        }
    }
}
