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

        // number of days this item is good for
        public int num_days_is_good;

        

        public Ingrediant(long id, string name, string units, float price, List<long> shops_ids,int num_days_is_good) {
            this.id = id;
            this.name = name;
            this.units = units;
            this.price = price;
            this.shops_ids = shops_ids;
            this.num_days_is_good = num_days_is_good;
        }

    }
}
