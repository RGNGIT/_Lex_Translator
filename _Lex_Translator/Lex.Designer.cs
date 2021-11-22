namespace _Lex_Translator
{
    partial class Lex
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
            this.listBoxCode = new System.Windows.Forms.ListBox();
            this.buttonLexAnalisys = new System.Windows.Forms.Button();
            this.listBoxErrors = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.dataGridViewIdenList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewConst = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewOpers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDiv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewLex = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIdenList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLex)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxCode
            // 
            this.listBoxCode.FormattingEnabled = true;
            this.listBoxCode.Location = new System.Drawing.Point(12, 46);
            this.listBoxCode.Name = "listBoxCode";
            this.listBoxCode.Size = new System.Drawing.Size(324, 316);
            this.listBoxCode.TabIndex = 0;
            // 
            // buttonLexAnalisys
            // 
            this.buttonLexAnalisys.Location = new System.Drawing.Point(12, 368);
            this.buttonLexAnalisys.Name = "buttonLexAnalisys";
            this.buttonLexAnalisys.Size = new System.Drawing.Size(324, 23);
            this.buttonLexAnalisys.TabIndex = 1;
            this.buttonLexAnalisys.Text = "Лексический анализ";
            this.buttonLexAnalisys.UseVisualStyleBackColor = true;
            this.buttonLexAnalisys.Click += new System.EventHandler(this.buttonLexAnalisys_Click);
            // 
            // listBoxErrors
            // 
            this.listBoxErrors.FormattingEnabled = true;
            this.listBoxErrors.Location = new System.Drawing.Point(12, 419);
            this.listBoxErrors.Name = "listBoxErrors";
            this.listBoxErrors.Size = new System.Drawing.Size(324, 199);
            this.listBoxErrors.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Исходный текст программы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ошибки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(552, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Таблица операторов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(723, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Таблица разделителей";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(552, 364);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Таблица идентификаторов";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(723, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Таблица констант";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(241, 17);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(95, 23);
            this.buttonOpen.TabIndex = 13;
            this.buttonOpen.Text = "Открыть код";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // dataGridViewIdenList
            // 
            this.dataGridViewIdenList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIdenList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridViewIdenList.Location = new System.Drawing.Point(555, 380);
            this.dataGridViewIdenList.Name = "dataGridViewIdenList";
            this.dataGridViewIdenList.Size = new System.Drawing.Size(165, 238);
            this.dataGridViewIdenList.TabIndex = 14;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Идентификаторы";
            this.Column1.Name = "Column1";
            this.Column1.Width = 122;
            // 
            // dataGridViewConst
            // 
            this.dataGridViewConst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridViewConst.Location = new System.Drawing.Point(726, 380);
            this.dataGridViewConst.Name = "dataGridViewConst";
            this.dataGridViewConst.Size = new System.Drawing.Size(165, 238);
            this.dataGridViewConst.TabIndex = 15;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Константы";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 122;
            // 
            // dataGridViewOpers
            // 
            this.dataGridViewOpers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOpers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dataGridViewOpers.Location = new System.Drawing.Point(555, 46);
            this.dataGridViewOpers.Name = "dataGridViewOpers";
            this.dataGridViewOpers.Size = new System.Drawing.Size(165, 315);
            this.dataGridViewOpers.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Операторы";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 122;
            // 
            // dataGridViewDiv
            // 
            this.dataGridViewDiv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewDiv.Location = new System.Drawing.Point(726, 46);
            this.dataGridViewDiv.Name = "dataGridViewDiv";
            this.dataGridViewDiv.Size = new System.Drawing.Size(165, 315);
            this.dataGridViewDiv.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Разделители";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 122;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Лексемы";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 122;
            // 
            // dataGridViewLex
            // 
            this.dataGridViewLex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4});
            this.dataGridViewLex.Location = new System.Drawing.Point(342, 46);
            this.dataGridViewLex.Name = "dataGridViewLex";
            this.dataGridViewLex.Size = new System.Drawing.Size(207, 572);
            this.dataGridViewLex.TabIndex = 18;
            // 
            // Lex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 630);
            this.Controls.Add(this.dataGridViewLex);
            this.Controls.Add(this.dataGridViewDiv);
            this.Controls.Add(this.dataGridViewOpers);
            this.Controls.Add(this.dataGridViewConst);
            this.Controls.Add(this.dataGridViewIdenList);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxErrors);
            this.Controls.Add(this.buttonLexAnalisys);
            this.Controls.Add(this.listBoxCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Lex";
            this.Text = "Анализатор";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIdenList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOpers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCode;
        private System.Windows.Forms.Button buttonLexAnalisys;
        private System.Windows.Forms.ListBox listBoxErrors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.DataGridView dataGridViewIdenList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridView dataGridViewConst;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridViewOpers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView dataGridViewDiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dataGridViewLex;
    }
}

