﻿namespace Calculator.Calculate
{
    /// <summary>
    /// Табличное вычисление энтропии
    /// </summary>
    public static class EntropyCalculator
    {
        /// <summary>
        /// Табличное вычисление энтропии
        /// </summary>
        /// <param name="inp_arr">Найденные в таблице значения энтропии</param>
        /// <returns>Усреднённое значение</returns>
        public static double calculate(double[] inp_arr)
        {
            return (inp_arr[0] + inp_arr[1] + inp_arr[2] + inp_arr[3]) / 4;
        }
    }
}
