using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CommonLibrary.SQL_Query
{
    class SQLHelper
    {
        /// <summary>
        /// Lấy thông tin các cột giống nhau giữa 2 bảng
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="table1">Bảng 1</param>
        /// <param name="table2">Bảng 2</param>
        /// <returns></returns>
        public string GetSameColumnsName(string connectionString, string table1, string table2)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = String.Format(@"SELECT STUFF(
                    (SELECT ', ' + ValueColumn
                     FROM (
                         SELECT COLUMN_NAME AS ValueColumn,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH
                         FROM INFORMATION_SCHEMA.COLUMNS
                         WHERE TABLE_NAME = '{0}' AND TABLE_SCHEMA = 'dbo'
                         INTERSECT
                         SELECT COLUMN_NAME,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH
                         FROM INFORMATION_SCHEMA.COLUMNS
                         WHERE TABLE_NAME = '{1}' AND TABLE_SCHEMA = 'dbo'
                     ) AS CommonColumns
                     FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'),
                     1, 2, '') AS All_Columns", table1, table2);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (dataTable.Rows.Count > 0)
                return dataTable.Rows[0]["All_Columns"].ToString();
            return "";
        }
        /// <summary>
        /// Tìm các bảng có cột "columnName"
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public DataTable GetAllTablesHaveColumn(string connectionString, string columnName)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = String.Format(@"select o.name as [table],cd.COLUMN_NAME,cd.DATA_TYPE,cd.COLUMN_DEFAULT, cd.CHARACTER_MAXIMUM_LENGTH from sys.columns c inner join
                    information_schema.columns cd on c.name  =  cd.COLUMN_NAME inner join
                    sys.objects o on c.object_id = o.object_id and cd.TABLE_NAME = o.name
                    where cd.COLUMN_NAME ='{0}'
                    ", columnName);
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dataTable;
        }
    }
}
