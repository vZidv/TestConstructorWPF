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
    
    public partial class TeacherStartMenu_Page : Page
    {
        public Windows.Teahcer_Win teahcer;
        
        MySqlConnectClass connectClass = new MySqlConnectClass();
        public TeacherStartMenu_Page()
        {
            InitializeComponent();
        }

        private void backToAuthorization_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            authorization.Show();
            teahcer.Close();
        }

        private void CreateNewacAdemicSubject_Page_Click(object sender, RoutedEventArgs e)
        {
            teahcer.MainFrame.Content = new Pages.CreateNewacAdemicSubject_Page() { teahcer = this.teahcer };
        }

        private void TestsMenu_Click(object sender, RoutedEventArgs e)
        {
            teahcer.MainFrame.Content = new Pages.Tests_Page() {teahcer = this.teahcer};
        }
    }
}
