namespace Calculator.Calculate
{
    /// <summary>
    /// Немного модифицированный интерполяционный поиск.
    /// Возвращает не конкретный элемент массива, а два соседних элемента,
    /// между которыми находится значение.
    /// </summary>
    public static class InterpolSearch
    {
        /// <summary>
        /// Метод, непосредственно осуществляющий поиск.
        /// </summary>
        /// <param name="a">Входной массив, в котором осуществляется поиск</param>
        /// <param name="key">Искомое значение, ключ</param>
        /// <returns>Массив из 2-х элементов. Содержит индексы элементов, между которыми находится искомое значение.</returns>
        public static int[] execute(double[] a, double key)
        {
            int[] ans = new int[2];
            int mid = 0, left = 0, right = a.Length - 1;

            while (a[left] <= key && a[right] >= key)
            {
                mid = (int)(left + ((key - a[left]) * (right - left)) / (a[right] - a[left]));

                if (a[mid] < key) left = mid + 1;

                else if (a[mid] > key) right = mid - 1;

                else
                {
                    ans[0] = mid;

                    return ans;
                }
            }

            if (a[left] == key)
            {
                ans[0] = left;

                return ans;
            }

            else
            {
                ans[0] = mid;
                ans[1] = left;

                return ans;
            }
        }
    }
}
