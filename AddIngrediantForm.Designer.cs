namespace FoodPlanInator {
    partial class AddIngrediantForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddIngrediantForm));
            mTxtBx_Name = new TextBox();
            mTxtBx_Units = new TextBox();
            mBtnSubmit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            mBtn_Delete = new Button();
            label4 = new Label();
            mTxtBxAmmount = new TextBox();
            mTxtNumDays = new TextBox();
            label5 = new Label();
            mChkBxListShops = new CheckedListBox();
            SuspendLayout();
            // 
            // mTxtBx_Name
            // 
            mTxtBx_Name.Location = new Point(105, 7);
            mTxtBx_Name.Name = "mTxtBx_Name";
            mTxtBx_Name.Size = new Size(191, 23);
            mTxtBx_Name.TabIndex = 0;
            // 
            // mTxtBx_Units
            // 
            mTxtBx_Units.Location = new Point(104, 168);
            mTxtBx_Units.Name = "mTxtBx_Units";
            mTxtBx_Units.Size = new Size(191, 23);
            mTxtBx_Units.TabIndex = 2;
            // 
            // mBtnSubmit
            // 
            mBtnSubmit.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            mBtnSubmit.ForeColor = Color.DarkOliveGreen;
            mBtnSubmit.Location = new Point(89, 267);
            mBtnSubmit.Name = "mBtnSubmit";
            mBtnSubmit.Size = new Size(206, 41);
            mBtnSubmit.TabIndex = 9;
            mBtnSubmit.Text = "Submit";
            mBtnSubmit.UseVisualStyleBackColor = true;
            mBtnSubmit.Click += mBtnSubmit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 10;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 163);
            label2.Name = "label2";
            label2.Size = new Size(89, 30);
            label2.TabIndex = 11;
            label2.Text = "Final Units \r\nFor Grocery List";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 204);
            label3.Name = "label3";
            label3.Size = new Size(74, 15);
            label3.TabIndex = 12;
            label3.Text = "Price Of Unit";
            // 
            // mBtn_Delete
            // 
            mBtn_Delete.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            mBtn_Delete.ForeColor = Color.DarkRed;
            mBtn_Delete.Location = new Point(11, 267);
            mBtn_Delete.Name = "mBtn_Delete";
            mBtn_Delete.Size = new Size(72, 41);
            mBtn_Delete.TabIndex = 14;
            mBtn_Delete.Text = "Delete";
            mBtn_Delete.UseVisualStyleBackColor = true;
            mBtn_Delete.Click += mBtn_Delete_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 45);
            label4.Name = "label4";
            label4.Size = new Size(76, 30);
            label4.TabIndex = 16;
            label4.Text = "Shops Where\r\nCan Buy";
            // 
            // mTxtBxAmmount
            // 
            mTxtBxAmmount.Location = new Point(104, 201);
            mTxtBxAmmount.Name = "mTxtBxAmmount";
            mTxtBxAmmount.Size = new Size(191, 23);
            mTxtBxAmmount.TabIndex = 17;
            mTxtBxAmmount.Text = "-1";
            // 
            // mTxtNumDays
            // 
            mTxtNumDays.Location = new Point(104, 235);
            mTxtNumDays.Name = "mTxtNumDays";
            mTxtNumDays.Size = new Size(191, 23);
            mTxtNumDays.TabIndex = 19;
            mTxtNumDays.Text = "-1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 238);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 18;
            label5.Text = "Days To Expire";
            // 
            // mChkBxListShops
            // 
            mChkBxListShops.FormattingEnabled = true;
            mChkBxListShops.Location = new Point(105, 42);
            mChkBxListShops.Name = "mChkBxListShops";
            mChkBxListShops.Size = new Size(191, 112);
            mChkBxListShops.TabIndex = 20;
            // 
            // AddIngrediantForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 318);
            Controls.Add(mChkBxListShops);
            Controls.Add(mTxtNumDays);
            Controls.Add(label5);
            Controls.Add(mTxtBxAmmount);
            Controls.Add(label4);
            Controls.Add(mBtn_Delete);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mBtnSubmit);
            Controls.Add(mTxtBx_Units);
            Controls.Add(mTxtBx_Name);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddIngrediantForm";
            Text = "AddIngrediantForm";
            Load += AddIngrediantForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox mTxtBx_Name;
        private TextBox mTxtBx_Units;
        private Button mBtnSubmit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button mBtn_Delete;
        private Label label4;
        private TextBox mTxtBxAmmount;
        private TextBox mTxtNumDays;
        private Label label5;
        private CheckedListBox mChkBxListShops;
    }
}