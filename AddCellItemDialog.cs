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
        // return vlaue of this form
        public long mSelected_recipe_id = 0;

        // used for recipes gridview
        DataTable SelecttedIngrediants_View;

        public AddCellItemDialog() {
            InitializeComponent();

            SelecttedIngrediants_View = new DataTable();
            SelecttedIngrediants_View.Columns.Add("recipe_id");
            SelecttedIngrediants_View.Columns[0].DefaultValue = 0;
            SelecttedIngrediants_View.Columns.Add("search_match_score");
            SelecttedIngrediants_View.Columns[1].DefaultValue = 0;
            SelecttedIngrediants_View.Columns.Add("Name");
            SelecttedIngrediants_View.Columns.Add("Servings");
            SelecttedIngrediants_View.Columns.Add("Work Per Serving [sec]");
            SelecttedIngrediants_View.Columns.Add("Price Per Serving");

            fill_table();

            this.mTextBoxFilter.Focus();
        }

        void fill_table() {
            SelecttedIngrediants_View.Clear();

            foreach (Recipe recipe in RecipiesArchiveIntf.get_all_recipes()) {
                DataRow row = SelecttedIngrediants_View.NewRow();
                row[0] = recipe.id;
                row[1] = calculate_recipe_match_score(recipe.name);
                row[2] = recipe.name;
                row[3] = "Not Avalible";
                row[4] = "Not Avalible";
                row[5] = "Not Avalible";
                SelecttedIngrediants_View.Rows.Add(row);
            }

            dataGridView1.DataSource = SelecttedIngrediants_View;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }

        float calculate_recipe_match_score(string recipe_name) {
            // low score means good match
            return StringSimilarityMetric.Compute(recipe_name, mTextBoxFilter.Text);
        }

        private int get_selected_index() {
            if (dataGridView1.SelectedCells.Count == 0) { return -1; }
            return dataGridView1.SelectedCells[0].RowIndex;
        }

        long get_selected_recipe_id() {
            if (dataGridView1.SelectedCells.Count == 0) { return -1; }
            return long.Parse((string)dataGridView1.SelectedCells[0].OwningRow.Cells[0].Value);
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
            int new_index = get_selected_index() + delta;
            if (new_index < dataGridView1.Rows.Count && new_index >= 0) {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[new_index].Selected = true;
                return true;
            }
            return false;
        }

        private void mBtnSubmit_Click(object sender, EventArgs e) {
            mSelected_recipe_id = get_selected_recipe_id();
            this.Close();
        }

        private bool ignore_selection_changed = false;
        private void mGridView_SelecttedIngrediants_SelectionChanged(object sender, EventArgs e) {
            if (this.ignore_selection_changed) { return; }

            int selected_row_index = get_selected_index();
            if (selected_row_index == -1) { return; }

            this.ignore_selection_changed = true;
            dataGridView1.Rows[selected_row_index].Selected = true;
            this.ignore_selection_changed = false;
        }

        private void mListBox_DoubleClick(object sender, EventArgs e) {
            mBtnSubmit_Click(null, null);
        }

        private void mTextBoxFilter_TextChanged(object sender, EventArgs e) {
            // clear sorting
            foreach (DataGridViewColumn col in dataGridView1.Columns) {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.SortMode = DataGridViewColumnSortMode.Automatic;
            }

            // order by search resutls
            fill_table();

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }
    }
}
