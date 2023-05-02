using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodPlanInator {
    public partial class show_buy_lists_form : Form {
        string calander_image_file_name;
        public show_buy_lists_form() {
            InitializeComponent();
        }

        public void init(string StoreA, string StoreBWeek1, string StoreBweek3, string spices, string calander_image_file_name) {
            mTxtMonth.Text = StoreA;
            mTxtStoreBWeek1.Text = StoreBWeek1;
            mTxtStoreBWeek3.Text = StoreBweek3;
            mTxtSpices.Text = spices;
            this.calander_image_file_name = calander_image_file_name;
        }

        private void mBtnOpenCalanderImage_Click(object sender, EventArgs e) {
            string args = string.Format("/e, /select, \"{0}\"", calander_image_file_name);

            Process.Start("explorer.exe", args);

        }
    }
}
