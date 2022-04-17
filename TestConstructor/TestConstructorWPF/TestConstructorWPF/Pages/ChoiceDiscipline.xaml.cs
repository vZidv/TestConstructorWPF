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

    public partial class ChoiceDiscipline : Page
    {
        public Windows.Student_Win student;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        public ChoiceDiscipline()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            connectClass.LoadTable("Select NameSubject,Description from AdemicSubject", dataGridView_Discipline);
        }

        private void backToAuthorization_button_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            student.Close();
        }

        private void ChoiceDiscipline_button_Click(object sender, RoutedEventArgs e)
        {
            int r = dataGridView_Discipline.SelectedIndex;

            string nameDiscipline = null;
            string description = null;


            for (int i = 0; i < 3;)
            {
                switch (i)
                {

                    case 0:
                        TextBlock itemP = dataGridView_Discipline.Columns[i].GetCellContent(dataGridView_Discipline.Items[r]) as TextBlock;
                        nameDiscipline = itemP.Text;
                        break;
                    case 1:
                        TextBlock itemG = dataGridView_Discipline.Columns[i].GetCellContent(dataGridView_Discipline.Items[r]) as TextBlock;
                        description = itemG.Text;
                        break;
                }
                i++;
            }

           // MessageBox.Show($"nAME  {nameDiscipline}");
            MySqlConnectClass.SqlConnect();

            SqlCommand command = new SqlCommand($"Select id from AdemicSubject where NameSubject = N'{nameDiscipline}'", MySqlConnectClass.sqlCon);

            student.MainFrame.Content = new Pages.ChoiceTest() { idDiscipline = Convert.ToInt32(command.ExecuteScalar()),student = this.student};
        }

        private void refresh_button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grade_button_Click(object sender, RoutedEventArgs e)
        {
            student.MainFrame.Content = new Pages.GradesStrudent_Page() { student = this.student};
        }
    }
}
