namespace BudgetBuddy
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.lblIncome = new System.Windows.Forms.Label();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.btnAddIncome = new System.Windows.Forms.Button();
            this.lblExpenses = new System.Windows.Forms.Label();
            this.txtExpenses = new System.Windows.Forms.TextBox();
            this.btnAddExpenses = new System.Windows.Forms.Button();
            this.lblNetBalance = new System.Windows.Forms.Label();
            this.txtNetBalance = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncome.Location = new System.Drawing.Point(94, 156);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(94, 29);
            this.lblIncome.TabIndex = 0;
            this.lblIncome.Text = "Income";
            // 
            // txtIncome
            // 
            this.txtIncome.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtIncome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIncome.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncome.Location = new System.Drawing.Point(194, 156);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(200, 23);
            this.txtIncome.TabIndex = 1;
            this.txtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddIncome
            // 
            this.btnAddIncome.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIncome.Location = new System.Drawing.Point(409, 149);
            this.btnAddIncome.Name = "btnAddIncome";
            this.btnAddIncome.Size = new System.Drawing.Size(188, 43);
            this.btnAddIncome.TabIndex = 2;
            this.btnAddIncome.Text = "Add Income";
            this.btnAddIncome.UseVisualStyleBackColor = true;
            this.btnAddIncome.Click += new System.EventHandler(this.btnAddIncome_Click);
            // 
            // lblExpenses
            // 
            this.lblExpenses.AutoSize = true;
            this.lblExpenses.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpenses.Location = new System.Drawing.Point(75, 247);
            this.lblExpenses.Name = "lblExpenses";
            this.lblExpenses.Size = new System.Drawing.Size(113, 29);
            this.lblExpenses.TabIndex = 3;
            this.lblExpenses.Text = "Expenses";
            // 
            // txtExpenses
            // 
            this.txtExpenses.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtExpenses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExpenses.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenses.Location = new System.Drawing.Point(194, 247);
            this.txtExpenses.Name = "txtExpenses";
            this.txtExpenses.Size = new System.Drawing.Size(200, 23);
            this.txtExpenses.TabIndex = 4;
            this.txtExpenses.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAddExpenses
            // 
            this.btnAddExpenses.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExpenses.Location = new System.Drawing.Point(409, 243);
            this.btnAddExpenses.Name = "btnAddExpenses";
            this.btnAddExpenses.Size = new System.Drawing.Size(188, 43);
            this.btnAddExpenses.TabIndex = 5;
            this.btnAddExpenses.Text = "Add Expenses";
            this.btnAddExpenses.UseVisualStyleBackColor = true;
            this.btnAddExpenses.Click += new System.EventHandler(this.btnAddExpenses_Click);
            // 
            // lblNetBalance
            // 
            this.lblNetBalance.AutoSize = true;
            this.lblNetBalance.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetBalance.Location = new System.Drawing.Point(38, 329);
            this.lblNetBalance.Name = "lblNetBalance";
            this.lblNetBalance.Size = new System.Drawing.Size(150, 29);
            this.lblNetBalance.TabIndex = 6;
            this.lblNetBalance.Text = "Net Balance";
            // 
            // txtNetBalance
            // 
            this.txtNetBalance.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNetBalance.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNetBalance.Location = new System.Drawing.Point(194, 329);
            this.txtNetBalance.Name = "txtNetBalance";
            this.txtNetBalance.ReadOnly = true;
            this.txtNetBalance.Size = new System.Drawing.Size(200, 23);
            this.txtNetBalance.TabIndex = 7;
            this.txtNetBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(659, 279);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 159);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Modern No. 20", 47.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(32, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(722, 65);
            this.label5.TabIndex = 12;
            this.label5.Text = "Welcome to BudgetBuddy";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Modern No. 20", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(409, 322);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(188, 43);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtNetBalance);
            this.Controls.Add(this.lblNetBalance);
            this.Controls.Add(this.btnAddExpenses);
            this.Controls.Add(this.txtExpenses);
            this.Controls.Add(this.lblExpenses);
            this.Controls.Add(this.btnAddIncome);
            this.Controls.Add(this.txtIncome);
            this.Controls.Add(this.lblIncome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BudgetBuddy Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.TextBox txtIncome;
        private System.Windows.Forms.Button btnAddIncome;
        private System.Windows.Forms.Label lblExpenses;
        private System.Windows.Forms.TextBox txtExpenses;
        private System.Windows.Forms.Button btnAddExpenses;
        private System.Windows.Forms.Label lblNetBalance;
        private System.Windows.Forms.TextBox txtNetBalance;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
    }
}