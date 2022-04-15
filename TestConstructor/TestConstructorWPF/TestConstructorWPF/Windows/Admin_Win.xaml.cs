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

namespace TestConstructorWPF.Windows
{
    /// <summary>
    /// Логика взаимодействия для Admin_Win.xaml
    /// </summary>
    public partial class Admin_Win : Window
    {
        public Admin_Win()
        {
            InitializeComponent();
            MainFrame.Content = new Pages.AdminMain_Page() { admin = this };
        }
    }
}
