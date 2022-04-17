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
    /// Логика взаимодействия для ChoiceTest.xaml
    /// </summary>
    public partial class ChoiceTest : Page
    {
        public Windows.Student_Win student;
        MySqlConnectClass connectClass = new MySqlConnectClass();

        public int idDiscipline;

        public ChoiceTest()
        {
            InitializeComponent();

        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            student.MainFrame.Content = new Pages.ChoiceDiscipline() {student = this.student};
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable table = connectClass.table;
            table.Clear();

            //MessageBox.Show($"{idDiscipline}");

            SqlDataAdapter adapter = new SqlDataAdapter($"Select NameTest from TestTable Where idAcademicSubject = '{idDiscipline}'", MySqlConnectClass.sqlCon);
            adapter.Fill(table);
            SortingTable(table);
            SortingTable(table);
        }
        void SortingTable(DataTable table)
        {
            DataRow row;

            for (int i = 0; i < table.Rows.Count;)
            {
                for (int j = i + 1; j < table.Rows.Count;)
                {
                    if (table.Rows[i][0].ToString() == table.Rows[j][0].ToString())
                    {
                        row = table.Rows[j];
                        table.Rows.Remove(row);
                    }

                    j++;
                }
                i++;
            }
            dataGridView_tests.ItemsSource = table.DefaultView;
        }

        private void ChoiceDiscipline_button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();
            int r = dataGridView_tests.SelectedIndex;

            string nameDiscipline = null;


            for (int i = 0; i < 1;)
            {
                switch (i)
                {

                    case 0:
                        TextBlock itemP = dataGridView_tests.Columns[i].GetCellContent(dataGridView_tests.Items[r]) as TextBlock;
                        nameDiscipline = itemP.Text;
                        break;
                }
                i++;
            }

            student.MainFrame.Content = new Pages.PassingTest_Page() { student = this.student, idSubject = idDiscipline, nameTest = nameDiscipline };
        }
    }
}
