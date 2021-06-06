
namespace library_winform
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.reportHistoryClassBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.buttonImport = new System.Windows.Forms.Button();
            this.reportHistoryClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.book_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exemplar_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issue_In_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportHistoryClassBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportHistoryClassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Период формирования отчета:";
            // 
            // dateStart
            // 
            this.dateStart.CustomFormat = "dd.mm.yyyy";
            this.dateStart.Location = new System.Drawing.Point(297, 13);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 20);
            this.dateStart.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(504, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = " - ";
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "dd.mm.yyyy";
            this.dateEnd.Location = new System.Drawing.Point(536, 13);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 20);
            this.dateEnd.TabIndex = 3;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(751, 13);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.book_title,
            this.authorDataGridViewTextBoxColumn,
            this.Exemplar_Count,
            this.Issue_In_Period,
            this.Available_Count});
            this.dataGridView.DataSource = this.reportHistoryClassBindingSource1;
            this.dataGridView.Location = new System.Drawing.Point(13, 37);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1297, 516);
            this.dataGridView.TabIndex = 5;
            // 
            // reportHistoryClassBindingSource1
            // 
            this.reportHistoryClassBindingSource1.DataSource = typeof(library_winform.ReportHistoryClass);
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(833, 13);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(75, 23);
            this.buttonImport.TabIndex = 6;
            this.buttonImport.Text = "Выгрузить";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // reportHistoryClassBindingSource
            // 
            this.reportHistoryClassBindingSource.DataSource = typeof(library_winform.ReportHistoryClass);
            // 
            // book_title
            // 
            this.book_title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.book_title.DataPropertyName = "Book_Title";
            this.book_title.HeaderText = "Книга";
            this.book_title.MinimumWidth = 15;
            this.book_title.Name = "book_title";
            this.book_title.Width = 62;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "Автор";
            this.authorDataGridViewTextBoxColumn.MinimumWidth = 20;
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.Width = 62;
            // 
            // Exemplar_Count
            // 
            this.Exemplar_Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Exemplar_Count.DataPropertyName = "Exemplar_Count";
            this.Exemplar_Count.HeaderText = "Всего экземпляров";
            this.Exemplar_Count.Name = "Exemplar_Count";
            this.Exemplar_Count.Width = 122;
            // 
            // Issue_In_Period
            // 
            this.Issue_In_Period.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Issue_In_Period.DataPropertyName = "Issue_In_Period";
            this.Issue_In_Period.HeaderText = "Выдано за период";
            this.Issue_In_Period.Name = "Issue_In_Period";
            this.Issue_In_Period.Width = 114;
            // 
            // Available_Count
            // 
            this.Available_Count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Available_Count.DataPropertyName = "Available_Count";
            this.Available_Count.HeaderText = "Доступно экзепляров";
            this.Available_Count.Name = "Available_Count";
            this.Available_Count.Width = 132;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 565);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Популярные книги за период";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportHistoryClassBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reportHistoryClassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.BindingSource reportHistoryClassBindingSource;
        private System.Windows.Forms.BindingSource reportHistoryClassBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn book_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Exemplar_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issue_In_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Available_Count;
    }
}

