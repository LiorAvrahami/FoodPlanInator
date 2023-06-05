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
        List<string> titles_list;
        List<string> text_list;
        int current_view;

        public show_buy_lists_form() {
            InitializeComponent();
        }

        public void init(List<string> titles_list, List<string> text_list) {
            if (titles_list.Count != text_list.Count) {
                throw new Exception("titles length must mach text length");
            }
            this.titles_list = titles_list;
            this.text_list = text_list;
            current_view = 0;
        }

        void update_view() {
            mTxtBx.Text = text_list[current_view];
            mLable_Title.Text = titles_list[current_view];
        }

        private void mBtnBack_Click(object sender, EventArgs e) {
            current_view--;
            if (current_view < 0) {
                current_view = 0;
            }
            update_view();
        }

        private void mBtnNext_Click(object sender, EventArgs e) {
            current_view++;
            if (current_view >= text_list.Count) {
                current_view = text_list.Count - 1;
            }
            update_view();
        }

        private void mLable_Title_Click(object sender, EventArgs e) {
            // TODO copy to clipboard
        }

        private void mBtnCopy_Click(object sender, EventArgs e) {
            // TODO copy to clipboard
        }
    }
}
