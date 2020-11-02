using System;
using System.Windows.Forms;

namespace Calculator
{
    /// <summary>
    /// Диалоговое окно для создания столбца в таблице
    /// </summary>
    public partial class createColumnDlg : Form
    {
        public createColumnDlg()
        {
            InitializeComponent();
        }

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

        /// <summary>
        /// Возвращаемое значение формы
        /// </summary>
        public string returnValue { get; set; }
    }
}
