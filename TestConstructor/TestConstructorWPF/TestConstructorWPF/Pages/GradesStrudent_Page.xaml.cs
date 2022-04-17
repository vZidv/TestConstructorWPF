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
    /// Логика взаимодействия для GradesStrudent_Page.xaml
    /// </summary>
    public partial class GradesStrudent_Page : Page
    {
        public Windows.Student_Win student;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        public GradesStrudent_Page()
        {
            InitializeComponent();
        }

        private void back_button_Click(object sender, RoutedEventArgs e)
        {
            student.MainFrame.Content = new Pages.ChoiceDiscipline() { student = this.student };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();
            connectClass.LoadTable($"Select AdemicSubject.NameSubject[idDiscipline],Estimation.NameTest,Estimation.Estimation" +
                $" from Estimation INNER JOIN AdemicSubject ON AdemicSubject.id = Estimation.id where idStudent = '{student.idStudent}'",dataGridView_estimation);
        }
    }
}
