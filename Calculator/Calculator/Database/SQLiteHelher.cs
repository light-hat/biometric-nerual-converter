using Calculator.AdditionalModules;
using System;
using System.Data.SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Database
{
    public class SQLiteHelher
    {
        /// <summary>
        /// Взаимодействие со sqlite-файлом
        /// </summary>
        /// <param name="file_path">Путь до обрабатываемого файла</param>
        public SQLiteHelher(string file_path)
        {
            _sqlite_path = file_path;

            sqlCmd = new SQLiteCommand();
        }

        /// <summary>
        /// Создание новой базы данных
        /// </summary>
        public void createNewDB()
        {
            try
            {
                if (!File.Exists(_sqlite_path))
                    SQLiteConnection.CreateFile(_sqlite_path);

                dbConn = new SQLiteConnection("Data Source=" + _sqlite_path + ";Version=3;");
                dbConn.Open();
                sqlCmd.Connection = dbConn;

                sqlCmd.CommandText = "CREATE TABLE IF NOT EXISTS test_table (id INTEGER PRIMARY KEY AUTOINCREMENT, hammdists TEXT, book TEXT)";
                sqlCmd.ExecuteNonQuery();
            }

            catch (SQLiteException e)
            {
                ErrorHandler.showErrorMessage("database exception: " + e.Message + '\n' + e.StackTrace);
            }
        }

        /// <summary>
        /// Чтение данных из базы
        /// </summary>
        public void readDB()
        {
            try
            {
                // ...
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }
        }

        /// <summary>
        /// Запись данных в базу
        /// </summary>
        public void writeDB()
        {
            try
            {
                // ...
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }
        }

        private string _sqlite_path;

        private SQLiteConnection dbConn;

        private SQLiteCommand sqlCmd;
    }
}
