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

        private void вычислениеЗначенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var calcDlg = new calculateDlg())
                {
                    var result = calcDlg.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        int[] iter_matrix_rows_indexes = InterpolSearch.execute(getDoubleValuesFromRowsOfTable(dataGridView1.Rows), calcDlg.hammingDist);
                        int[] iter_matrix_cols_indexes = InterpolSearch.execute(getDoubleValuesFromColumnsOfTable(dataGridView1.Columns), calcDlg.standDeviation);

                        double[,] iter_matrix = new double[2, 2];
                        iter_matrix = getDoubleValuesFromTable(iter_matrix_rows_indexes, iter_matrix_cols_indexes);

                        double[] iter_matrix_rows = getIterRows(iter_matrix_rows_indexes);
                        double[] iter_matrix_cols = getIterCols(iter_matrix_cols_indexes);

                        TableExtender tableExter = new TableExtender(iter_matrix, iter_matrix_rows_indexes, iter_matrix_cols_indexes);
                        tableExter.extend();

                        MessageBox.Show("Результат по первой итерации: " + Convert.ToString(EntropyCalculator.calculate(tableExter.getNewMatrix(calcDlg.hammingDist, calcDlg.standDeviation))) + " бит");
                    }
                }
            }

            catch (Exception ex)
            {
                ErrorHandler.showErrorMessage(ex.Message);
            }
        }

        #region Вспомогательные методы класса

        private double[] getIterRows(int[] row_indexes)
        {
            double[] result = new double[4];
            
            for (int i = 0; i < 4; i++)
                result[i] = Convert.ToDouble(dataGridView1.Rows[row_indexes[i]]);

            return result;
        }

        private double[] getIterCols(int[] col_indexes)
        {
            double[] result = new double[4];

            for (int i = 0; i < 4; i++)
                result[i] = Convert.ToDouble(dataGridView1.Columns[col_indexes[i]]);

            return result;
        }

        private double[] getDoubleValuesFromColumnsOfTable(DataGridViewColumnCollection input)
        {
            double[] result = new double[input.Count - 1];

            try
            {
                for (int i = 0; i < input.Count; i++)
                    result.Append(Convert.ToDouble(input[i]));
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }

            return result;
        }

        private double[] getDoubleValuesFromRowsOfTable(DataGridViewRowCollection input)
        {
            double[] result = new double[input.Count - 1];

            try
            {
                for (int i = 0; i < input.Count; i++)
                    result.Append(Convert.ToDouble(input[i].DataBoundItem));
            }

            catch (Exception e)
            {
                ErrorHandler.showErrorMessage(e.Message + '\n' + e.StackTrace);
            }

            return result;
        }

        private double[,] getDoubleValuesFromTable(int[] rows, int[] cols)
        {
            double[,] result = new double[2, 2];

            double[,] tmp = new double[dataGridView1.Rows.Count, dataGridView1.Columns.Count];

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    tmp[i, j] = Convert.ToDouble(dataGridView1[j, i]);

            result[0, 0] = tmp[rows[0], cols[0]];
            result[0, 1] = tmp[rows[0], cols[1]];
            result[1, 0] = tmp[rows[1], rows[0]];
            result[1, 1] = tmp[rows[1], rows[1]];

            return result;
        }

        #endregion
    }
}
