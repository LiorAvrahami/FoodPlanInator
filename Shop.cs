using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanInator {
    internal class Shop {
        public string name;

        // if equals 0 then no maximum exists
        private int maximum_visits_per_month;

        public long id;

        public bool make_legal() {
            bool is_legal = true;
            if (id == 0) {
                is_legal = false;
                throw new Exception("Shop has id 0");
            }
            if (name == null) {
                is_legal = false;
                name = "EMPTY NAME";
                Log.print("shop with Id " + id.ToString() + " has empty name, name was reset to be " + name);
            }
            if (maximum_visits_per_month < 0) {
                is_legal = false;
                maximum_visits_per_month = 0;
                Log.print("shop with name " + name + " has incorrect maximum_visits_per_month, resetting to infinity");
            }
            return is_legal;
        }

        // for the meanwhile Shops are going to be statically created (no interface for creating/saving/loading Shops)
        public static Shop[] make_Shops_array() {
            Shop[] ret = new Shop[2];

            ret[0] = new Shop();
            ret[0].name = "ShopA";
            ret[0].maximum_visits_per_month = 1;
            // just some number
            ret[0].id = 117;

            ret[1] = new Shop();
            ret[1].name = "ShopB";
            ret[1].maximum_visits_per_month = 0;
            // just some number
            ret[1].id = 118;

            return ret;
        }

        // return true if ammont of visits to this store is not too large.
        public bool is_too_many_visits(int num_visits_in_month) {
            bool is_num_visits_valid = (maximum_visits_per_month == 0) || (maximum_visits_per_month >= num_visits_in_month);
            return !is_num_visits_valid;
        }
    }
}
