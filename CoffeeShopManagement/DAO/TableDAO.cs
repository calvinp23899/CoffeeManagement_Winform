using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        #region Singleton
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        #endregion

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        #region public method
        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTabel @idTable1 , @idTabel2", new object[]{id1, id2});
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
        public void UpdateStatusTable(int idTable, int action)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UPDATESTATUSTABLE @idTable , @action", new object[] { idTable, action});
        }

        public void UpdateTable(int idTable, string name, string status)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_UPDATETABLE @idTable , @action , @status", new object[] { idTable, name , status });
        }

        public bool InsertTable(string name, string status)
        {
            string query = string.Format("INSERT dbo.TableFood ( name, status )VALUES  ( N'{0}', N'{1}')", name, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool DeleteTable(string tableName)
        {
            string query = string.Format("Delete TableFood where name = N'{0}'", tableName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        #endregion 
    }
}
