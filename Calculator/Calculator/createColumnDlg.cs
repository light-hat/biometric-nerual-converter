using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Диалоговое окно для создания столбца в таблице
    /// </summary>
    public partial class createColumnDlg : Form
    {
        #region Конструктор

        public createColumnDlg()
        {
            InitializeComponent();
        }

        #endregion

        #region Обработчики кликов

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.returnValue = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion

        #region Поле, используемое как возвращаемое значение

        /// <summary>
        /// Возвращаемое значение формы
        /// </summary>
        public string returnValue { get; set; }

        #endregion
    }
}
