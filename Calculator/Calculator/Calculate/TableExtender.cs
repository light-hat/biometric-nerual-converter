namespace Calculator.Calculate
{
    /// <summary>
    /// Класс, реализующий расширение таблицы в 1,5 раза
    /// </summary>
    public class TableExtender
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="inp_matrix">Двумерный массив дробных чисел на 4 элемента</param>
        /// <param name="rows">Заголовки строк расширяемой таблицы, содержит 2 элемента</param>
        /// <param name="columns">Заголовки столбцов расширяемой таблицы, содержит 2 элемента</param>
        public TableExtender(double[,] inp_matrix, int[] inp_rows, int[] inp_columns)
        {
            // Непосредственно табличные значения
            _a[0, 0] = inp_matrix[0, 0];
            _a[0, 2] = inp_matrix[0, 1];
            _a[2, 0] = inp_matrix[1, 0];
            _a[2, 2] = inp_matrix[1, 1];

            // Заголовки для строк
            _table_rows[0] = inp_rows[0];
            _table_rows[2] = inp_rows[1];

            // Заголовки для столбцов
            _table_cols[0] = inp_columns[0];
            _table_cols[2] = inp_columns[1];
        }

        /// <summary>
        /// Непосредственно расширение
        /// </summary>
        public void extend()
        {
            // Значения энтропии
            _a[0, 1] = (_a[0, 0] + _a[0, 2]) / 2;
            _a[2, 1] = (_a[2, 0] + _a[2, 2]) / 2;

            _a[1, 0] = (_a[0, 0] + _a[2, 0]) / 2;
            _a[1, 2] = (_a[0, 2] + _a[2, 2]) / 2;

            _a[1, 1] = (_a[0, 1] + _a[2, 1] + _a[1, 0] + _a[1, 2]) / 4;

            // Столбцы
            _table_cols[1] = (_table_cols[0] + _table_cols[2]) / 2;

            // Строки
            _table_rows[1] = (_table_rows[0] + _table_rows[2]) / 2;
        }

        /// <summary>
        /// Получает новую таблицу из расширенной
        /// </summary>
        /// <returns>Финальная таблица для данной итерации табличных преобразований</returns>
        public double[] getNewMatrix(double real_math_exp, double real_stand_deviation)
        {
            int[] indexes_rows = InterpolSearch.execute(_table_rows, real_math_exp);
            int[] indexes_cols = InterpolSearch.execute(_table_cols, real_stand_deviation);

            double[] final_matrix = new double[4];

            final_matrix[0] = _a[indexes_rows[0], indexes_cols[0]];
            final_matrix[1] = _a[indexes_rows[0], indexes_cols[1]];
            final_matrix[2] = _a[indexes_rows[1], indexes_cols[0]];
            final_matrix[3] = _a[indexes_rows[1], indexes_cols[1]];

            return final_matrix;
        }

        /// <summary>
        /// Расширенная таблица на 9 элементов, где производится следующая итерация поиска
        /// </summary>
        private double[,] _a = new double[3, 3];

        /// <summary>
        /// Строки расширенной таблицы
        /// </summary>
        private double[] _table_rows = new double[3];

        /// <summary>
        /// Столбцы расширенной таблицы
        /// </summary>
        private double[] _table_cols = new double[3];
    }
}
