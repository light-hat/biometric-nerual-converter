using Calculator.AdditionalModules;
using Calculator.Calculate;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();

            dataGridView1.MultiSelect = false;
        }

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
                // ...
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
                // ...
            }

            catch (Exception ex)
            {
                ErrorHandler.showErrorMessage(ex.Message);
            }
        }

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

        /// <summary>
        /// Непосредственно вычисление значения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вычислениеЗначенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Вызываем диалоговую форму, запрашиваем у пользователя входные данные
                using (var calcDlg = new calculateDlg())
                {
                    var result = calcDlg.ShowDialog();

                    if (result == DialogResult.OK) // Постараюсь внятно растолковать, что тут происходит...
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

                        ////// dataGridView1.Columns[2].HeaderText; - заголовок столбца
                        ////// dataGridView1[0, 1].Value; - заголовок строки
                        ////// dataGridView1[0, 2].Value; - данные непосредственно

                        // Запись преобразуемых табличных данных
                        for (int i = 0; i < 2; i++)
                            for (int j = 0; j < 2; j++)
                                iter_matrix[i, j] = full_table_data[iter_matrix_rows_indexes[i], iter_matrix_cols_indexes[j]];

                        TableExtender tableExter = new TableExtender(iter_matrix, iter_matrix_row_heads, iter_matrix_col_heads); // Передаём табличные значения, над которыми будут производиться вычисления, на вход конструктора класса, который реализует расширение таблицы
                        tableExter.extend(); // Вызываем метод, выполняющий расширение таблицы

                        // Вызываем метод для получения новой таблицы, результат работы которого передаём статическому методу класса, отвечающего за вычисление среднего значения энтропии. Результат в свою очередь выводится в сообщении.
                        MessageBox.Show("Результат по первой итерации: " + Convert.ToString(EntropyCalculator.calculate(tableExter.getNewMatrix(calcDlg.hammingDist, calcDlg.standDeviation))) + " бит");
                    }
                }
            }

            catch (Exception ex)
            {
                ErrorHandler.showErrorMessage(ex.Message);
            }
        }

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

            result[0] = Convert.ToDouble(dataGridView1.Columns[2].HeaderText);
            result[1] = Convert.ToDouble(dataGridView1.Columns[3].HeaderText);

            return result;
        }

        /// <summary>
        /// Преобразует данные в таблице в дробные числа. Имеется в виду чисто область данных.
        /// </summary>
        /// <returns>Область данных в таблице</returns>
        private double[,] getDoubleValuesFromData()
        {
            double[,] result = new double[dataGridView1.Rows.Count - 1, dataGridView1.Columns.Count - 2];

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                for (int j = 0; j < dataGridView1.Columns.Count - 2; j++)
                    result[i, j] = Convert.ToDouble(dataGridView1[j + 2, i].Value);

            return result;
        }
    }
}
