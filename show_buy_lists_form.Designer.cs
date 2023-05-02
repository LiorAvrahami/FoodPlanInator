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
            mTxtMonth = new TextBox();
            mTxtStoreBWeek1 = new TextBox();
            mTxtStoreBWeek3 = new TextBox();
            mTxtSpices = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            mBtnOpenCalanderImage = new Button();
            SuspendLayout();
            // 
            // mTxtMonth
            // 
            mTxtMonth.Location = new Point(17, 43);
            mTxtMonth.Multiline = true;
            mTxtMonth.Name = "mTxtMonth";
            mTxtMonth.Size = new Size(252, 444);
            mTxtMonth.TabIndex = 0;
            // 
            // mTxtStoreBWeek1
            // 
            mTxtStoreBWeek1.Location = new Point(275, 43);
            mTxtStoreBWeek1.Multiline = true;
            mTxtStoreBWeek1.Name = "mTxtStoreBWeek1";
            mTxtStoreBWeek1.Size = new Size(252, 444);
            mTxtStoreBWeek1.TabIndex = 1;
            // 
            // mTxtStoreBWeek3
            // 
            mTxtStoreBWeek3.Location = new Point(533, 43);
            mTxtStoreBWeek3.Multiline = true;
            mTxtStoreBWeek3.Name = "mTxtStoreBWeek3";
            mTxtStoreBWeek3.Size = new Size(260, 444);
            mTxtStoreBWeek3.TabIndex = 2;
            // 
            // mTxtSpices
            // 
            mTxtSpices.Location = new Point(799, 43);
            mTxtSpices.Multiline = true;
            mTxtSpices.Name = "mTxtSpices";
            mTxtSpices.Size = new Size(260, 343);
            mTxtSpices.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 4;
            label1.Text = "StoreA Month";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 9);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 5;
            label2.Text = "StoreB Weeks 1 and 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(533, 9);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 6;
            label3.Text = "StoreB Weeks 3 and 4";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(799, 9);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 7;
            label4.Text = "Spices";
            // 
            // mBtnOpenCalanderImage
            // 
            mBtnOpenCalanderImage.Location = new Point(799, 392);
            mBtnOpenCalanderImage.Name = "mBtnOpenCalanderImage";
            mBtnOpenCalanderImage.Size = new Size(260, 95);
            mBtnOpenCalanderImage.TabIndex = 8;
            mBtnOpenCalanderImage.Text = "open calander image";
            mBtnOpenCalanderImage.UseVisualStyleBackColor = true;
            mBtnOpenCalanderImage.Click += mBtnOpenCalanderImage_Click;
            // 
            // show_buy_lists_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 502);
            Controls.Add(mBtnOpenCalanderImage);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mTxtSpices);
            Controls.Add(mTxtStoreBWeek3);
            Controls.Add(mTxtStoreBWeek1);
            Controls.Add(mTxtMonth);
            Name = "show_buy_lists_form";
            Text = "show_buy_lists_form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mTxtMonth;
        private TextBox mTxtStoreBWeek1;
        private TextBox mTxtStoreBWeek3;
        private TextBox mTxtSpices;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button mBtnOpenCalanderImage;
    }
}