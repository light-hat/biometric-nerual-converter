using Calculator.AdditionalModules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class calculateDlg : Form
    {
        public calculateDlg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.hammingDist = Convert.ToDouble(textBox1.Text);
                this.standDeviation = Convert.ToDouble(textBox2.Text);
                this.iterations = Convert.ToUInt16(textBox3.Text);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            catch (Exception ex) { ErrorHandler.showErrorMessage(ex.Message); }
        }

        public double hammingDist { get; set; }

        public double standDeviation { get; set; }

        public uint iterations { get; set; }
    }
}
