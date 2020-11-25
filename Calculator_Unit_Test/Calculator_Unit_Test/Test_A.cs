using Calculator.Calculate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator_Unit_Test
{
    /// <summary>
    /// Данный класс отвечает за тестирование модуля, отвечающего за интерполяционный поиск
    /// </summary>
    [TestClass]
    public class Test_A
    {
        #region Тестовые методы класса

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem()
        {
            // TODO
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится элемент массива, который находится в конце
        /// </summary>
        [TestMethod]
        public void TestSearchLastItem()
        {
            // TODO
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится второй элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchSecondItem()
        {
            // TODO
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится предпоследний элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchPenultItem()
        {
            // TODO
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится существующий элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchSomeItem()
        {
            // TODO
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли определяется, что поданного на вход элемента не существует
        /// </summary>
        [TestMethod]
        public void TestSearchNonExistentItem()
        {
            // TODO
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится элемент между элементами массива
        /// </summary>
        [TestMethod]
        public void TestSearchBetweenItem()
        {
            // TODO
        }

        #endregion

        #region Тестовые наборы данных

        /// <summary>
        /// И целые, и дробные числа
        /// </summary>
        private double[] FirstDataset = new double[15] { 1, 2.7, 3.14, 8, 9, 10, 11, 12, 13, 14, 15.2, 16.8, 17.2, 18, 19 };

        /// <summary>
        /// Только дробные
        /// </summary>
        private double[] SecondDataset = new double[15] { 2.2, 3.14, 4.6, 4.8, 5.8, 6.6, 7.1, 8.1, 9.1, 10.2, 11.9, 12.3, 13.9, 14.8, 15.4 };

        /// <summary>
        /// Только целые
        /// </summary>
        private double[] ThirdDataset = new double[16] { 1, 4, 8, 12, 13, 14, 15, 17, 18, 22, 29, 31, 32, 34, 38, 39 };

        /// <summary>
        /// Массив из одного элемента, целое число
        /// </summary>
        private double[] FourthDataset = new double[1] { 12 };

        /// <summary>
        /// Массив из одного элемента, дробное число
        /// </summary>
        private double[] FifthDataset = new double[1] { 22.5 };

        /// <summary>
        /// Массив из двух элементов, целые числа
        /// </summary>
        private double[] SixthDataset = new double[2] { 2, 5 };

        /// <summary>
        /// Массив из двух элементов, дробные числа
        /// </summary>
        private double[] SeventhDataset = new double[2] { 6.4, 8.3 };

        /// <summary>
        /// Массив из трёх чисел, целые
        /// </summary>
        private double[] EighthDataset = new double[3] { 4, 6, 8 };

        /// <summary>
        /// Массив из трёх чисел, дробные
        /// </summary>
        private double[] NinethDataset = new double[3] { 13.2, 18.6, 24.8 };

        #endregion
    }
}
