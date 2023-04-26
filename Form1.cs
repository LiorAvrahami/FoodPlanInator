using Newtonsoft.Json;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FoodPlanInator {
    public partial class Form1 : Form {

        DateTime start_date;
        DateTime end_date;

        List<DayCell> dayCells = new List<DayCell>();

        int findDayCell(ListBox listbox) {
            for (int i = 0; i < dayCells.Count; i++) {
                if (dayCells[i].listBox == this.ActiveControl) {
                    return i;
                }
            }
            throw new Exception("DayCell Not Found");
        }

        void removeDayCellItem(ListBox listbox, int index) {
            int cell_index = findDayCell(listbox);
            dayCells[cell_index].removeItem(index);
        }

        void addDayCellItem(ListBox listbox, long recipe_id) {
            int cell_index = findDayCell(listbox);
            dayCells[cell_index].addItem(recipe_id);
        }

        public Form1() {
            InitializeComponent();

            RecipiesArchiveIntf.init();

            start_date = new DateTime(2023, (int)Math.Round(DateTime.Now.Month + DateTime.Now.Day / 30.0), 1);
            end_date = start_date.AddMonths(1);
            this.make_day_cells();
        }

        void make_day_cells() {
            List<DayCell> newDayCells = new List<DayCell>();

            // iterate over all days betwean start date and end date
            int weekIndex = 0;
            for (DateTime i = this.start_date; i < this.end_date; i = i.AddDays(1)) {
                DayCell newDayCell = new DayCell(i, weekIndex);
                newDayCells.Add(newDayCell);
                if (i.DayOfWeek == DayOfWeek.Saturday) {
                    weekIndex++;
                }
            }

            refreshCalander(newDayCells);
        }

        void refreshCalander(List<DayCell> newDayCells) {
            start_date = newDayCells[0].date;

            // clear calander
            if (dayCells != null) {
                foreach (var day_cell in dayCells) {
                    this.panel1.Controls.Remove(day_cell.listBox);
                    this.panel1.Controls.Remove(day_cell.label);
                }
            }

            this.dayCells = newDayCells;

            // add new daycell to calander
            foreach (var dayCell in this.dayCells) {
                this.panel1.Controls.Add(dayCell.listBox);
                this.panel1.Controls.Add(dayCell.label);
            }

            //set month label
            string[] month_names = { "Jan", "Feb", "March", "April", "May", "June", "July", "August", "Sept", "Oct", "Nov", "Dec" };
            MonthLabel.Text = month_names[start_date.Month - 1];
        }

        private void mBtn_SelectMonth_Click(object sender, EventArgs e) {
            SelectMonth ret = SelectMonth.Prompt(start_date.Month, start_date.Year);
            if (!ret.submitted) {
                return;
            }
            start_date = new DateTime(ret.selectted_year, ret.selectted_month, 1);
            end_date = start_date.AddMonths(1);
            this.make_day_cells();
        }


        private void mBtn_SaveToJson_Click(object sender, EventArgs e) {
            try {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "json|*.json";
                dialog.AddExtension = true;
                if (dialog.ShowDialog() == DialogResult.OK) {
                    DayCell.CompactForm compactForm = DayCell.create_compact_form(dayCells);
                    File.WriteAllText(dialog.FileName, JsonConvert.SerializeObject(compactForm, Formatting.Indented));
                }
            } catch {
                MessageBox.Show("Error, save failed.");
            }
        }

        private void mBtn_LoadJson_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "json|*.json";
                dialog.AddExtension = true;
                if (dialog.ShowDialog() == DialogResult.OK) {
                    string json_text = File.ReadAllText(dialog.FileName);
                    DayCell.CompactForm compactForm = JsonConvert.DeserializeObject<DayCell.CompactForm>(json_text);
                    List<DayCell> newDayCells = DayCell.create_from_json_compact_form(compactForm);
                    refreshCalander(newDayCells);
                }
            } catch {
                MessageBox.Show("Error, save failed.");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Down || keyData == Keys.Up || keyData == Keys.Left || keyData == Keys.Right) {
                KeyDown_priv(keyData);
                //Check the keyData and do your custom processing
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            KeyDown_priv(e.KeyData);
        }

        private void KeyDown_priv(Keys KeyCode) {
            bool isCtrl = (KeyCode & Keys.Control) == Keys.Control;
            KeyCode &= ~Keys.Control;
            if (KeyCode == Keys.Left) {
                move_to_other_cell(-1);
            }
            if (KeyCode == Keys.Right) {
                move_to_other_cell(1);
            }
            if (KeyCode == Keys.Up) {
                bool moved_in_cell;
                if (isCtrl) {
                    moved_in_cell = false;
                } else {
                    moved_in_cell = move_in_cell(-1);
                }
                if (!moved_in_cell) {
                    move_to_other_cell(-7);
                }
            }
            if (KeyCode == Keys.Down) {
                bool moved_in_cell;
                if (isCtrl) {
                    moved_in_cell = false;
                } else {
                    moved_in_cell = move_in_cell(1);
                }
                if (!moved_in_cell) {
                    move_to_other_cell(7);
                }
            }
            if (KeyCode == Keys.Delete) {
                if (this.ActiveControl is ListBox) {
                    ListBox listBox = (this.ActiveControl as ListBox);
                    int index = listBox.SelectedIndex;
                    if (index != -1) {
                        removeDayCellItem(listBox, index);
                    }
                    if (index >= listBox.Items.Count) {
                        index = listBox.Items.Count - 1;
                    }
                    listBox.SelectedIndex = index;
                }
            }
            if (KeyCode == Keys.Enter) {
                AddCellItem();
            }
        }

        public bool move_in_cell(int delta) {
            if (this.ActiveControl is ListBox) {
                ListBox listBox = (ListBox)this.ActiveControl;
                int new_index = listBox.SelectedIndex + delta;
                if (new_index < listBox.Items.Count && new_index >= 0) {
                    listBox.SelectedIndex = new_index;
                    return true;
                }
            }
            return false;
        }
        public void move_to_other_cell(int delta) {
            int selected_day_index = 0;
            if (this.ActiveControl is ListBox) {
                selected_day_index = findDayCell(this.ActiveControl as ListBox);
            }

            selected_day_index += delta;
            if (selected_day_index < 0 || selected_day_index >= dayCells.Count) {
                return;
            }

            int new_selected_day_index = 0;
            if (this.ActiveControl is ListBox) {
                new_selected_day_index = (this.ActiveControl as ListBox).SelectedIndex;
            }

            // select next listbox
            this.ActiveControl = dayCells[selected_day_index].listBox;

            // set selected index of new listbox to be same as last, if last was -1 then set to 0
            if (new_selected_day_index == -1) {
                new_selected_day_index = 0;
            }
            if (new_selected_day_index >= dayCells[selected_day_index].listBox.Items.Count) {
                new_selected_day_index = dayCells[selected_day_index].listBox.Items.Count - 1;
            }
            dayCells[selected_day_index].listBox.SelectedIndex = new_selected_day_index;
        }

        public void AddCellItem() {
            if (!(this.ActiveControl is ListBox)) {
                return;
            }
            ListBox listBox = (ListBox)this.ActiveControl;

            AddCellItemDialog addCellItemDialog = new AddCellItemDialog();
            addCellItemDialog.ShowDialog();
            long selected_recipe_id = addCellItemDialog.mSelected_recipe_id;
            addDayCellItem(listBox, selected_recipe_id);
        }


        class DayCell {
            static int width = 199;
            static int height = 115;

            static int start_x = 10;
            static int start_y = 10;

            public DateTime date;
            public ListBox listBox = new ListBox();
            public List<long> mRecipeIdList = new List<long>();

            public Label label = new Label();

            public DayCell(DateTime date, int weekIndex) {
                this.date = date;
                int x = width * ((int)date.DayOfWeek) + start_x;
                int y = ((height + label.Height) * weekIndex) + start_y + label.Height;
                listBox.Location = new Point(x, y);
                listBox.Width = width;
                listBox.Height = height;
                listBox.Leave += listBox_Leave;
                listBox.Enter += listBox_Enter;
                listBox.DoubleClick += listBox_Click;
                listBox.DrawMode = DrawMode.OwnerDrawFixed;
                listBox.DrawItem += mListBox_DrawItem;
                listBox.SelectedIndexChanged += mListBx_SelectedIndexChanged;


                string[] days_of_the_week = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

                label.Location = new Point(x, y - label.Height + 8);
                label.Text = date.Day + "  " + days_of_the_week[(int)date.DayOfWeek];
            }

            public void assert_legal() {
                if (listBox.Items.Count != mRecipeIdList.Count) {
                    throw new Exception("day-cell is not legal at date " + this.date.ToString());
                }
            }

            public void removeItem(int itemIndex) {
                listBox.Items.RemoveAt(itemIndex);
                mRecipeIdList.RemoveAt(itemIndex);
                assert_legal();
            }

            public void addItem(long recipeId) {
                if (recipeId == 0) {
                    return;
                }
                listBox.Items.Add(RecipiesArchiveIntf.get_recipe(recipeId).name);
                mRecipeIdList.Add(recipeId);
                assert_legal();
            }

            private void listBox_Leave(object sender, EventArgs e) {
                listBox.ClearSelected();
                label.BackColor = Color.White;
            }

            private void listBox_Click(object sender, EventArgs e) {
                AddCellItemDialog addCellItemDialog = new AddCellItemDialog();
                addCellItemDialog.ShowDialog();
                long selected_recipe_id = addCellItemDialog.mSelected_recipe_id;
                this.addItem(selected_recipe_id);
            }

            private void listBox_Enter(object sender, EventArgs e) {

                label.BackColor = Color.FromArgb(255, 255, 220, 220);
            }

            int realSelecttedIndex = -1;
            private void mListBx_SelectedIndexChanged(object sender, EventArgs e) {
                ListBox listBoxSender = (ListBox)sender;
                realSelecttedIndex = listBoxSender.SelectedIndex;
                listBoxSender.Refresh();
            }

            private void mListBox_DrawItem(object sender, DrawItemEventArgs e) {
                ListBoxUtil.DrawListBoxItem(realSelecttedIndex, sender, e);
            }


            // compactify for json
            public class CompactForm {
                public List<List<long>> recipe_ids_list_in_each_day = new List<List<long>>();
                public List<DateTime> list_of_dates = new List<DateTime>();
            }

            public static CompactForm create_compact_form(List<DayCell> dayCells) {
                CompactForm ret = new CompactForm();
                foreach (var item in dayCells) {
                    ret.recipe_ids_list_in_each_day.Add(item.mRecipeIdList);
                    ret.list_of_dates.Add(item.date);
                }
                return ret;
            }

            public static List<DayCell> create_from_json_compact_form(CompactForm compact_form) {

                int weekIndex = 0;
                List<DayCell> ret = new List<DayCell>();
                for (int i = 0; i < compact_form.list_of_dates.Count; i++) {
                    DateTime date = compact_form.list_of_dates[i];

                    // make new daycell
                    ret.Add(new DayCell(date, weekIndex));

                    // add all relevant recipe id's to current cell
                    foreach (long item in compact_form.recipe_ids_list_in_each_day[i]) {
                        ret.Last().addItem(item);
                    }

                    if (date.DayOfWeek == DayOfWeek.Saturday) {
                        weekIndex++;
                    }

                }
                return ret;
            }

        }

        private void mBtn_EditRecepies_Click(object sender, EventArgs e) {
            new AddRecipe().ShowDialog();
        }

        private void mBtn_ExportToImage_Click(object sender, EventArgs e) {
            // accumilate ingrediants
            Dictionary<long, float> dry_ingrediant_accumilator = new Dictionary<long, float>();

            foreach (var dayCell in dayCells) {

                foreach (long recipeId in dayCell.mRecipeIdList) {

                    Recipe cur_recipe = RecipiesArchiveIntf.get_recipe(recipeId);

                    foreach (IngrediantAmmount ingrediant in cur_recipe.ingrediants) {
                        Ingrediant cur_ingrediant = RecipiesArchiveIntf.get_Ingrediant(ingrediant.ingrediant_id);
                        if (cur_ingrediant.catigory == Ingrediant.Catigory.NotVegetable) {
                            if (dry_ingrediant_accumilator.ContainsKey(ingrediant.ingrediant_id)) {
                                dry_ingrediant_accumilator[ingrediant.ingrediant_id] += ingrediant.ammount;
                            } else {
                                dry_ingrediant_accumilator[ingrediant.ingrediant_id] = ingrediant.ammount;
                            }
                        }
                    }
                }
            }

            string dry_buy_list = "";

            foreach (KeyValuePair<long, float> entry in dry_ingrediant_accumilator) {
                Ingrediant cur_ingrediant = RecipiesArchiveIntf.get_Ingrediant(entry.Key);
                dry_buy_list += cur_ingrediant.name + "\t" + cur_ingrediant.units + "\t" + entry.Value + "\n";
            }

            MessageBox.Show(dry_buy_list);

        }
    }
}
