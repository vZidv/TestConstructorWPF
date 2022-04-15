using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;

namespace TestConstructorWPF
{
    class MySqlConnectClass
    {
        public static SqlConnection sqlCon;
        public SqlDataAdapter adapter;
        public DataTable table = new DataTable();
        public DataSet datSet = new DataSet();

        public static void SqlConnect()
        {
            sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Артём\Проекты и их материалы\TestConstructorRepos\TestConstructorWPF\TestConstructor\TestConstructorWPF\TestConstructorWPF\TestConstructor.mdf;Integrated Security=True");
            sqlCon.Open();
        }
        public void LoadTable(string command, DataGrid dataGrid)
        {
            table.Clear();
            SqlConnect();
            adapter = new SqlDataAdapter(command, sqlCon);
            adapter.Fill(table);
            dataGrid.ItemsSource = table.DefaultView;
        }
    }
}
