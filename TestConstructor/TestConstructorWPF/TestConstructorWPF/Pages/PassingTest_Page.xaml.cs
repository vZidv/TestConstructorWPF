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

    public partial class PassingTest_Page : Page
    {
        public Windows.Teahcer_Win teahcer;
        public Windows.Student_Win student;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        DataTable table = new DataTable();

        public int idSubject;
        public string nameTest;
        
        private int numberQuestion = 0;

        int trueAnswers = 0;
        string Answer = string.Empty;
        public bool isTeacehr = false;
        public PassingTest_Page()
        {
            InitializeComponent();
        }



        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            if (isTeacehr)
            teahcer.MainFrame.Content = new Pages.Tests_Page() { teahcer = this.teahcer };
            else
            student.MainFrame.Content = new Pages.ChoiceDiscipline() { student = this.student };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();

            table = connectClass.table;
            table.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter("Select NameTest,NumberQuestion,QuestionText,AnswerTrue,AnswerFalse1,AnswerFalse2,AnswerFalse3,Type " +
                $"From TestTable where NameTest = N'{nameTest}' ",MySqlConnectClass.sqlCon);

            adapter.Fill(table);

            NextQuestion(table);
        }
        void NextQuestion(DataTable table)
        {
            
            //MessageBox.Show($"Правильных ответов {trueAnswers}");
            numberQuestion += 1;

            if (numberQuestion <= table.Rows.Count)
            {
                int row = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (Convert.ToInt32(table.Rows[i][1]) == numberQuestion)
                    {
                        row = i;
                        break;
                    }
                }
                ThemeTest_textblock.Text = table.Rows[row][0].ToString();
                NumberQuestion_textblock.Text = ($"Вопрос№{table.Rows[row][1].ToString()}");
                QuestionText_textblock.Text = table.Rows[row][2].ToString();
                Answer = table.Rows[row][3].ToString();
                if (table.Rows[row][7].ToString() == "EnterAnswer")
                {
                    enterAnswer_panel.Visibility = Visibility.Visible;
                    ChoiceAnswer_panel.Visibility = Visibility.Hidden;
                }
                else if (table.Rows[row][7].ToString() == "ChangeAnswer")
                {
                    enterAnswer_panel.Visibility = Visibility.Hidden;
                    ChoiceAnswer_panel.Visibility = Visibility.Visible;
                    Random random = new Random();
                    int rand;
                    for (int i = 0; i < 5; i++)
                    {
                        // 3-6
                        //rand = random.Next(0, 4);
                        Answer_Button1.Content = table.Rows[row][3].ToString();
                        Answer_Button2.Content = table.Rows[row][4].ToString();
                        Answer_Button3.Content = table.Rows[row][5].ToString();
                        Answer_Button4.Content = table.Rows[row][6].ToString();
                    }
                }
            }
            else
            {
                enterAnswer_panel.Visibility = Visibility.Hidden;
                ChoiceAnswer_panel.Visibility = Visibility.Hidden;
                ThemeTest_textblock.Text = "Тест завершён!";
                double procent = ( 100/(numberQuestion - 1)) * trueAnswers;
                NumberQuestion_textblock.Text = $"Ваш результат: {procent}%";
                QuestionText_textblock.Text = $"Вы ответилт правильно на {trueAnswers} вопроса из {numberQuestion - 1}.";
                if (!isTeacehr)
                {
                    MySqlConnectClass.SqlConnect();

                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Estimation (idStudent,Estimation,idDiscipline,NameTest) VALUES" +
                        " (@idStudent,@Estimation,@idDiscipline,@NameTest)", MySqlConnectClass.sqlCon);

                    sqlCommand.Parameters.AddWithValue("@idStudent", student.idStudent);
                    sqlCommand.Parameters.AddWithValue("@Estimation", procent);
                    sqlCommand.Parameters.AddWithValue("@idDiscipline", idSubject);
                    sqlCommand.Parameters.AddWithValue("@NameTest", nameTest);

                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Данные сохранены");
                }
            }
        }

        private void Answer_Button1_Click(object sender, RoutedEventArgs e)
        {
            if (Answer_Button1.Content.ToString() == Answer)
                trueAnswers += 1;
            NextQuestion(table);
        }

        private void Answer_Button2_Click(object sender, RoutedEventArgs e)
        {
            if (Answer_Button2.Content.ToString() == Answer)
                trueAnswers += 1;
            NextQuestion(table);
        }

        private void Answer_Button3_Click(object sender, RoutedEventArgs e)
        {
            if (Answer_Button3.Content.ToString() == Answer)
                trueAnswers += 1;
            NextQuestion(table);
        }

        private void Answer_Button4_Click(object sender, RoutedEventArgs e)
        {
            if (Answer_Button4.Content.ToString() == Answer)
                trueAnswers += 1;
            NextQuestion(table);
        }
    }
}
