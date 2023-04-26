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
        Ingrediant.Catigory catigory;

        long IngrediantId_priv;

        bool isSubmitted = false;

        public static long AddNew() {
            AddIngrediantForm temp = new AddIngrediantForm();
            temp.ShowDialog();
            if (temp.isSubmitted) {
                RecipiesArchiveIntf.add_Ingrediant(new Ingrediant(RecipiesArchiveIntf.get_unused_id(), temp.name, temp.units, temp.price, temp.catigory));
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
                Ingrediant.catigory = temp.catigory;
            }
            RecipiesArchiveIntf.save();
        }

        void set_IngrediantId(long val) {
            IngrediantId_priv = val;
            name = RecipiesArchiveIntf.get_Ingrediant(val).name;
            units = RecipiesArchiveIntf.get_Ingrediant(val).units;
            price = RecipiesArchiveIntf.get_Ingrediant(val).price;
            catigory = RecipiesArchiveIntf.get_Ingrediant(val).catigory;

            mTxtBx_Name.Text = name;
            mTxtBx_Units.Text = units;
            mTxtBxAmmount.Text = price.ToString();
            mCombo_Catigory.Text = catigory.ToString();

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
            this.catigory = Enum.Parse<Ingrediant.Catigory>(mCombo_Catigory.Text);
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
            mCombo_Catigory.Items.AddRange(Enum.GetNames(typeof(Ingrediant.Catigory)));
        }
    }
}
