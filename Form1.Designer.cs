namespace FoodPlanInator {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            mBtn_EditRecepies = new Button();
            mBtn_ExportToImage = new Button();
            mBtn_SaveToJson = new Button();
            mBtn_LoadJson = new Button();
            mBtn_SelectMonth = new Button();
            panel1 = new Panel();
            MonthLabel = new Label();
            listBox1 = new ListBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // mBtn_EditRecepies
            // 
            mBtn_EditRecepies.Location = new Point(964, 12);
            mBtn_EditRecepies.Name = "mBtn_EditRecepies";
            mBtn_EditRecepies.Size = new Size(150, 80);
            mBtn_EditRecepies.TabIndex = 1;
            mBtn_EditRecepies.Text = "Edit Recipies";
            mBtn_EditRecepies.UseVisualStyleBackColor = true;
            mBtn_EditRecepies.Click += mBtn_EditRecepies_Click;
            // 
            // mBtn_ExportToImage
            // 
            mBtn_ExportToImage.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            mBtn_ExportToImage.ForeColor = Color.DarkOliveGreen;
            mBtn_ExportToImage.Location = new Point(12, 54);
            mBtn_ExportToImage.Name = "mBtn_ExportToImage";
            mBtn_ExportToImage.Size = new Size(150, 38);
            mBtn_ExportToImage.TabIndex = 2;
            mBtn_ExportToImage.Text = "Submit Food Plan";
            mBtn_ExportToImage.UseVisualStyleBackColor = true;
            mBtn_ExportToImage.Click += mBtn_ExportToImage_Click;
            // 
            // mBtn_SaveToJson
            // 
            mBtn_SaveToJson.Location = new Point(168, 12);
            mBtn_SaveToJson.Name = "mBtn_SaveToJson";
            mBtn_SaveToJson.RightToLeft = RightToLeft.Yes;
            mBtn_SaveToJson.Size = new Size(150, 36);
            mBtn_SaveToJson.TabIndex = 3;
            mBtn_SaveToJson.Text = "Save Plan To json";
            mBtn_SaveToJson.UseVisualStyleBackColor = true;
            mBtn_SaveToJson.Click += mBtn_SaveToJson_Click;
            // 
            // mBtn_LoadJson
            // 
            mBtn_LoadJson.Location = new Point(168, 55);
            mBtn_LoadJson.Name = "mBtn_LoadJson";
            mBtn_LoadJson.Size = new Size(150, 38);
            mBtn_LoadJson.TabIndex = 4;
            mBtn_LoadJson.Text = "Load Plan From Json";
            mBtn_LoadJson.UseVisualStyleBackColor = true;
            mBtn_LoadJson.Click += mBtn_LoadJson_Click;
            // 
            // mBtn_SelectMonth
            // 
            mBtn_SelectMonth.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            mBtn_SelectMonth.ForeColor = Color.DarkGoldenrod;
            mBtn_SelectMonth.Location = new Point(12, 12);
            mBtn_SelectMonth.Name = "mBtn_SelectMonth";
            mBtn_SelectMonth.Size = new Size(150, 36);
            mBtn_SelectMonth.TabIndex = 5;
            mBtn_SelectMonth.Text = "Select Month";
            mBtn_SelectMonth.UseVisualStyleBackColor = true;
            mBtn_SelectMonth.Click += mBtn_SelectMonth_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(MonthLabel);
            panel1.Location = new Point(12, 98);
            panel1.Name = "panel1";
            panel1.Size = new Size(1102, 658);
            panel1.TabIndex = 6;
            // 
            // MonthLabel
            // 
            MonthLabel.AutoSize = true;
            MonthLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            MonthLabel.Location = new Point(2, 3);
            MonthLabel.Name = "MonthLabel";
            MonthLabel.Size = new Size(51, 20);
            MonthLabel.TabIndex = 0;
            MonthLabel.Text = "label1";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Items.AddRange(new object[] { "קמון קל", "גמל ישן", "קקוס" });
            listBox1.Location = new Point(476, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 49);
            listBox1.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 768);
            Controls.Add(listBox1);
            Controls.Add(panel1);
            Controls.Add(mBtn_SelectMonth);
            Controls.Add(mBtn_LoadJson);
            Controls.Add(mBtn_SaveToJson);
            Controls.Add(mBtn_ExportToImage);
            Controls.Add(mBtn_EditRecepies);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button mBtn_EditRecepies;
        private Button mBtn_ExportToImage;
        private Button mBtn_SaveToJson;
        private Button mBtn_LoadJson;
        private Button mBtn_SelectMonth;
        private Panel panel1;
        private Label MonthLabel;
        private ListBox listBox1;
    }
}