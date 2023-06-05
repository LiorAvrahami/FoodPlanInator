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

        // for the meanwhile Shops are going to be statically created (no interface for creating/saving/loading Shops)
        public Shop[] make_Shops_array() {
            Shop[] ret = new Shop[2];
            
            ret[0].name = "ShopA";
            ret[0].maximum_visits_per_month = 1;
            // just some number
            ret[0].id = 117;

            ret[0].name = "ShopB";
            ret[0].maximum_visits_per_month = 0;
            // just some number
            ret[0].id = 118;

            return ret;
        }

        // return true if ammont of visits to this store is not too large.
        public bool is_too_many_visits(int num_visits_in_month) {
            bool is_num_visits_valid = (maximum_visits_per_month == 0) || (maximum_visits_per_month > num_visits_in_month);
            return !is_num_visits_valid;
        }
    }
}
