using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculator.AdditionalModules;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
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
                DataView data = new DataView();


            }

            catch (Exception ex)
            {
                ErrorHandler.showMessage(ex.Message);
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
            // ...
        }

        /// <summary>
        /// Сохраняет сформированную таблицу в виде файла базы данных формата SQLite3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьтСформированнуюТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ...
        }
    }
}
