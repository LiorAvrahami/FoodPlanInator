using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FoodPlanInator.Ingrediant;

namespace FoodPlanInator {

    // this form adds new ingrediants or edits old ingrediants
    public partial class AddIngrediantForm : Form {

        string name = "";
        string units = "";
        float price = -1;

        // shops where this item can be bout at
        public List<long> selectted_shops_ids = new List<long>();

        // number of days this item is good for
        int num_days_is_good;


        long IngrediantId_priv;

        bool isSubmitted = false;

        void fill_shops_checklist() {
            this.mChkBxListShops.Items.Clear();
            foreach (Shop shop in RecipiesArchiveIntf.get_all_shops()) {
                this.mChkBxListShops.Items.Add(shop.name);
                if (selectted_shops_ids.Contains(shop.id)) {
                    this.mChkBxListShops.SetItemChecked(this.mChkBxListShops.Items.Count - 1, true);
                }
            }
        }

        void assert_shops_didnt_change() {
            List<Shop> shops = RecipiesArchiveIntf.get_all_shops();
            if (RecipiesArchiveIntf.get_all_shops().Count != mChkBxListShops.Items.Count) {
                throw new Exception("error shops changed outside of form");
            }

            for (int i = 0; i < this.mChkBxListShops.Items.Count; i++) {
                if (shops[i].name != (string)this.mChkBxListShops.Items[i]) {
                    throw new Exception("error shops changed outside of form");
                }
            }
        }

        public static long AddNew() {
            AddIngrediantForm temp = new AddIngrediantForm();
            temp.ShowDialog();
            if (temp.isSubmitted) {
                RecipiesArchiveIntf.add_Ingrediant(new Ingrediant(RecipiesArchiveIntf.get_unused_id(), temp.name, temp.units, temp.price, temp.selectted_shops_ids, temp.num_days_is_good));
                return temp.get_IngrediantId();
            } else {
                return 0;
            }
        }

        public static void EditOld(long IngrediantId) {
            AddIngrediantForm temp = new AddIngrediantForm(IngrediantId);
            temp.ShowDialog();
            if (temp.isSubmitted) {
                Ingrediant Ingrediant = RecipiesArchiveIntf.get_Ingrediant(IngrediantId);
                Ingrediant.name = temp.name;
                Ingrediant.units = temp.units;
                Ingrediant.price = temp.price;
                Ingrediant.shops_ids = new List<long>(temp.selectted_shops_ids);
                Ingrediant.num_days_is_good = temp.num_days_is_good;
            }
            RecipiesArchiveIntf.save();
        }

        void set_IngrediantId(long val) {
            IngrediantId_priv = val;
            name = RecipiesArchiveIntf.get_Ingrediant(val).name;
            units = RecipiesArchiveIntf.get_Ingrediant(val).units;
            price = RecipiesArchiveIntf.get_Ingrediant(val).price;
            selectted_shops_ids = new List<long>(RecipiesArchiveIntf.get_Ingrediant(val).shops_ids);
            num_days_is_good = RecipiesArchiveIntf.get_Ingrediant(val).num_days_is_good;

            fill_shops_checklist();
            mTxtBx_Name.Text = name;
            mTxtBx_Units.Text = units;
            mTxtBxAmmount.Text = price.ToString();
            mTxtNumDays.Text = num_days_is_good.ToString();
        }

        long get_IngrediantId() { return IngrediantId_priv; }

        public AddIngrediantForm() {
            InitializeComponent();
            IngrediantId_priv = 0;
            mBtn_Delete.Enabled = false;
        }

        public AddIngrediantForm(long IngrediantId) {
            InitializeComponent();
            set_IngrediantId(IngrediantId);
        }

        private void mBtnSubmit_Click(object sender, EventArgs e) {
            this.name = mTxtBx_Name.Text != null ? mTxtBx_Name.Text : "";
            this.units = mTxtBx_Units.Text != null ? mTxtBx_Units.Text : "";
            try {
                this.price = float.Parse(mTxtBxAmmount.Text);
            } catch (Exception ex) {
                MessageBox.Show("Price must be number");
                return;
            }
            try {
                int temp = int.Parse(mTxtNumDays.Text);
                if (temp <= 0) {
                    throw new Exception();
                }
                this.num_days_is_good = temp;
            } catch (Exception ex) {
                MessageBox.Show("num days is good must be a positive number");
                return;
            }

            selectted_shops_ids.Clear();
            assert_shops_didnt_change();
            List<Shop> shops = RecipiesArchiveIntf.get_all_shops();
            for (int i = 0; i < this.mChkBxListShops.Items.Count; i++) {
                if (mChkBxListShops.GetItemChecked(i)) {
                    selectted_shops_ids.Add(shops[i].id);
                }
            }

            this.isSubmitted = true;
            Close();
        }

        private void mBtn_Delete_Click(object sender, EventArgs e) {
            if (this.IngrediantId_priv == 0) {
                MessageBox.Show("can't delete ingrediant doesn't exist yet.");
            }
            RecipiesArchiveIntf.delete_Ingrediant(this.IngrediantId_priv, false);
            Close();
        }

        private void AddIngrediantForm_Load(object sender, EventArgs e) {
            fill_shops_checklist();
        }
    }
}
