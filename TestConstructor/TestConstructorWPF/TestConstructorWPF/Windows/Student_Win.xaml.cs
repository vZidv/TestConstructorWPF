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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace TestConstructorWPF.Windows
{

    public partial class Student_Win : Window
    {
        public int idStudent;
        public Student_Win()
        {
            InitializeComponent();
            MainFrame.Content = new Pages.ChoiceDiscipline() {student = this};
        }
    }
}
