using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <param name="rows">Заголовки строк расширяемой таблицы</param>
        /// <param name="columns">Заголовки столбцов расширяемой таблицы</param>
        public TableExtender(double[,] inp_matrix, double[] rows, double[] columns)
        {
            _a[0, 0] = inp_matrix[0, 0];
            _a[0, 2] = inp_matrix[0, 1];
            _a[2, 0] = inp_matrix[1, 0];
            _a[2, 2] = inp_matrix[1, 1];
        }

        /// <summary>
        /// Непосредственно расширение
        /// </summary>
        public void extend()
        {
            _a[0, 1] = (_a[0, 0] + _a[0, 2]) / 2;
            _a[2, 1] = (_a[2, 0] + _a[2, 2]) / 2;

            _a[1, 0] = (_a[0, 0] + _a[2, 0]) / 2;
            _a[1, 2] = (_a[0, 2] + _a[2, 2]) / 2;

            _a[1, 1] = (_a[0, 1] + _a[2, 1] + _a[1, 0] + _a[1, 2]) / 4;
        }

        /// <summary>
        /// Расширенная таблица на 9 элементов, где производится следующая итерация поиска
        /// </summary>
        private double[,] _a = new double[3, 3];
    }
}
