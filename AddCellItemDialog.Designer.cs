namespace FoodPlanInator {
    partial class AddCellItemDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCellItemDialog));
            mTextBoxFilter = new TextBox();
            mBtnSubmit = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // mTextBoxFilter
            // 
            mTextBoxFilter.Location = new Point(12, 15);
            mTextBoxFilter.Name = "mTextBoxFilter";
            mTextBoxFilter.Size = new Size(367, 23);
            mTextBoxFilter.TabIndex = 0;
            mTextBoxFilter.TextChanged += mTextBoxFilter_TextChanged;
            // 
            // mBtnSubmit
            // 
            mBtnSubmit.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            mBtnSubmit.Location = new Point(111, 489);
            mBtnSubmit.Name = "mBtnSubmit";
            mBtnSubmit.Size = new Size(168, 32);
            mBtnSubmit.TabIndex = 2;
            mBtnSubmit.Text = "Submit";
            mBtnSubmit.UseVisualStyleBackColor = true;
            mBtnSubmit.Click += mBtnSubmit_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 44);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 4;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(367, 439);
            dataGridView1.TabIndex = 3;
            dataGridView1.SelectionChanged += mGridView_SelecttedIngrediants_SelectionChanged;
            dataGridView1.DoubleClick += mListBox_DoubleClick;
            // 
            // AddCellItemDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 533);
            Controls.Add(dataGridView1);
            Controls.Add(mBtnSubmit);
            Controls.Add(mTextBoxFilter);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddCellItemDialog";
            Text = "AddCellItemDialog";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mTextBoxFilter;
        private Button mBtnSubmit;
        private DataGridView dataGridView1;
    }
}