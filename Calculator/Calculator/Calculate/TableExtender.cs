using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculate
{
    /// <summary>
    /// Алгоритм для расширения таблицы
    /// </summary>
    public class TableExtender
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="inp_arr">Массив дробных чисел на ЧЕТЫРЕ ЭЛЕМЕНТА</param>
        public TableExtender(double[,] inp_arr)
        {
            _a[0, 0] = inp_arr[0, 0];
            _a[0, 2] = inp_arr[0, 1];
            _a[2, 0] = inp_arr[1, 0];
            _a[2, 2] = inp_arr[1, 1];
        }

        public int[,] doingIteration()
        {
            int[,] ans = new int[2, 2]; // Возвращаемая таблица



            return ans;
        }

        /// <summary>
        /// Расширенная таблица на 9 элементов, где производится следующая итерация поиска
        /// </summary>
        private double[,] _a = new double[3, 3];
    }
}
