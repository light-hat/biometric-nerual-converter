using System;
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

        #region Проверка нахождения первого элемента
        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #1
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS1()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(FirstDataset, FirstDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 1 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #2
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS2()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(SecondDataset, SecondDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 2 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #3
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS3()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(ThirdDataset, ThirdDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 3 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #4
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS4()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(FourthDataset, FourthDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 4 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #5
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS5()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(FifthDataset, FifthDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 5 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #6
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS6()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(SixthDataset, SixthDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 6 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #7
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS7()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(SeventhDataset, SeventhDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 7 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #8
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS8()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(EighthDataset, EighthDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 8 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится первый элемент массива
        /// Проверка идёт по датасету #9
        /// </summary>
        [TestMethod]
        public void TestSearchFirstItem_DS9()
        {
            int[] real_answer = new int[2];
            int[] expected_answer = new int[2] { 0, 0 };

            real_answer = InterpolSearch.execute(NinethDataset, NinethDataset[0]);

            try
            {
                for (int i = 0; i < 2; i++)
                    Assert.AreEqual(real_answer[i], expected_answer[i]);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Dataset 9 is failed. Real meaning: [" + real_answer[0] + ", " + real_answer[1] + "]; and expected: [" + expected_answer[0] + ", " + expected_answer[1] + "]");
            }
        }

        #endregion

        #region Проверка нахождения последнего элемента

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится элемент массива, который находится в конце
        /// </summary>
        [TestMethod]
        public void TestSearchLastItem_DS1()
        {
            // TODO
        }

        #endregion

        #region Проверка нахождения второго элемента

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится второй элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchSecondItem()
        {
            // TODO
        }

        #endregion

        #region Проверка нахождения предпоследнего элемента

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится предпоследний элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchPenultItem()
        {
            // TODO
        }

        #endregion

        #region Проверка нахождения любого существующего элемента

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится существующий элемент массива
        /// </summary>
        [TestMethod]
        public void TestSearchSomeItem()
        {
            // TODO
        }

        #endregion

        #region Проверка определения отсутствия элемента

        /// <summary>
        /// Данный метод класса проверяет, корректно ли определяется, что поданного на вход элемента не существует
        /// </summary>
        [TestMethod]
        public void TestSearchNonExistentItem()
        {
            // TODO
        }

        #endregion

        #region Проверка поиска значения, находящегося между соседними элементами

        /// <summary>
        /// Данный метод класса проверяет, корректно ли находится элемент между элементами массива
        /// </summary>
        [TestMethod]
        public void TestSearchBetweenItem()
        {
            // TODO
        }

        #endregion

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
