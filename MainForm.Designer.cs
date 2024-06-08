namespace BudgetBuddy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTransaction1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateColumn,
            this.CategoryColumn,
            this.AmountColumn,
            this.DescriptionColumn});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(800, 450);
            this.dataGridView2.TabIndex = 0;
            // 
            // DateColumn
            // 
            this.DateColumn.DataPropertyName = "Date";
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.Width = 150;
            // 
            // CategoryColumn
            // 
            this.CategoryColumn.DataPropertyName = "Category";
            this.CategoryColumn.HeaderText = "Category";
            this.CategoryColumn.Name = "CategoryColumn";
            this.CategoryColumn.Width = 200;
            // 
            // AmountColumn
            // 
            this.AmountColumn.DataPropertyName = "Amount";
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.Name = "AmountColumn";
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.DataPropertyName = "Description";
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.Width = 250;
            // 
            // btnAddTransaction1
            // 
            this.btnAddTransaction1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTransaction1.Location = new System.Drawing.Point(668, 398);
            this.btnAddTransaction1.Name = "btnAddTransaction1";
            this.btnAddTransaction1.Size = new System.Drawing.Size(120, 40);
            this.btnAddTransaction1.TabIndex = 1;
            this.btnAddTransaction1.Text = "Add Transaction";
            this.btnAddTransaction1.UseVisualStyleBackColor = true;
            this.btnAddTransaction1.Click += new System.EventHandler(this.btnAddTransaction1_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddTransaction1);
            this.Controls.Add(this.dataGridView2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddTransaction;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnAddTransaction1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
    }
}

