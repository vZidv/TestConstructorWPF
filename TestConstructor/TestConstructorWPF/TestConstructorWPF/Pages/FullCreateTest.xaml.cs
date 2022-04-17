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

    public partial class FullCreateTest : Page
    {
        public Windows.Teahcer_Win teahcer;
        MySqlConnectClass connectClass = new MySqlConnectClass();

        public int academicSubject;
        public string nameTest;
        public int idTest;
        private int idQuestion = 1;
        private string typeQuestion;

        public FullCreateTest()
        {
            InitializeComponent();        
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            panelTypeChangeAnswer_Sp.Visibility = Visibility.Hidden;
            panelTypeEnter_Sp.Visibility = Visibility.Visible;

            ChangeTypeQuestion_combox.SelectedIndex = 0;
            typeQuestion = "EnterAnswer";
           // MessageBox.Show($"{academicSubject}");
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            teahcer.MainFrame.Content = new Pages.CreateTest_Page() { teahcer = this.teahcer };
        }

  

        private void ChangeTypeQuestion_combox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {       
            if (ChangeTypeQuestion_combox.SelectedIndex == 0)
            {
                panelTypeEnter_Sp.Visibility = Visibility.Visible;
                panelTypeChangeAnswer_Sp.Visibility = Visibility.Hidden;
                typeQuestion = "EnterAnswer";
            }

            else if (ChangeTypeQuestion_combox.SelectedIndex == 1)
            {
                panelTypeChangeAnswer_Sp.Visibility = Visibility.Visible;
                panelTypeEnter_Sp.Visibility = Visibility.Hidden;
                typeQuestion = "ChangeAnswer";
            }
        }



        private void EndCreate_button_Click(object sender, RoutedEventArgs e)
        {
           
            MySqlConnectClass.SqlConnect();
            AddQuestion();
            
            MessageBox.Show($"Тест добавлен!");
        }

        private void newQuestion_button_Click(object sender, RoutedEventArgs e)
        {
            AddQuestion();

            QuestionText_tb.Text = String.Empty;
            idQuestion++;
            TrueAnswerTypeChangeAnswer_tb.Text = String.Empty;
            TrueAnswerTypeEnter_tb.Text = String.Empty;
            falseAnswer1_tb.Text = String.Empty;
            falseAnswer2_tb.Text = String.Empty;
            falseAnswer3_tb.Text = String.Empty;

        }
        void AddQuestion()
        {
            if (typeQuestion == "ChangeAnswer")
            {
                SqlCommand command = new SqlCommand("INSERT INTO TestTable (Id,NameTest,idAcademicSubject,NumberQuestion,QuestionText,AnswerTrue,AnswerFalse1,AnswerFalse2,AnswerFalse3,Type)" +
                    " VALUES (@Id,@NameTest,@idAcademicSubject,@NumberQuestion,@QuestionText,@AnswerTrue,@AnswerFalse1,@AnswerFalse2,@AnswerFalse3,@Type)", MySqlConnectClass.sqlCon);

                command.Parameters.AddWithValue("@Id", idTest);
                command.Parameters.AddWithValue("@NameTest", nameTest);
                command.Parameters.AddWithValue("@idAcademicSubject", academicSubject);
                command.Parameters.AddWithValue("@NumberQuestion", idQuestion);
                command.Parameters.AddWithValue("@QuestionText", QuestionText_tb.Text);
                command.Parameters.AddWithValue("@AnswerTrue", TrueAnswerTypeChangeAnswer_tb.Text);
                command.Parameters.AddWithValue("@AnswerFalse1", falseAnswer1_tb.Text);
                command.Parameters.AddWithValue("@AnswerFalse2", falseAnswer2_tb.Text);
                command.Parameters.AddWithValue("@AnswerFalse3", falseAnswer3_tb.Text);
                command.Parameters.AddWithValue("@Type", typeQuestion);

                command.ExecuteNonQuery();

            }
            else if (typeQuestion == "EnterAnswer")
            {
                SqlCommand command = new SqlCommand("INSERT INTO TestTable (Id,NameTest,idAcademicSubject,NumberQuestion,QuestionText,AnswerTrue,Type)" +
                    " VALUES (@Id,@NameTest,@idAcademicSubject,@NumberQuestion,@QuestionText,@AnswerTrue,@Type)", MySqlConnectClass.sqlCon);

                command.Parameters.AddWithValue("@Id", idTest);
                command.Parameters.AddWithValue("@NameTest", nameTest);
                command.Parameters.AddWithValue("@idAcademicSubject", academicSubject);
                command.Parameters.AddWithValue("@NumberQuestion", idQuestion);
                command.Parameters.AddWithValue("@QuestionText", QuestionText_tb.Text);
                command.Parameters.AddWithValue("@AnswerTrue", TrueAnswerTypeEnter_tb.Text);
                command.Parameters.AddWithValue("@Type", typeQuestion);

                command.ExecuteNonQuery();
            }
        }
    }
}
