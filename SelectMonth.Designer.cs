namespace FoodPlanInator {
    partial class SelectMonth {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectMonth));
            mCombobox_Months = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            mTextbox_Years = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // mCombobox_Months
            // 
            mCombobox_Months.AutoCompleteMode = AutoCompleteMode.Suggest;
            mCombobox_Months.FormattingEnabled = true;
            mCombobox_Months.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            mCombobox_Months.Location = new Point(139, 36);
            mCombobox_Months.Name = "mCombobox_Months";
            mCombobox_Months.Size = new Size(121, 23);
            mCombobox_Months.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 2;
            label1.Text = "Year";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(139, 18);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 3;
            label2.Text = "Month";
            // 
            // mTextbox_Years
            // 
            mTextbox_Years.Location = new Point(12, 36);
            mTextbox_Years.Name = "mTextbox_Years";
            mTextbox_Years.Size = new Size(121, 23);
            mTextbox_Years.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(58, 65);
            button1.Name = "button1";
            button1.Size = new Size(153, 49);
            button1.TabIndex = 5;
            button1.Text = "Submit";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SelectMonth
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 126);
            Controls.Add(button1);
            Controls.Add(mTextbox_Years);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mCombobox_Months);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectMonth";
            Text = "SelectMonth";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox mCombobox_Months;
        private Label label1;
        private Label label2;
        private TextBox mTextbox_Years;
        private Button button1;
    }
}