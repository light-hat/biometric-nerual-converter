namespace Calculator
{
    partial class Calculator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.базаДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьтСформированнуюТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.вычислениеЗначенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRow = new System.Windows.Forms.Button();
            this.rmRow = new System.Windows.Forms.Button();
            this.addColumn = new System.Windows.Forms.Button();
            this.rmColumn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.базаДанныхToolStripMenuItem,
            this.вычислениеЗначенияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // базаДанныхToolStripMenuItem
            // 
            this.базаДанныхToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сформироватьToolStripMenuItem,
            this.сохранитьтСформированнуюТаблицуToolStripMenuItem});
            this.базаДанныхToolStripMenuItem.Name = "базаДанныхToolStripMenuItem";
            this.базаДанныхToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.базаДанныхToolStripMenuItem.Text = "Таблица";
            // 
            // сформироватьToolStripMenuItem
            // 
            this.сформироватьToolStripMenuItem.Name = "сформироватьToolStripMenuItem";
            this.сформироватьToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.сформироватьToolStripMenuItem.Text = "Сформировать новую";
            this.сформироватьToolStripMenuItem.Click += new System.EventHandler(this.сформироватьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.открытьToolStripMenuItem.Text = "Открыть созданную ранее";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьтСформированнуюТаблицуToolStripMenuItem
            // 
            this.сохранитьтСформированнуюТаблицуToolStripMenuItem.Name = "сохранитьтСформированнуюТаблицуToolStripMenuItem";
            this.сохранитьтСформированнуюТаблицуToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.сохранитьтСформированнуюТаблицуToolStripMenuItem.Text = "Сохранить сформированную таблицу";
            this.сохранитьтСформированнуюТаблицуToolStripMenuItem.Click += new System.EventHandler(this.сохранитьтСформированнуюТаблицуToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(933, 415);
            this.dataGridView1.TabIndex = 2;
            // 
            // вычислениеЗначенияToolStripMenuItem
            // 
            this.вычислениеЗначенияToolStripMenuItem.Name = "вычислениеЗначенияToolStripMenuItem";
            this.вычислениеЗначенияToolStripMenuItem.Size = new System.Drawing.Size(179, 24);
            this.вычислениеЗначенияToolStripMenuItem.Text = "Вычисление значения";
            // 
            // addRow
            // 
            this.addRow.Image = ((System.Drawing.Image)(resources.GetObject("addRow.Image")));
            this.addRow.Location = new System.Drawing.Point(813, 33);
            this.addRow.Name = "addRow";
            this.addRow.Size = new System.Drawing.Size(32, 32);
            this.addRow.TabIndex = 3;
            this.addRow.UseVisualStyleBackColor = true;
            this.addRow.Click += new System.EventHandler(this.addRow_Click);
            // 
            // rmRow
            // 
            this.rmRow.Image = ((System.Drawing.Image)(resources.GetObject("rmRow.Image")));
            this.rmRow.Location = new System.Drawing.Point(889, 33);
            this.rmRow.Name = "rmRow";
            this.rmRow.Size = new System.Drawing.Size(32, 32);
            this.rmRow.TabIndex = 4;
            this.rmRow.UseVisualStyleBackColor = true;
            this.rmRow.Click += new System.EventHandler(this.rmRow_Click);
            // 
            // addColumn
            // 
            this.addColumn.Image = ((System.Drawing.Image)(resources.GetObject("addColumn.Image")));
            this.addColumn.Location = new System.Drawing.Point(775, 33);
            this.addColumn.Name = "addColumn";
            this.addColumn.Size = new System.Drawing.Size(32, 32);
            this.addColumn.TabIndex = 5;
            this.addColumn.UseVisualStyleBackColor = true;
            this.addColumn.Click += new System.EventHandler(this.addColumn_Click);
            // 
            // rmColumn
            // 
            this.rmColumn.Image = ((System.Drawing.Image)(resources.GetObject("rmColumn.Image")));
            this.rmColumn.Location = new System.Drawing.Point(851, 33);
            this.rmColumn.Name = "rmColumn";
            this.rmColumn.Size = new System.Drawing.Size(32, 32);
            this.rmColumn.TabIndex = 6;
            this.rmColumn.UseVisualStyleBackColor = true;
            this.rmColumn.Click += new System.EventHandler(this.rmColumn_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 484);
            this.Controls.Add(this.rmColumn);
            this.Controls.Add(this.addColumn);
            this.Controls.Add(this.rmRow);
            this.Controls.Add(this.addRow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Calculator";
            this.Text = "Калькулятор";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem базаДанныхToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem сформироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьтСформированнуюТаблицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вычислениеЗначенияToolStripMenuItem;
        private System.Windows.Forms.Button addRow;
        private System.Windows.Forms.Button rmRow;
        private System.Windows.Forms.Button addColumn;
        private System.Windows.Forms.Button rmColumn;
    }
}

