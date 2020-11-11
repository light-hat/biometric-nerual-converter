using Calculator.AdditionalModules;
using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Calculator.Database
{
    /// <summary>
    /// Взаимодействие со sqlite-файлом
    /// </summary>
    public class SQLiteHelper
    {
        #region Конструктор
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="file_path">Путь до обрабатываемого файла</param>
        public SQLiteHelper(string file_path)
        {
            _sqlite_path = file_path;

            sqlCmd = new SQLiteCommand();
        }

        #endregion

        #region Публичные методы класса

        /// <summary>
        /// Чтение данных из базы
        /// </summary>
        public void readDB()
        {
            try
            {
                switch (File.Exists(_sqlite_path))
                {
                    case true:
                        {
                            // TODO
                        }

                        break;

                    case false:
                        ErrorHandler.showErrorMessage("Что-то пошло не так: файла базы данных не существует");

                        break;
                }
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }
        }

        /// <summary>
        /// Подготовка базы данных. При необходимости создаёт файл, занимается обустройством таблицы и пр.
        /// </summary>
        /// <param name="column_names">Названия столбцов таблицы, стандартное отклонение расстояний Хэмминга</param>
        public void preparateTable(string[] column_names)
        {
            try
            {
                switch (File.Exists(_sqlite_path))
                {
                    case true:
                        reloadDB(column_names); // Если файл базы существует - перезаписываем в нём таблицу
                        break;

                    case false:
                        createNewDB(column_names); // Если нет файла базы данных - создаём его
                        break;
                }
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }
        }

        /// <summary>
        /// Запись остальных табличных данных в подготовленную таблицу
        /// </summary>
        /// <param name="tableData">Остальные табличные данные</param>
        /// <param name="row_count">Количество строк в передаваемой таблице</param>
        /// <param name="col_count">Общее количество передаваемых столбцов</param>
        public void writeDataInDB(string[,] tableData, int row_count, int col_count)
        {
            try
            {
                string request_part = null;

                for (int i = 0; i < row_count; i++)
                {
                    request_part += string.Format("'{0}'", tableData[i, 0]);

                    for (int j = 1; j < col_count; j++)
                    {
                        request_part += string.Format(", '{0}'", tableData[i, j]);
                    }

                    sqlCmd.CommandText = string.Format("INSERT INTO test_table ({0}) values ({1})", _current_table_col_names, request_part);
                    sqlCmd.ExecuteNonQuery();

                    request_part = "";
                }
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }
        }

        #endregion

        #region Закрытые методы класса

        /// <summary>
        /// Создание и сохранение новой базы данных
        /// </summary>
        /// <param name="column_names">Названия столбцов таблицы, стандартное отклонение расстояний Хэмминга</param>
        private void createNewDB(string[] column_names)
        {
            try
            {
                string command_col_names = "";

                foreach (string column in column_names)
                    command_col_names += string.Format(", c{0} TEXT", column);

                string tmp_col_names = "";

                tmp_col_names += "'id'";
                tmp_col_names += ", 'hammdists'";

                foreach (string col in column_names)
                    tmp_col_names += string.Format(", 'c{0}'", col);

                _current_table_col_names = tmp_col_names;

                if (!File.Exists(_sqlite_path))
                    SQLiteConnection.CreateFile(_sqlite_path);

                dbConn = new SQLiteConnection("Data Source=" + _sqlite_path + ";Version=3;");
                dbConn.Open();
                sqlCmd.Connection = dbConn;

                sqlCmd.CommandText = string.Format("CREATE TABLE IF NOT EXISTS test_table (id INTEGER PRIMARY KEY AUTOINCREMENT, hammdists TEXT {0})", command_col_names);
                sqlCmd.ExecuteNonQuery();
            }

            catch (SQLiteException e)
            {
                ErrorHandler.showErrorMessage("database exception: " + e.Message + '\n' + e.StackTrace);
            }
        }

        /// <summary>
        /// Обновление существующей базы данных, открытой в данный момент времени.
        /// Пока под этим имеется в виду обычная перезапись. Полностью перезаписываем таблицу
        /// из-за того, что может меняться количество и заголовки столбцов.
        /// </summary>
        /// <param name="column_names"></param>
        private void reloadDB(string[] column_names)
        {
            // 
            sqlCmd.CommandText = string.Format("DROP TABLE IF EXISTS test_table");
            sqlCmd.ExecuteNonQuery();

            string command_col_names = "";

            foreach (string column in column_names)
                command_col_names += string.Format(", c{0} TEXT", column);

            string tmp_col_names = "";

            tmp_col_names += "'id'";
            tmp_col_names += ", 'hammdists'";

            foreach (string col in column_names)
                tmp_col_names += string.Format(", 'c{0}'", col);

            _current_table_col_names = tmp_col_names;

            if (!File.Exists(_sqlite_path))
                SQLiteConnection.CreateFile(_sqlite_path);

            dbConn = new SQLiteConnection("Data Source=" + _sqlite_path + ";Version=3;");
            dbConn.Open();
            sqlCmd.Connection = dbConn;

            sqlCmd.CommandText = string.Format("CREATE TABLE test_table (id INTEGER PRIMARY KEY AUTOINCREMENT, hammdists TEXT {0})", command_col_names);
            sqlCmd.ExecuteNonQuery();
        }

        #endregion

        #region Поля класса

        /// <summary>
        /// Хранит путь до файла базы данных, с которым работаем
        /// </summary>
        private string _sqlite_path;

        /// <summary>
        /// Экземпляр класса подключения к БД
        /// </summary>
        private SQLiteConnection dbConn;

        /// <summary>
        /// Экземпляр класса для исполнения команд, посылаемых базе данных
        /// </summary>
        private SQLiteCommand sqlCmd;

        /// <summary>
        /// Имена столбцов текущей таблицы
        /// </summary>
        private string _current_table_col_names;

        #endregion
    }
}
