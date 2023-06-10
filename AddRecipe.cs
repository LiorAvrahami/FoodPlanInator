using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace FoodPlanInator {
    public partial class AddRecipe : Form {
        public AddRecipe() {
            InitializeComponent();
            reload_ingrediants_list();
            reload_all_recipes_list();
            init_GridView();
        }

        // ------------------------------ Ingrediants Logic

        float calculate_ingrediant_match_score(string ingrediant_name) {
            // low score means good match
            return StringSimilarityMetric.Compute(ingrediant_name, m_TxtBoxIngrediantSearch.Text);
        }

        // in the n'th cell is the ingrediant-id of the n'th best match
        long[] ingr_idx_to_id_map = null;

        long get_selected_ingrediant_id() {
            if (mIngrediantListBox.SelectedIndex == -1) {
                return 0;
            }
            return ingr_idx_to_id_map[mIngrediantListBox.SelectedIndex];
        }

        void set_selected_ingrediant(long id) {
            mIngrediantListBox.SelectedIndex = Array.IndexOf(ingr_idx_to_id_map, id);
        }

        void reload_ingrediants_list() {
            // load list of ingrediants
            List<Ingrediant> ingrediants_list = RecipiesArchiveIntf.get_all_ingrediants();
            float[] scores = new float[ingrediants_list.Count];
            long[] idx_arr = new long[ingrediants_list.Count];

            // sort ingrediants list by how closely they match filter.
            for (int i = 0; i < scores.Length; i++) {
                scores[i] = calculate_ingrediant_match_score(ingrediants_list[i].name);
                idx_arr[i] = ingrediants_list[i].id;
            }
            Array.Sort(scores, idx_arr);
            ingr_idx_to_id_map = idx_arr;

            // populate mIngrediantListBox
            mIngrediantListBox.Items.Clear();
            for (int i = 0; i < ingr_idx_to_id_map.Length; i++) {
                mIngrediantListBox.Items.Add(RecipiesArchiveIntf.get_Ingrediant(ingr_idx_to_id_map[i]).name);
            }
        }

        private void mBtnAddIngrediants_Click(object sender, EventArgs e) {
            long new_ingrediant_id = AddIngrediantForm.AddNew();
            reload_ingrediants_list();
            set_selected_ingrediant(new_ingrediant_id);

        }

        private void mBtnEditIngrediants_Click(object sender, EventArgs e) {
            long ingrediant_id = get_selected_ingrediant_id();
            if (ingrediant_id == 0) {
                return;
            }
            AddIngrediantForm.EditOld(ingrediant_id);
            reload_ingrediants_list();
            set_selected_ingrediant(ingrediant_id);
        }

        private void m_TxtBoxIngrediantSearch_TextChanged(object sender, EventArgs e) {
            reload_ingrediants_list();
        }

        private void mIngrediantListBox_DoubleClick(object sender, EventArgs e) {
            mBtnEditIngrediants_Click(null, null);
        }

        int realSelecttedIngrediantIndex = -1;
        private void mIngrediantListBox_SelectedIndexChanged(object sender, EventArgs e) {
            mTxtBx_IngrediantUnits.Text = RecipiesArchiveIntf.get_Ingrediant(get_selected_ingrediant_id()).units;
            ListBox listBoxSender = (ListBox)sender;
            realSelecttedIngrediantIndex = listBoxSender.SelectedIndex;
            listBoxSender.Refresh();

        }

        private void mIngrediantListBox_DrawItem(object sender, DrawItemEventArgs e) {
            ListBoxUtil.DrawListBoxItem(realSelecttedIngrediantIndex, sender, e);
        }

        private IngrediantAmmount make_ingrediant_ammount() {
            if (get_selected_ingrediant_id() == 0) {
                return null;
            }
            float ammount;
            try {
                ammount = float.Parse(mTxtBx_Ammount.Text);
            } catch (Exception ex) {
                MessageBox.Show("Amount must be number");
                return null;
            }
            return new IngrediantAmmount(get_selected_ingrediant_id(), ammount);
        }

        private void mIngrediantListBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (get_selected_ingrediant_id() != 0) {
                    Ingrediant ingred = RecipiesArchiveIntf.get_Ingrediant(get_selected_ingrediant_id());
                    DialogResult dialogResult = MessageBox.Show("You are about to delete ingrediant: \"" + ingred.name + "\" are you sure?",
                        "Delete Ingrediant", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) {
                        bool success = false;
                        success = RecipiesArchiveIntf.delete_Ingrediant(ingred.id, false);
                        // force delete, it is commentted out because it is too destructive.
                        /*
                        if (!success) {
                            dialogResult = MessageBox.Show("do you want to FORCE DELETE the ingrediant: \"" + ingred.name + "\"? THIS IS NOT ADVISED!",
                                "Delete Ingrediant", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes) {
                                success = RecipiesArchiveIntf.delete_Ingrediant(ingred.id, true);
                                if (!success) {
                                    throw new Exception("UNEXPECTTED ERROR: couldn't delete");
                                }
                            }
                        }
                        */
                    }
                }
            }
            reload_ingrediants_list();
        }

        // ------------------------------ Recipe Creator Logic
        DataTable SelecttedIngrediants_View;

        void init_GridView() {

            SelecttedIngrediants_View = new DataTable();
            SelecttedIngrediants_View.Columns.Add("ingrediant_id");
            SelecttedIngrediants_View.Columns[0].DefaultValue = 0;
            SelecttedIngrediants_View.Columns.Add("name");
            SelecttedIngrediants_View.Columns.Add("units");
            SelecttedIngrediants_View.Columns.Add("amount");


            mGridView_SelecttedIngrediants.DataSource = SelecttedIngrediants_View;
            mGridView_SelecttedIngrediants.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in mGridView_SelecttedIngrediants.Columns) {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            mGridView_SelecttedIngrediants.Columns[1].Width = 160;
            mGridView_SelecttedIngrediants.Columns[2].Width = 80;
            mGridView_SelecttedIngrediants.Columns[3].Width = 60;
        }
        private void fill_row(DataRow row, IngrediantAmmount new_ingrediant_ammount) {
            Ingrediant cur_ingrediant = RecipiesArchiveIntf.get_Ingrediant(new_ingrediant_ammount.ingrediant_id);
            row[0] = new_ingrediant_ammount.ingrediant_id;
            row[1] = cur_ingrediant.name;
            row[2] = cur_ingrediant.units;
            row[3] = new_ingrediant_ammount.ammount;
        }

        private IngrediantAmmount row_index_to_ingrediant_ammount(int index) {
            DataRow row = SelecttedIngrediants_View.Rows[index];
            return new IngrediantAmmount(long.Parse((string)row[0]), float.Parse((string)row[3]));
        }

        private bool ignore_selection_changed = false;
        private void mGridView_SelecttedIngrediants_SelectionChanged(object sender, EventArgs e) {
            if (this.ignore_selection_changed) { return; }

            int selected_row_index = recipe_creator_get_selected_index();
            if (selected_row_index == -1) { return; }

            this.ignore_selection_changed = true;
            mGridView_SelecttedIngrediants.Rows[selected_row_index].Selected = true;
            this.ignore_selection_changed = false;
        }

        private int recipe_creator_get_selected_index() {
            if (mGridView_SelecttedIngrediants.SelectedCells.Count == 0) { return -1; }
            return mGridView_SelecttedIngrediants.SelectedCells[0].RowIndex;
        }

        private List<IngrediantAmmount> get_ingrediant_list() {
            List<IngrediantAmmount> ret = new List<IngrediantAmmount>();
            for (int i = 0; i < this.SelecttedIngrediants_View.Rows.Count; i++) {
                ret.Add(row_index_to_ingrediant_ammount(i));
            }
            return ret;
        }

        private void set_ingrediant_list(List<IngrediantAmmount> list) {
            foreach (IngrediantAmmount item in list) {
                add_row_to_recipe_creator(item);
            }
        }

        private void add_row_to_recipe_creator(IngrediantAmmount new_ingrediant_ammount) {

            DataRow row = SelecttedIngrediants_View.NewRow();
            fill_row(row, new_ingrediant_ammount);
            SelecttedIngrediants_View.Rows.Add(row);
        }

        private void edit_row_of_recipe_creator(int edit_index, IngrediantAmmount new_ingrediant_ammount) {
            DataRow row = SelecttedIngrediants_View.Rows[edit_index];
            fill_row(row, new_ingrediant_ammount);
        }

        private void mBtn_AppendIngrediant_Click(object sender, EventArgs e) {
            IngrediantAmmount new_ingrediant_ammount = make_ingrediant_ammount();
            if (new_ingrediant_ammount == null) {
                return;
            }
            add_row_to_recipe_creator(new_ingrediant_ammount);
        }

        private void mBtnConfirmEdit_Click(object sender, EventArgs e) {
            int index = recipe_creator_get_selected_index();
            // update selected recipe-item to be pulled from ingrediantes view.
            IngrediantAmmount new_ingrediant_ammount = make_ingrediant_ammount();
            if (new_ingrediant_ammount == null || index == -1) {
                return;
            }
            edit_row_of_recipe_creator(index, new_ingrediant_ammount);
        }

        private void mRecipe_ListBox_MouseClick(object sender, MouseEventArgs e) {
            // whenever a recipe-item is clicked, open it up in the ingrediants view.
            if (recipe_creator_get_selected_index() == -1) {
                return;
            }
            IngrediantAmmount cur_ingred_amount = row_index_to_ingrediant_ammount(recipe_creator_get_selected_index());
            m_TxtBoxIngrediantSearch.Text = cur_ingred_amount.get_ingrediant().name;
            mIngrediantListBox.SelectedIndex = 0;
            if ((string)mIngrediantListBox.Items[mIngrediantListBox.SelectedIndex] != cur_ingred_amount.get_ingrediant().name) {
                MessageBox.Show("wierd error occured");
                return;
            }
            mTxtBx_Ammount.Text = cur_ingred_amount.ammount.ToString();
        }

        private Recipe makeRecipe(long recipe_id_to_use) {
            if (mTxtBxNewRecipeName.Text == null || mTxtBxNewRecipeName.Text == "") {
                MessageBox.Show("enter new recipe name");
                return null;
            }
            if (SelecttedIngrediants_View.Rows.Count == 0) {
                MessageBox.Show("recipe can't be empty");
                return null;
            }

            if (recipe_id_to_use == 0) {
                recipe_id_to_use = RecipiesArchiveIntf.get_unused_id();
            }
            Recipe new_recipe = new Recipe(recipe_id_to_use, mTxtBxNewRecipeName.Text, get_ingrediant_list());
            SelecttedIngrediants_View.Clear();
            mTxtBxNewRecipeName.Text = "";
            return new_recipe;
        }

        private void mBtnSubmitRecipe_Click(object sender, EventArgs e) {
            Recipe new_recipe = makeRecipe(0);
            if (new_recipe == null) {
                return;
            }
            RecipiesArchiveIntf.add_recipe(new_recipe);
            reload_all_recipes_list();
        }

        private void mGridView_SelecttedIngrediants_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (recipe_creator_get_selected_index() != -1) {
                    mGridView_SelecttedIngrediants.Rows.RemoveAt(recipe_creator_get_selected_index());
                }
            }
        }


        // ------------------------------ Recipe List Logic

        float calculate_recipe_match_score(string recipe_name) {
            // low score means good match
            return StringSimilarityMetric.Compute(recipe_name, mTxtBx_RecipeSearch.Text);
        }

        // in the n'th cell is the recipe-id of the n'th best match
        long[] recipe_idx_to_id_map = null;

        long get_selected_recipe_id() {
            if (mListBx_Recipes.SelectedIndex == -1) {
                return 0;
            }
            return recipe_idx_to_id_map[mListBx_Recipes.SelectedIndex];
        }

        void set_selected_recipe(long id) {
            mListBx_Recipes.SelectedIndex = Array.IndexOf(recipe_idx_to_id_map, id);
        }

        void reload_all_recipes_list() {
            // load list of recipes
            List<Recipe> recipes_list = RecipiesArchiveIntf.get_all_recipes();
            float[] scores = new float[recipes_list.Count];
            long[] idx_arr = new long[recipes_list.Count];

            // sort recipes list by how closely they match filter.
            for (int i = 0; i < scores.Length; i++) {
                scores[i] = calculate_recipe_match_score(recipes_list[i].name);
                idx_arr[i] = recipes_list[i].id;
            }
            Array.Sort(scores, idx_arr);
            recipe_idx_to_id_map = idx_arr;

            // populate mListBox
            mListBx_Recipes.Items.Clear();
            for (int i = 0; i < recipe_idx_to_id_map.Length; i++) {
                mListBx_Recipes.Items.Add(RecipiesArchiveIntf.get_recipe(recipe_idx_to_id_map[i]).name);
            }
        }

        private void mTxtBx_RecipeSearch_TextChanged(object sender, EventArgs e) {
            reload_all_recipes_list();
        }

        private void mListBx_Recipes_MouseDoubleClick(object sender, MouseEventArgs e) {
            Recipe selected_recipe = RecipiesArchiveIntf.get_recipe(get_selected_recipe_id());
            mTxtBxNewRecipeName.Text = selected_recipe.name;
            SelecttedIngrediants_View.Clear();
            set_ingrediant_list(new List<IngrediantAmmount>(selected_recipe.ingrediants));
        }

        private void mBtn_SaveRecieEdits_Click(object sender, EventArgs e) {
            Recipe old_recipe = RecipiesArchiveIntf.get_recipe(get_selected_recipe_id());
            Recipe new_recipe = makeRecipe(old_recipe.id);
            if (new_recipe == null) {
                return;
            }
            old_recipe.overwrite(new_recipe);
            RecipiesArchiveIntf.save();
            reload_all_recipes_list();
        }

        private void AddRecipe_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        int realSelecttedRecipeIndex = -1;
        private void mListBx_Recipes_SelectedIndexChanged(object sender, EventArgs e) {
            ListBox listBoxSender = (ListBox)sender;
            realSelecttedRecipeIndex = listBoxSender.SelectedIndex;
            listBoxSender.Refresh();
        }

        private void mListBx_Recipes_DrawItem(object sender, DrawItemEventArgs e) {
            ListBoxUtil.DrawListBoxItem(realSelecttedRecipeIndex, sender, e);
        }

        private void mListBx_Recipes_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (get_selected_recipe_id() != 0) {
                    Recipe recipe = RecipiesArchiveIntf.get_recipe(get_selected_recipe_id());
                    DialogResult dialogResult = MessageBox.Show("You are about to delete recipe: \"" + recipe.name + "\" are you sure?",
                        "Delete Recipe", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) {
                        RecipiesArchiveIntf.delete_recipe(recipe.id);
                    }
                }
            }
            reload_all_recipes_list();
        }

    }
}