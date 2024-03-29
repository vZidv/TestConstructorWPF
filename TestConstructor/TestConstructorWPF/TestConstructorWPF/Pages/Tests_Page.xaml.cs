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

    public partial class Tests_Page : Page
    {
        public Windows.Teahcer_Win teahcer;
        MySqlConnectClass connectClass = new MySqlConnectClass();
        private int idSubject;
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
            #region ComboBoxAdemicSubject
            DataTable table = connectClass.table;
            table.Clear();

            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT NameSubject FROM AdemicSubject WHERE Teacher ='{teahcer.id_teacher}'", MySqlConnectClass.sqlCon);
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count;)
            {
                ChangeAcademicSubject_combox.Items.Add(table.Rows[i][0]);
                i++;
            }
           // ChangeAcademicSubject_combox.SelectedIndex = 0;
            #endregion

            SqlCommand comm = new SqlCommand($"Select id from AdemicSubject where NameSubject = N'{ChangeAcademicSubject_combox.Text}'", MySqlConnectClass.sqlCon);
            idSubject = Convert.ToInt32(comm.ExecuteScalar());
            table.Clear();
            adapter = new SqlDataAdapter($"SELECT TestTable.NameTest,AdemicSubject.NameSubject[idAcademicSubject] " +
                $"FROM TestTable INNER JOIN AdemicSubject ON AdemicSubject.id = TestTable.idAcademicSubject Where TestTable.idAcademicSubject = '{idSubject}'", MySqlConnectClass.sqlCon);
            adapter.Fill(table);
            SortingTable(table);
        }

        private void addTest_button_Click(object sender, RoutedEventArgs e)
        {
            teahcer.MainFrame.Content = new Pages.CreateTest_Page() { teahcer = this.teahcer };
        }

        void SortingTable(DataTable table)
        {
            DataRow row;

            for (int i = 0; i < table.Rows.Count;)
            {
                for (int j = 0; j < table.Rows.Count;)
                {
                    if (j != i)
                    {
                        if (table.Rows[i][0].ToString() == table.Rows[j][0].ToString())
                        {
                            row = table.Rows[j];
                            table.Rows.Remove(row);
                        }
                    }

                    j++;
                }
                i++;
            }
            dataGridView_tests.ItemsSource = table.DefaultView;
        }

        private void ChangeAcademicSubject_combox_DropDownClosed(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand($"Select id from AdemicSubject where NameSubject = N'{ChangeAcademicSubject_combox.Text}'", MySqlConnectClass.sqlCon);
            idSubject = Convert.ToInt32(comm.ExecuteScalar());

            DataTable table = connectClass.table;
            table.Clear();
            SqlDataAdapter adapter2 = new SqlDataAdapter($"SELECT TestTable.NameTest,AdemicSubject.NameSubject[idAcademicSubject] " +
                $"FROM TestTable INNER JOIN AdemicSubject ON AdemicSubject.id = TestTable.idAcademicSubject Where TestTable.idAcademicSubject = '{idSubject}'", MySqlConnectClass.sqlCon);
            adapter2.Fill(table);
            SortingTable(table);
            //MessageBox.Show($"{idSubject}");
        }

        private void editTest_button_Click(object sender, RoutedEventArgs e)
        {
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
            teahcer.MainFrame.Content = new Pages.PassingTest_Page() {teahcer = this.teahcer, isTeacehr = true,nameTest = nameDiscipline};
        }

        private void deleteTest_button_Click(object sender, RoutedEventArgs e)
        {
            int r = dataGridView_tests.SelectedIndex;

            string nameTest = null;
            string subject = null;

            for (int i = 0; i < 2;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = dataGridView_tests.Columns[i].GetCellContent(dataGridView_tests.Items[r]) as TextBlock;
                        nameTest = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = dataGridView_tests.Columns[i].GetCellContent(dataGridView_tests.Items[r]) as TextBlock;
                        subject = itemP.Text;
                        break;
                }
                i++;
            }
            MySqlConnectClass.SqlConnect();
           // MessageBox.Show($"{nameTest}");
            SqlDataAdapter adapter3 = new SqlDataAdapter($"Select id from TestTable where NameTest = N'{nameTest}'", MySqlConnectClass.sqlCon);
            DataTable tab = new DataTable();
            adapter3.Fill(tab);
           // MessageBox.Show($"{tab.Rows.Count}");
            for (int i = 0; i <= tab.Rows.Count - 1; )
            {
                SqlCommand command = new SqlCommand($"DELETE FROM TestTable WHERE NameTest = N'{nameTest}' ", MySqlConnectClass.sqlCon);
                command.ExecuteNonQuery();
                i++;
            }
            

             MessageBox.Show("Тест удалён!");
        }
    }
}
