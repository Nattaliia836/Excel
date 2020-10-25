namespace Laboratory1
{
    partial class Form1
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Apply = new System.Windows.Forms.Button();
            this.AddColumn = new System.Windows.Forms.Button();
            this.RemoveColumn = new System.Windows.Forms.Button();
            this.AddRow = new System.Windows.Forms.Button();
            this.ExpressionTextBox = new System.Windows.Forms.TextBox();
            this.RemoveRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 72);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 24;
            this.DGV.Size = new System.Drawing.Size(898, 408);
            this.DGV.TabIndex = 0;
            this.DGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(255, 17);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(118, 37);
            this.Apply.TabIndex = 1;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // AddColumn
            // 
            this.AddColumn.Location = new System.Drawing.Point(406, 17);
            this.AddColumn.Name = "AddColumn";
            this.AddColumn.Size = new System.Drawing.Size(118, 37);
            this.AddColumn.TabIndex = 2;
            this.AddColumn.Text = "Add Column";
            this.AddColumn.UseVisualStyleBackColor = true;
            this.AddColumn.Click += new System.EventHandler(this.AddColumn_Click);
            // 
            // RemoveColumn
            // 
            this.RemoveColumn.Location = new System.Drawing.Point(530, 17);
            this.RemoveColumn.Name = "RemoveColumn";
            this.RemoveColumn.Size = new System.Drawing.Size(128, 37);
            this.RemoveColumn.TabIndex = 3;
            this.RemoveColumn.Text = "Remove Column";
            this.RemoveColumn.UseVisualStyleBackColor = true;
            this.RemoveColumn.Click += new System.EventHandler(this.RemoveColumn_Click);
            // 
            // AddRow
            // 
            this.AddRow.Location = new System.Drawing.Point(668, 17);
            this.AddRow.Name = "AddRow";
            this.AddRow.Size = new System.Drawing.Size(118, 37);
            this.AddRow.TabIndex = 5;
            this.AddRow.Text = "Add Row";
            this.AddRow.UseVisualStyleBackColor = true;
            this.AddRow.Click += new System.EventHandler(this.AddRow_Click);
            // 
            // ExpressionTextBox
            // 
            this.ExpressionTextBox.Location = new System.Drawing.Point(12, 24);
            this.ExpressionTextBox.Name = "ExpressionTextBox";
            this.ExpressionTextBox.Size = new System.Drawing.Size(225, 22);
            this.ExpressionTextBox.TabIndex = 6;
            // 
            // RemoveRow
            // 
            this.RemoveRow.Location = new System.Drawing.Point(792, 17);
            this.RemoveRow.Name = "RemoveRow";
            this.RemoveRow.Size = new System.Drawing.Size(118, 37);
            this.RemoveRow.TabIndex = 7;
            this.RemoveRow.Text = "Remove Row";
            this.RemoveRow.UseVisualStyleBackColor = true;
            this.RemoveRow.Click += new System.EventHandler(this.RemoveRow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 492);
            this.Controls.Add(this.RemoveRow);
            this.Controls.Add(this.ExpressionTextBox);
            this.Controls.Add(this.AddRow);
            this.Controls.Add(this.RemoveColumn);
            this.Controls.Add(this.AddColumn);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.DGV);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button AddColumn;
        private System.Windows.Forms.Button RemoveColumn;
        private System.Windows.Forms.Button AddRow;
        private System.Windows.Forms.TextBox ExpressionTextBox;
        private System.Windows.Forms.Button RemoveRow;
    }
}

