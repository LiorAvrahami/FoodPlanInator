using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FoodPlanInator {
    public partial class AddCellItemDialog : Form {
        public long mSelected_recipe_id = 0;

        public AddCellItemDialog() {
            InitializeComponent();
            reload_recipe_list();
            this.mListBox.SelectedIndex = -1;
            this.mTextBoxFilter.Focus();
        }

        float calculate_recipe_match_score(string recipe_name) {
            // low score means good match
            return StringSimilarityMetric.Compute(recipe_name, mTextBoxFilter.Text);
        }

        // in the n'th cell is the recipe-id of the n'th best match
        long[] idx_to_id_map = null;

        long get_selected_recipe_id() {
            if (mListBox.SelectedIndex == -1) {
                return 0;
            }
            return idx_to_id_map[mListBox.SelectedIndex];
        }

        void set_selected_recipe(long id) {
            mListBox.SelectedIndex = Array.IndexOf(idx_to_id_map, id);
        }

        void reload_recipe_list() {
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
            idx_to_id_map = idx_arr;

            // populate mListBox
            mListBox.Items.Clear();
            for (int i = 0; i < idx_to_id_map.Length; i++) {
                mListBox.Items.Add(RecipiesArchiveIntf.get_recipe(idx_to_id_map[i]).name);
            }
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Enter) {
                KeyDown_priv(keyData);
                //Check the keyData and do your custom processing
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void KeyDown_priv(Keys KeyCode) {
            bool isCtrl = (KeyCode & Keys.Control) == Keys.Control;
            KeyCode &= ~Keys.Control;
            if (KeyCode == Keys.Enter) {
                mBtnSubmit_Click(null, null);
            }
            if (KeyCode == Keys.Down) {
                change_selection(1);
            }
            if (KeyCode == Keys.Up) {
                change_selection(-1);
            }
        }

        public bool change_selection(int delta) {
            int new_index = mListBox.SelectedIndex + delta;
            if (new_index < mListBox.Items.Count && new_index >= 0) {
                mListBox.SelectedIndex = new_index;
                return true;
            }
            return false;
        }

        private void mBtnSubmit_Click(object sender, EventArgs e) {
            mSelected_recipe_id = get_selected_recipe_id();
            this.Close();
        }


        int realSelecttedIndex = -1;
        private void mListBox_SelectedIndexChanged(object sender, EventArgs e) {
            ListBox listBoxSender = (ListBox)sender;
            realSelecttedIndex = listBoxSender.SelectedIndex;
            listBoxSender.Refresh();
        }

        private void mListBox_DrawItem(object sender, DrawItemEventArgs e) {
            ListBoxUtil.DrawListBoxItem(realSelecttedIndex, sender, e);
        }

        private void mListBox_DoubleClick(object sender, EventArgs e) {
            mBtnSubmit_Click(null, null);
        }

        private void mTextBoxFilter_TextChanged(object sender, EventArgs e) {
            reload_recipe_list();
        }
    }
}
