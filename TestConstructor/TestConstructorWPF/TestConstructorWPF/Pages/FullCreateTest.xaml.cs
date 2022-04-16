﻿using System;
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

        public FullCreateTest()
        {
            InitializeComponent();        
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            panelTypeChangeAnswer_Sp.Visibility = Visibility.Hidden;
            panelTypeEnter_Sp.Visibility = Visibility.Visible;

            ChangeTypeQuestion_combox.SelectedIndex = 0;

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
            }

            else if (ChangeTypeQuestion_combox.SelectedIndex == 1)
            {
                panelTypeChangeAnswer_Sp.Visibility = Visibility.Visible;
                panelTypeEnter_Sp.Visibility = Visibility.Hidden;
            }
        }



        private void EndCreate_button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnectClass.SqlConnect();

            //SqlCommand command = new SqlCommand("INSERT INTO TestTable (Id,NameTest,idAcademicSubject,NumberQuestion,QuestionText,AnswerTrue,AnswerFalse1,AnswerFalse2,AnswerFalse3,Type)" +
            //    " VALUES (@Id,@NameTest,@idAcademicSubject,@NumberQuestion,@QuestionText,@AnswerTrue,@AnswerFalse1,@AnswerFalse2,@AnswerFalse3,@Type)");

            //command.Parameters.AddWithValue("Id", idTest);
            //command.Parameters.AddWithValue("NameTest", nameTest);
            //command.Parameters.AddWithValue("idAcademicSubject",);
            //command.Parameters.AddWithValue("Id", idTest);
            //command.Parameters.AddWithValue("Id", idTest);
            //command.Parameters.AddWithValue("Id", idTest);
            //command.Parameters.AddWithValue("Id", idTest);
        }
    }
}
