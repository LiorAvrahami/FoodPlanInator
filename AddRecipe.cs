﻿using System;
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
        DataTable SelecttedIngrediants_View;
        public AddRecipe() {
            InitializeComponent();
            reload_ingrediants_list();
            reload_all_recipes_list();

            SelecttedIngrediants_View = new DataTable();
            SelecttedIngrediants_View.Columns.Add("name");
            SelecttedIngrediants_View.Columns.Add("units");
            SelecttedIngrediants_View.Columns.Add("amount");

            mGridView_SelecttedIngrediants.DataSource = SelecttedIngrediants_View;

            for (int i = 0; i < 5; i++) {
                DataRow row = SelecttedIngrediants_View.NewRow();
                row[0] = "lior" + (5 - i).ToString();
                row[1] = "kg";
                row[2] = i.ToString();
                SelecttedIngrediants_View.Rows.Add(row);
            }

            //SelecttedIngrediants_View.Columns.AddRange();
        }

        // Ingrediants Logic

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

        // Recipe Creator Logic

        List<IngrediantAmmount> current_recipe_ingrediants_list = new List<IngrediantAmmount>();

        private void reload_current_recipe_list() {
            mRecipe_ListBox.Items.Clear();
            foreach (var item in current_recipe_ingrediants_list) {
                Ingrediant ingred = RecipiesArchiveIntf.get_Ingrediant(item.ingrediant_id);
                mRecipe_ListBox.Items.Add(ingred.name + ", " + ingred.units + ", " + item.ammount.ToString());
            }
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

        private void mBtn_AppendIngrediant_Click(object sender, EventArgs e) {
            IngrediantAmmount new_ingrediant_ammount = make_ingrediant_ammount();
            if (new_ingrediant_ammount == null) {
                return;
            }
            current_recipe_ingrediants_list.Add(new_ingrediant_ammount);
            reload_current_recipe_list();
        }

        private void mBtnSwapUp_Click(object sender, EventArgs e) {
            int idx = mRecipe_ListBox.SelectedIndex;
            dynamic temp = current_recipe_ingrediants_list[idx];
            if (idx > 0) {
                current_recipe_ingrediants_list[idx] = current_recipe_ingrediants_list[idx - 1];
                current_recipe_ingrediants_list[idx - 1] = temp;
                reload_current_recipe_list();
                mRecipe_ListBox.SelectedIndex = idx - 1;
            }
        }

        private void mBtnConfirmEdit_Click(object sender, EventArgs e) {
            int index = mRecipe_ListBox.SelectedIndex;
            // update selected recipe-item to be pulled from ingrediantes view.
            IngrediantAmmount new_ingrediant_ammount = make_ingrediant_ammount();
            if (new_ingrediant_ammount == null || index == -1) {
                return;
            }
            current_recipe_ingrediants_list[index] = (new_ingrediant_ammount);
            reload_current_recipe_list();
        }

        private void mRecipe_ListBox_MouseClick(object sender, MouseEventArgs e) {
            // whenever a recipe-item is clicked, open it up in the ingrediants view.
            if (mRecipe_ListBox.SelectedIndex == -1) {
                return;
            }
            IngrediantAmmount cur_ingred_amount = current_recipe_ingrediants_list[mRecipe_ListBox.SelectedIndex];
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
            if (current_recipe_ingrediants_list == null || current_recipe_ingrediants_list.Count == 0) {
                MessageBox.Show("recipe can't be empty");
                return null;
            }

            if (recipe_id_to_use == 0) {
                recipe_id_to_use = RecipiesArchiveIntf.get_unused_id();
            }
            Recipe new_recipe = new Recipe(recipe_id_to_use, mTxtBxNewRecipeName.Text, current_recipe_ingrediants_list);
            current_recipe_ingrediants_list = new List<IngrediantAmmount>();
            mTxtBxNewRecipeName.Text = "";
            reload_current_recipe_list();
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

        private void mRecipe_ListBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                if (mRecipe_ListBox.SelectedIndex != -1) {
                    current_recipe_ingrediants_list.RemoveAt(mRecipe_ListBox.SelectedIndex);
                }
                reload_current_recipe_list();
            }
        }

        int realSelecttedRecipeCreationIndex = -1;
        private void mRecipe_ListBox_SelectedIndexChanged(object sender, EventArgs e) {
            ListBox listBoxSender = (ListBox)sender;
            realSelecttedRecipeCreationIndex = listBoxSender.SelectedIndex;
            listBoxSender.Refresh();
        }

        private void mRecipe_ListBox_DrawItem(object sender, DrawItemEventArgs e) {
            ListBoxUtil.DrawListBoxItem(realSelecttedRecipeCreationIndex, sender, e);
        }

        private bool ignore_selection_changed = false;
        private void mGridView_SelecttedIngrediants_SelectionChanged(object sender, EventArgs e) {
            if (this.ignore_selection_changed) { return; }
            if (mGridView_SelecttedIngrediants.SelectedCells.Count == 0) { return; }
            this.ignore_selection_changed = true;

            int selected_row_index = mGridView_SelecttedIngrediants.SelectedCells[0].RowIndex;
            mGridView_SelecttedIngrediants.Rows[selected_row_index].Selected = true;

            this.ignore_selection_changed = false;
        }


        // Recipe List Logic

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
            current_recipe_ingrediants_list.Clear();
            current_recipe_ingrediants_list = new List<IngrediantAmmount>(selected_recipe.ingrediants);
            reload_current_recipe_list();
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
    }
}