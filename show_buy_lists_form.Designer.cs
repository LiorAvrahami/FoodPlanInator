namespace FoodPlanInator {
    partial class show_buy_lists_form {
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
            mTxtBx = new TextBox();
            mLable_Title = new Label();
            mBtnBack = new Button();
            mBtnNext = new Button();
            mBtnCopy = new Button();
            SuspendLayout();
            // 
            // mTxtBx
            // 
            mTxtBx.Location = new Point(10, 33);
            mTxtBx.Multiline = true;
            mTxtBx.Name = "mTxtBx";
            mTxtBx.Size = new Size(317, 404);
            mTxtBx.TabIndex = 0;
            // 
            // mLable_Title
            // 
            mLable_Title.AutoSize = true;
            mLable_Title.BackColor = Color.FromArgb(255, 224, 192);
            mLable_Title.BorderStyle = BorderStyle.FixedSingle;
            mLable_Title.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            mLable_Title.Location = new Point(10, 9);
            mLable_Title.Name = "mLable_Title";
            mLable_Title.Size = new Size(94, 23);
            mLable_Title.TabIndex = 4;
            mLable_Title.Text = "NOT FILLED";
            mLable_Title.Click += mLable_Title_Click;
            // 
            // mBtnBack
            // 
            mBtnBack.Location = new Point(10, 445);
            mBtnBack.Name = "mBtnBack";
            mBtnBack.Size = new Size(100, 47);
            mBtnBack.TabIndex = 8;
            mBtnBack.Text = "Back";
            mBtnBack.UseVisualStyleBackColor = true;
            mBtnBack.Click += mBtnBack_Click;
            // 
            // mBtnNext
            // 
            mBtnNext.Location = new Point(227, 445);
            mBtnNext.Name = "mBtnNext";
            mBtnNext.Size = new Size(100, 47);
            mBtnNext.TabIndex = 9;
            mBtnNext.Text = "Next";
            mBtnNext.UseVisualStyleBackColor = true;
            mBtnNext.Click += mBtnNext_Click;
            // 
            // mBtnCopy
            // 
            mBtnCopy.Location = new Point(120, 445);
            mBtnCopy.Name = "mBtnCopy";
            mBtnCopy.Size = new Size(100, 47);
            mBtnCopy.TabIndex = 10;
            mBtnCopy.Text = "Copy";
            mBtnCopy.UseVisualStyleBackColor = true;
            mBtnCopy.Click += mBtnCopy_Click;
            // 
            // show_buy_lists_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 502);
            Controls.Add(mBtnCopy);
            Controls.Add(mBtnNext);
            Controls.Add(mBtnBack);
            Controls.Add(mLable_Title);
            Controls.Add(mTxtBx);
            Name = "show_buy_lists_form";
            Text = "show_buy_lists_form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mTxtBx;
        private TextBox mTxtStoreBWeek1;
        private TextBox mTxtStoreBWeek2;
        private TextBox mTxtSpices;
        private Label mLable_Title;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button mBtnBack;
        private Button mBtnNext;
        private Label label5;
        private Label label6;
        private TextBox mTxtStoreBWeek4;
        private TextBox mTxtStoreBWeek3;
        private Button mBtnCopy;
    }
}