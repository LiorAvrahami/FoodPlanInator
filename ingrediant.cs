using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanInator {
    class Ingrediant {

        // DEPRICATTED
        public enum Catigory {
            // always add to the end for backwards compatibility.
            Monthly = 42,
            Vegetables,
            Packaged_Dual_Weekly,
            Spices,
        }
        public Catigory catigory;

        // each Ingrediant has some random id
        public long id;

        public string name;
        public string units;
        public float price = -1;

        // shops where this item can be bout at
        public List<long> shops_ids = new List<long>();

        // number of days this item is good for. 0 is infinity.
        public int num_days_is_good;

        public Ingrediant(long id, string name, string units, float price, List<long> shops_ids, int num_days_is_good) {
            this.id = id;
            this.name = name;
            this.units = units;
            this.price = price;
            this.shops_ids = shops_ids;
            this.num_days_is_good = num_days_is_good;
        }

        public bool make_legal() {
            bool is_legal = true;
            if (id == 0) {
                is_legal = false;
                throw new Exception("ingrediant has id 0");
            }
            if (name == null) {
                is_legal = false;
                name = "EMPTY NAME";
                Log.print("ingrediant with Id " + id.ToString() + " has empty name, name was reset to be " + name);
            }
            if (units == null) {
                is_legal = false;
                units = "EMPTY UNITS";
                Log.print("ingrediant with name " + name + " has empty units, units was reset to be " + units);
            }
            if (catigory != Catigory.Monthly && catigory != Catigory.Vegetables) {

            }
            if (catigory == Catigory.Monthly) {
                bool reset_num_days_is_good = false;
                if (shops_ids == null) {
                    is_legal = false;
                    shops_ids = new List<long>();
                    shops_ids.Add(117);
                    Log.print("ingrediant with name " + name + " has null shops_ids list, it was reset to be ShopA");
                    reset_num_days_is_good = true;
                }
                if (num_days_is_good <= 0 || reset_num_days_is_good) {
                    is_legal = false;
                    num_days_is_good = 60;
                    Log.print("ingrediant with name " + name + " has non-positive num_days_is_good, it was reset to be 60");
                }
            } else if (catigory == Catigory.Vegetables) {
                bool reset_num_days_is_good = false;
                if (shops_ids == null) {
                    is_legal = false;
                    shops_ids = new List<long>();
                    shops_ids.Add(118);
                    Log.print("ingrediant with name " + name + " has null shops_ids list, it was reset to be ShopB");
                    reset_num_days_is_good = true;
                }
                if (num_days_is_good <= 0 || reset_num_days_is_good) {
                    is_legal = false;
                    num_days_is_good = 7;
                    Log.print("ingrediant with name " + name + " has negative num_days_is_good, it was reset to be 7");
                }
            } else {
                bool reset_num_days_is_good = false;
                if (shops_ids == null) {
                    is_legal = false;
                    shops_ids = new List<long>();
                    Log.print("ingrediant with name " + name + " has null shops_ids list, it was reset to be empty");
                    reset_num_days_is_good = true;
                }
                if (num_days_is_good <= 0 || reset_num_days_is_good) {
                    is_legal = false;
                    num_days_is_good = 60;
                    Log.print("ingrediant with name " + name + " has negative num_days_is_good, it was reset to be 60");
                }
            }
            return is_legal;
        }

    }
}
