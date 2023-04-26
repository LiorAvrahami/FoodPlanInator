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
            mListBox = new ListBox();
            mBtnSubmit = new Button();
            SuspendLayout();
            // 
            // mTextBoxFilter
            // 
            mTextBoxFilter.Location = new Point(12, 15);
            mTextBoxFilter.Name = "mTextBoxFilter";
            mTextBoxFilter.Size = new Size(258, 23);
            mTextBoxFilter.TabIndex = 0;
            mTextBoxFilter.TextChanged += mTextBoxFilter_TextChanged;
            // 
            // mListBox
            // 
            mListBox.DrawMode = DrawMode.OwnerDrawFixed;
            mListBox.FormattingEnabled = true;
            mListBox.ItemHeight = 15;
            mListBox.Location = new Point(12, 44);
            mListBox.Name = "mListBox";
            mListBox.Size = new Size(258, 454);
            mListBox.TabIndex = 1;
            mListBox.DrawItem += mListBox_DrawItem;
            mListBox.SelectedIndexChanged += mListBox_SelectedIndexChanged;
            mListBox.DoubleClick += mListBox_DoubleClick;
            // 
            // mBtnSubmit
            // 
            mBtnSubmit.Location = new Point(12, 498);
            mBtnSubmit.Name = "mBtnSubmit";
            mBtnSubmit.Size = new Size(75, 23);
            mBtnSubmit.TabIndex = 2;
            mBtnSubmit.Text = "Submit";
            mBtnSubmit.UseVisualStyleBackColor = true;
            mBtnSubmit.Click += mBtnSubmit_Click;
            // 
            // AddCellItemDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(282, 533);
            Controls.Add(mBtnSubmit);
            Controls.Add(mListBox);
            Controls.Add(mTextBoxFilter);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddCellItemDialog";
            Text = "AddCellItemDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mTextBoxFilter;
        private ListBox mListBox;
        private Button mBtnSubmit;
    }
}