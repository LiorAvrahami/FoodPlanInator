namespace FoodPlanInator {
    partial class AddRecipe {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRecipe));
            mBtnEditIngrediants = new Button();
            m_TxtBoxIngrediantSearch = new TextBox();
            mIngrediantListBox = new ListBox();
            groupBox1 = new GroupBox();
            mTxtBx_Ammount = new TextBox();
            label2 = new Label();
            mTxtBx_IngrediantUnits = new TextBox();
            mBtn_AppendIngrediant = new Button();
            mBtnAddIngrediants = new Button();
            label1 = new Label();
            mBtnSubmitRecipe = new Button();
            mBtnConfirmEdit = new Button();
            label3 = new Label();
            mTxtBxNewRecipeName = new TextBox();
            label4 = new Label();
            groupBox2 = new GroupBox();
            mGridView_SelecttedIngrediants = new DataGridView();
            groupBox3 = new GroupBox();
            label5 = new Label();
            mBtn_SaveRecieEdits = new Button();
            mTxtBx_RecipeSearch = new TextBox();
            mListBx_Recipes = new ListBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mGridView_SelecttedIngrediants).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // mBtnEditIngrediants
            // 
            mBtnEditIngrediants.Location = new Point(149, 550);
            mBtnEditIngrediants.Name = "mBtnEditIngrediants";
            mBtnEditIngrediants.Size = new Size(131, 24);
            mBtnEditIngrediants.TabIndex = 0;
            mBtnEditIngrediants.Text = "Edit Ingrediant";
            mBtnEditIngrediants.UseVisualStyleBackColor = true;
            mBtnEditIngrediants.Click += mBtnEditIngrediants_Click;
            // 
            // m_TxtBoxIngrediantSearch
            // 
            m_TxtBoxIngrediantSearch.Location = new Point(6, 40);
            m_TxtBoxIngrediantSearch.Name = "m_TxtBoxIngrediantSearch";
            m_TxtBoxIngrediantSearch.Size = new Size(274, 23);
            m_TxtBoxIngrediantSearch.TabIndex = 1;
            m_TxtBoxIngrediantSearch.TextChanged += m_TxtBoxIngrediantSearch_TextChanged;
            // 
            // mIngrediantListBox
            // 
            mIngrediantListBox.DrawMode = DrawMode.OwnerDrawFixed;
            mIngrediantListBox.FormattingEnabled = true;
            mIngrediantListBox.ItemHeight = 15;
            mIngrediantListBox.Location = new Point(6, 69);
            mIngrediantListBox.Name = "mIngrediantListBox";
            mIngrediantListBox.Size = new Size(274, 364);
            mIngrediantListBox.TabIndex = 2;
            mIngrediantListBox.DrawItem += mIngrediantListBox_DrawItem;
            mIngrediantListBox.SelectedIndexChanged += mIngrediantListBox_SelectedIndexChanged;
            mIngrediantListBox.DoubleClick += mIngrediantListBox_DoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mTxtBx_Ammount);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(mTxtBx_IngrediantUnits);
            groupBox1.Controls.Add(mBtnEditIngrediants);
            groupBox1.Controls.Add(mBtn_AppendIngrediant);
            groupBox1.Controls.Add(mBtnAddIngrediants);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(m_TxtBoxIngrediantSearch);
            groupBox1.Controls.Add(mIngrediantListBox);
            groupBox1.Location = new Point(615, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(286, 583);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Select Ingrediant";
            // 
            // mTxtBx_Ammount
            // 
            mTxtBx_Ammount.Location = new Point(6, 441);
            mTxtBx_Ammount.Name = "mTxtBx_Ammount";
            mTxtBx_Ammount.Size = new Size(274, 23);
            mTxtBx_Ammount.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 467);
            label2.Name = "label2";
            label2.Size = new Size(34, 15);
            label2.TabIndex = 7;
            label2.Text = "Units";
            // 
            // mTxtBx_IngrediantUnits
            // 
            mTxtBx_IngrediantUnits.Enabled = false;
            mTxtBx_IngrediantUnits.Location = new Point(6, 485);
            mTxtBx_IngrediantUnits.Name = "mTxtBx_IngrediantUnits";
            mTxtBx_IngrediantUnits.Size = new Size(274, 23);
            mTxtBx_IngrediantUnits.TabIndex = 6;
            // 
            // mBtn_AppendIngrediant
            // 
            mBtn_AppendIngrediant.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            mBtn_AppendIngrediant.ForeColor = Color.DarkOliveGreen;
            mBtn_AppendIngrediant.Location = new Point(6, 514);
            mBtn_AppendIngrediant.Name = "mBtn_AppendIngrediant";
            mBtn_AppendIngrediant.Size = new Size(274, 30);
            mBtn_AppendIngrediant.TabIndex = 4;
            mBtn_AppendIngrediant.Text = "⬅️ Add To Recipe ⬅️";
            mBtn_AppendIngrediant.UseVisualStyleBackColor = true;
            mBtn_AppendIngrediant.Click += mBtn_AppendIngrediant_Click;
            // 
            // mBtnAddIngrediants
            // 
            mBtnAddIngrediants.Location = new Point(6, 550);
            mBtnAddIngrediants.Name = "mBtnAddIngrediants";
            mBtnAddIngrediants.Size = new Size(137, 24);
            mBtnAddIngrediants.TabIndex = 4;
            mBtnAddIngrediants.Text = "New Ingrediant";
            mBtnAddIngrediants.UseVisualStyleBackColor = true;
            mBtnAddIngrediants.Click += mBtnAddIngrediants_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 22);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 3;
            label1.Text = "Search";
            // 
            // mBtnSubmitRecipe
            // 
            mBtnSubmitRecipe.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            mBtnSubmitRecipe.ForeColor = Color.DarkOliveGreen;
            mBtnSubmitRecipe.Location = new Point(87, 537);
            mBtnSubmitRecipe.Name = "mBtnSubmitRecipe";
            mBtnSubmitRecipe.Size = new Size(144, 41);
            mBtnSubmitRecipe.TabIndex = 8;
            mBtnSubmitRecipe.Text = "Save New Recipe";
            mBtnSubmitRecipe.UseVisualStyleBackColor = true;
            mBtnSubmitRecipe.Click += mBtnSubmitRecipe_Click;
            // 
            // mBtnConfirmEdit
            // 
            mBtnConfirmEdit.Location = new Point(237, 538);
            mBtnConfirmEdit.Name = "mBtnConfirmEdit";
            mBtnConfirmEdit.Size = new Size(87, 23);
            mBtnConfirmEdit.TabIndex = 9;
            mBtnConfirmEdit.Text = "Confirm Edit";
            mBtnConfirmEdit.UseVisualStyleBackColor = true;
            mBtnConfirmEdit.Click += mBtnConfirmEdit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 27);
            label3.Name = "label3";
            label3.Size = new Size(104, 15);
            label3.TabIndex = 9;
            label3.Text = "New Recipe Name";
            // 
            // mTxtBxNewRecipeName
            // 
            mTxtBxNewRecipeName.Location = new Point(6, 45);
            mTxtBxNewRecipeName.Name = "mTxtBxNewRecipeName";
            mTxtBxNewRecipeName.Size = new Size(318, 23);
            mTxtBxNewRecipeName.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 71);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 10;
            label4.Text = "Ingrediants";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(mGridView_SelecttedIngrediants);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(mBtnSubmitRecipe);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(mBtnConfirmEdit);
            groupBox2.Controls.Add(mTxtBxNewRecipeName);
            groupBox2.Location = new Point(276, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(333, 586);
            groupBox2.TabIndex = 11;
            groupBox2.TabStop = false;
            groupBox2.Text = "Recipe Creation Area";
            // 
            // mGridView_SelecttedIngrediants
            // 
            mGridView_SelecttedIngrediants.AllowUserToAddRows = false;
            mGridView_SelecttedIngrediants.AllowUserToDeleteRows = false;
            mGridView_SelecttedIngrediants.AllowUserToResizeRows = false;
            mGridView_SelecttedIngrediants.BackgroundColor = SystemColors.Control;
            mGridView_SelecttedIngrediants.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mGridView_SelecttedIngrediants.Location = new Point(9, 91);
            mGridView_SelecttedIngrediants.MultiSelect = false;
            mGridView_SelecttedIngrediants.Name = "mGridView_SelecttedIngrediants";
            mGridView_SelecttedIngrediants.ReadOnly = true;
            mGridView_SelecttedIngrediants.RowHeadersWidth = 4;
            mGridView_SelecttedIngrediants.RowTemplate.Height = 25;
            mGridView_SelecttedIngrediants.Size = new Size(315, 440);
            mGridView_SelecttedIngrediants.TabIndex = 11;
            mGridView_SelecttedIngrediants.SelectionChanged += mGridView_SelecttedIngrediants_SelectionChanged;
            mGridView_SelecttedIngrediants.KeyDown += AddRecipe_KeyDown;
            mGridView_SelecttedIngrediants.MouseClick += mRecipe_ListBox_MouseClick;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(mBtn_SaveRecieEdits);
            groupBox3.Controls.Add(mTxtBx_RecipeSearch);
            groupBox3.Controls.Add(mListBx_Recipes);
            groupBox3.Location = new Point(12, 12);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(258, 586);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Recipies List";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 22);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 9;
            label5.Text = "Search";
            // 
            // mBtn_SaveRecieEdits
            // 
            mBtn_SaveRecieEdits.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            mBtn_SaveRecieEdits.ForeColor = Color.DarkOliveGreen;
            mBtn_SaveRecieEdits.Location = new Point(59, 537);
            mBtn_SaveRecieEdits.Name = "mBtn_SaveRecieEdits";
            mBtn_SaveRecieEdits.Size = new Size(132, 41);
            mBtn_SaveRecieEdits.TabIndex = 11;
            mBtn_SaveRecieEdits.Text = "Save Edit";
            mBtn_SaveRecieEdits.UseVisualStyleBackColor = true;
            mBtn_SaveRecieEdits.Click += mBtn_SaveRecieEdits_Click;
            // 
            // mTxtBx_RecipeSearch
            // 
            mTxtBx_RecipeSearch.Location = new Point(6, 40);
            mTxtBx_RecipeSearch.Name = "mTxtBx_RecipeSearch";
            mTxtBx_RecipeSearch.Size = new Size(244, 23);
            mTxtBx_RecipeSearch.TabIndex = 8;
            mTxtBx_RecipeSearch.TextChanged += mTxtBx_RecipeSearch_TextChanged;
            // 
            // mListBx_Recipes
            // 
            mListBx_Recipes.DrawMode = DrawMode.OwnerDrawFixed;
            mListBx_Recipes.FormattingEnabled = true;
            mListBx_Recipes.ItemHeight = 15;
            mListBx_Recipes.Location = new Point(6, 70);
            mListBx_Recipes.Name = "mListBx_Recipes";
            mListBx_Recipes.Size = new Size(244, 469);
            mListBx_Recipes.TabIndex = 0;
            mListBx_Recipes.DrawItem += mListBx_Recipes_DrawItem;
            mListBx_Recipes.SelectedIndexChanged += mListBx_Recipes_SelectedIndexChanged;
            mListBx_Recipes.MouseDoubleClick += mListBx_Recipes_MouseDoubleClick;
            // 
            // AddRecipe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 606);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AddRecipe";
            Text = "AddRecipe";
            KeyDown += AddRecipe_KeyDown;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mGridView_SelecttedIngrediants).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button mBtnEditIngrediants;
        private TextBox m_TxtBoxIngrediantSearch;
        private ListBox mIngrediantListBox;
        private GroupBox groupBox1;
        private Button mBtn_AppendIngrediant;
        private Label label1;
        private TextBox mTxtBx_IngrediantUnits;
        private Button mBtnAddIngrediants;
        private Label label2;
        private Button mBtnSubmitRecipe;
        private Button mBtnConfirmEdit;
        private Label label3;
        private TextBox mTxtBxNewRecipeName;
        private Label label4;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label5;
        private Button mBtn_SaveRecieEdits;
        private TextBox mTxtBx_RecipeSearch;
        private ListBox mListBx_Recipes;
        private TextBox mTxtBx_Ammount;
        private DataGridView mGridView_SelecttedIngrediants;
    }
}