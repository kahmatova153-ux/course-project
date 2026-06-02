using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WatchRepairApp
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Server=DESKTOP-JO2O3M6;Database=WatchRepairDB;Trusted_Connection=True;";

        /// <summary>
        /// Получить новое подключение к БД
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Выполнить SELECT запрос (получение данных)
        /// Возвращает таблицу с результатами
        /// </summary>
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }
        public static DataTable GetSimpleOrders()
        {
            return ExecuteQuery("SELECT * FROM vw_OrdersSimple");
        }

        // Простой метод для процедуры
        public static DataTable GetOrderCounts(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_CountOrdersByStatus", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DateFrom", fromDate);
                    cmd.Parameters.AddWithValue("@DateTo", toDate);
                    new SqlDataAdapter(cmd).Fill(dt);
                }
            }
            return dt;
        }
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении операции: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static int ArchiveOldOrders()
        {
            string query = @"
        -- Удаляем связанные расходы
        DELETE FROM Expenses 
        WHERE RelatedOrderID IN (
            SELECT o.OrderID FROM Orders o
            JOIN OrderStatuses os ON o.StatusID = os.StatusID
            WHERE os.StatusName IN ('Готов', 'Выдан')
            AND o.ActualCompletionDate IS NOT NULL
            AND DATEADD(MONTH, o.WarrantyMonths, o.ActualCompletionDate) < GETDATE()
        );

        DELETE op FROM OrderParts op
        WHERE EXISTS (
            SELECT 1 FROM Orders o
            JOIN OrderStatuses os ON o.StatusID = os.StatusID
            WHERE o.OrderID = op.OrderID
            AND os.StatusName IN ('Готов', 'Выдан')
            AND o.ActualCompletionDate IS NOT NULL
            AND DATEADD(MONTH, o.WarrantyMonths, o.ActualCompletionDate) < GETDATE()
        );

        DELETE ow FROM OrderWorks ow
        WHERE EXISTS (
            SELECT 1 FROM Orders o
            JOIN OrderStatuses os ON o.StatusID = os.StatusID
            WHERE o.OrderID = ow.OrderID
            AND os.StatusName IN ('Готов', 'Выдан')
            AND o.ActualCompletionDate IS NOT NULL
            AND DATEADD(MONTH, o.WarrantyMonths, o.ActualCompletionDate) < GETDATE()
        );

        DELETE p FROM Payments p
        WHERE EXISTS (
            SELECT 1 FROM Orders o
            JOIN OrderStatuses os ON o.StatusID = os.StatusID
            WHERE o.OrderID = p.OrderID
            AND os.StatusName IN ('Готов', 'Выдан')
            AND o.ActualCompletionDate IS NOT NULL
            AND DATEADD(MONTH, o.WarrantyMonths, o.ActualCompletionDate) < GETDATE()
        );

        DELETE o FROM Orders o
        JOIN OrderStatuses os ON o.StatusID = os.StatusID
        WHERE os.StatusName IN ('Готов', 'Выдан')
        AND o.ActualCompletionDate IS NOT NULL
        AND DATEADD(MONTH, o.WarrantyMonths, o.ActualCompletionDate) < GETDATE();

        SELECT @@ROWCOUNT;";

            object result = ExecuteScalar(query);
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}