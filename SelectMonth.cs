using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodPlanInator {
    public partial class SelectMonth : Form {
        public int selectted_month;
        public int selectted_year;

        public bool submitted = false;

        public static SelectMonth Prompt(int default_month, int default_year) {
            SelectMonth temp = new SelectMonth(default_month, default_year);
            temp.ShowDialog();
            return temp;
        }

        public SelectMonth(int default_month, int default_year) {
            InitializeComponent();
            this.mCombobox_Months.SelectedIndex = default_month - 1;
            this.mTextbox_Years.Text = default_year.ToString();
        }

        private void button1_Click(object sender, EventArgs e) {
            selectted_month = this.mCombobox_Months.SelectedIndex + 1;
            selectted_year = int.Parse(this.mTextbox_Years.Text);
            submitted = true;
            Close();
        }
    }
}
