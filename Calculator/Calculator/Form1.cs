using Calculator.AdditionalModules;
using Calculator.Database;
using Calculator.Calculate;
using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        #region Конструктор

        public Calculator()
        {
            InitializeComponent();

            dataGridView1.MultiSelect = false;
        }

        #endregion

        #region Обработчики кликов

            #region Манипуляции с файлом базы данных

            /// <summary>
            /// Создаёт шаблон таблицы связи значений энтропии и математического
            /// ожидания расстояний Хэмминга со стандартным отклонением
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void сформироватьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    bool answer = true;

                    if (dataGridView1.Rows.Count > 0 || dataGridView1.Columns.Count > 0)
                        answer = ErrorHandler.processingQuestion("Прежде чем создавать новую таблицу, убедитесь, что сохранили текущую. В противном случае она будет утеряна. Вы хотите продолжить?");

                    switch (answer)
                    {
                        case true:
                            // Полная зачистка
                            dataGridView1.Rows.Clear();
                            dataGridView1.Columns.Clear();

                            // Создаём новые колонки
                            dataGridView1.Columns.Add("number", "#"); // Столбец для порядкового номера
                            dataGridView1.Columns.Add("hammdists", "E(h)"); // Математическое ожидание расстояний Хэмминга
                            // Дальнейшие столбцы в этой таблице - стандартное отклонение расстояний Хэмминга,
                            // Их пользователь вводит уже сам
                            break;

                        case false:
                            break;
                    }
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            /// <summary>
            /// Открывает созданную ранее таблицу.
            /// Таблица содержится в файле базы данных в формате SQLite3
            /// и хранится в файловой системе компьютера локально.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Title = "Открыть файл базы данных";
                    openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    if (ErrorHandler.processingQuestion("Вы не сохранили таблицу. Если вы сейчас откроете новую таблицу, вы можете потерять данные. Точно хотите продолжить?"))
                    {
                        DialogResult result = openFile.ShowDialog();

                        if (result == DialogResult.OK || result == DialogResult.Yes)
                        {
                            _path_to_opened_db = openFile.FileName;

                            // TODO
                        }
                    }
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            /// <summary>
            /// Сохраняет сформированную таблицу в виде файла базы данных формата SQLite3
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void сохранитьтСформированнуюТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    if (_path_to_opened_db == null)
                    {
                        SaveFileDialog saveDialog = new SaveFileDialog();
                        saveDialog.Title = "Открыть файл базы данных";
                        saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                        DialogResult save_result = saveDialog.ShowDialog();

                        if (save_result == DialogResult.OK || save_result == DialogResult.Yes)
                        {
                            SQLiteHelper sqHelper = new SQLiteHelper(saveDialog.FileName);
                            sqHelper.preparateTable(getStringValuesFromHeadersOfColumns());

                            string[,] set_up_data = new string[dataGridView1.Rows.Count - 1, dataGridView1.Columns.Count];

                            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                            {
                                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                                {
                                    set_up_data[i, j] = Convert.ToString(dataGridView1[j, i].Value);
                                }
                            }

                            sqHelper.writeDataInDB(set_up_data, dataGridView1.Rows.Count - 1, dataGridView1.Columns.Count);
                        }
                    }

                    else
                    {
                        SQLiteHelper sqHelper = new SQLiteHelper(_path_to_opened_db);
                        sqHelper.preparateTable(getStringValuesFromHeadersOfColumns());
                    }
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            #endregion

            #region Манипуляции с таблицей на экране пользователя

            /// <summary>
            /// Добавление в таблицу нового столбца.
            /// Используется для записи значений стандартного
            /// отклонения расстояний Хэмминга
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void addColumn_Click(object sender, EventArgs e)
            {
                try
                {
                    using (var crDlg = new createColumnDlg())
                    {
                        var result = crDlg.ShowDialog();

                        if (result == DialogResult.OK)
                            dataGridView1.Columns.Add(string.Format("stdev{0}", dataGridView1.Columns.Count - 2), crDlg.returnValue);
                    }
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            /// <summary>
            /// Удаление выделенного столбца из таблицы
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void rmColumn_Click(object sender, EventArgs e) // FIXME
            {
                try
                {
                    if (dataGridView1.SelectedColumns[0].Name == "number" || dataGridView1.SelectedColumns[0].Name == "hammdists")
                        throw new Exception("Этот столбец удалять нельзя");

                    dataGridView1.Columns.Remove(dataGridView1.SelectedColumns[0]);
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            /// <summary>
            /// Добавление строки в таблицу
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void addRow_Click(object sender, EventArgs e)
            {
                try
                {
                    dataGridView1.Rows.Add();
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            /// <summary>
            /// Удалить строку из таблицы
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void rmRow_Click(object sender, EventArgs e)
            {
                try
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            #endregion

            #region Непосредственно вычисление значения

            /// <summary>
            /// Непосредственно вычисление значения
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void вычислениеЗначенияToolStripMenuItem_Click(object sender, EventArgs e)
            {
                try
                {
                    using (var calcDlg = new calculateDlg()) // Создаём экземпляр диалоговой формы
                    {
                        var result = calcDlg.ShowDialog(); // Вызываем диалоговую форму, запрашиваем у пользователя входные данные

                        if (result == DialogResult.OK) // Постараюсь как можно внятнее растолковать, что тут происходит...
                        {
                            double[] full_table_head_rows = getDoubleValuesFromHeadersOfRows(); // Заголовки строк для области данных во всей таблице
                            double[] full_table_head_cols = getDoubleValuesFromHeadersOfColumns(); // Заголовки для столбцов из области данных во всей таблице
                            double[,] full_table_data = getDoubleValuesFromData(); // Непосредственно табличные значения из области данных, тоже вся таблица

                            int[] iter_matrix_rows_indexes = InterpolSearch.execute(full_table_head_rows, calcDlg.hammingDist); // Индексы заголовков строк искомых элементов в массиве, созданном выше. Важный момент, этот индекс не соответствует индексу из таблицы, что у пользователя на экране.
                            int[] iter_matrix_cols_indexes = InterpolSearch.execute(full_table_head_cols, calcDlg.standDeviation); // Индексы заголовков столбцов для искомых в таблице данных

                            double[] iter_matrix_row_heads = new double[2]; // Непосредственно заголовки строк искомых элементов
                            double[] iter_matrix_col_heads = new double[2]; // Заголовки столбцов искомых элементов

                            for (int i = 0; i < 2; i++) // Присваиваем значения двум последним массивам
                            {
                                iter_matrix_col_heads[i] = full_table_head_cols[iter_matrix_cols_indexes[i]];
                                iter_matrix_row_heads[i] = full_table_head_rows[iter_matrix_rows_indexes[i]];
                            }

                            double[,] iter_matrix = new double[2, 2]; // Здесь будут храниться табличные данные, над которыми будут производиться вычисления

                            // Запись преобразуемых табличных данных в двумерный массив, который будет обрабатываться дальше
                            for (int i = 0; i < 2; i++)
                                for (int j = 0; j < 2; j++)
                                    iter_matrix[i, j] = full_table_data[iter_matrix_rows_indexes[i], iter_matrix_cols_indexes[j]];

                            MessageBox.Show(string.Format("Усреднение найденных значений: {0} бит", EntropyCalculator.calculate(iter_matrix))); // Выводим среднее значение

                            double iter_entropy = 0; // Значение энтропии, вычисленное на каждой итерации

                            IterTableStruct iter_table = new IterTableStruct(); // Структура таблицы
                            iter_table.matrix = iter_matrix; // Записываем начальные табличные значения
                            iter_table.row_headers = iter_matrix_row_heads; // Записывам заголовки строк
                            iter_table.column_headers = iter_matrix_col_heads; // Записываем заголовки столбцов

                            for (int i = 0; i < calcDlg.iterations; i++) // Цикл по количеству итераций
                            {
                                TableExtender iterTableExter = new TableExtender(iter_table); // Создаём экземпляр класса для расширения таблицы на текущей итерации
                                iterTableExter.extend(); // Расширяем таблицу

                                iter_table = iterTableExter.getNewMatrix(calcDlg.hammingDist, calcDlg.standDeviation); // Получаем новую таблицу

                                iter_entropy = EntropyCalculator.calculate(iter_table.matrix); // Вычисляем среднее значение энтропии на данной итерации

                                MessageBox.Show(string.Format("Результат по {0}-й итерации: {1} бит", Convert.ToString(i + 1), Convert.ToString(iter_entropy))); // Выводим результат
                            }
                        }
                    }
                }

                catch (Exception ex)
                {
                    ErrorHandler.showErrorMessage(ex.Message);
                }
            }

            #endregion

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Преобразует заголовки строк таблицы в массив дробных чисел
        /// </summary>
        /// <returns>Математическое ожидание Хэмминга</returns>
        private double[] getDoubleValuesFromHeadersOfRows()
        {
            double[] result = new double[dataGridView1.Rows.Count - 1];

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                result[i] = Convert.ToDouble(dataGridView1[1, i].Value);
            }

            return result;
        }

        /// <summary>
        /// Преобразует заголовки столбцов таблицы в массив дробных чисел
        /// </summary>
        /// <returns>Стандартное отклонение расстояний Хэмминга</returns>
        private double[] getDoubleValuesFromHeadersOfColumns()
        {
            double[] result = new double[dataGridView1.Columns.Count - 2];

            //result[0] = Convert.ToDouble(dataGridView1.Columns[2].HeaderText);
            //result[1] = Convert.ToDouble(dataGridView1.Columns[3].HeaderText);

            for (int i = 0; i < dataGridView1.Columns.Count - 2; i++)
                result[i] = Convert.ToDouble(dataGridView1.Columns[i + 2].HeaderText);

            return result;
        }

        /// <summary>
        /// Преобразует данные в таблице в дробные числа. Имеется в виду чисто область данных.
        /// </summary>
        /// <returns>Табличные данные</returns>
        private double[,] getDoubleValuesFromData()
        {
            double[,] result = new double[dataGridView1.Rows.Count - 1, dataGridView1.Columns.Count - 2];

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                for (int j = 0; j < dataGridView1.Columns.Count - 2; j++)
                    result[i, j] = Convert.ToDouble(dataGridView1[j + 2, i].Value);

            return result;
        }

        /// <summary>
        /// Возвращает заголовки столбцов таблицы, отвечающих за значения cтандартного отклонения расстояний Хэмминга
        /// </summary>
        /// <returns>Массив строк, соответствующих стандартному отклонению расстояний Хэмминга</returns>
        private string[] getStringValuesFromHeadersOfColumns()
        {
            string[] result = new string[dataGridView1.Columns.Count - 2];

            for (int i = 0; i < dataGridView1.Columns.Count - 2; i++)
                result[i] = dataGridView1.Columns[i + 2].HeaderText;

            return result;
        }

        #endregion

        #region Поля класса

        /// <summary>
        /// Поле класса для хранения пути до обрабатываемой базы данных. Если null - значит база данных не открыта
        /// </summary>
        private string _path_to_opened_db;

        #endregion
    }
}
