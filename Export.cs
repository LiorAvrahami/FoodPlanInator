using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FoodPlanInator.Form1;


namespace FoodPlanInator {

    class BuyListAccumilator {
        ShopId shop_id;
        Dictionary<ingrediantId, float> ammount_map = new Dictionary<ingrediantId, float>();
        DateTime start_date;

        public BuyListAccumilator(ShopId shop_id) {
            this.shop_id = shop_id;
        }

        public ShopId get_shop_id() {
            return shop_id;
        }

        public bool try_add(IngrediantAmmount ingrediant_ammount, DateTime date) {
            // if is first
            if (ammount_map.Count == 0) {
                start_date = date;
                ammount_map[ingrediant_ammount.ingrediant_id] = ingrediant_ammount.ammount;
                return true;
            } else {
                if (date < start_date) {
                    // will be before start of list
                    throw new ArgumentException("ingrediants must be given in order");
                }
                if (date > start_date.AddDays(ingrediant_ammount.get_ingrediant().num_days_is_good)) {
                    // will expire before used
                    return false;
                }
                if (ammount_map.ContainsKey(ingrediant_ammount.ingrediant_id)) {
                    ammount_map[ingrediant_ammount.ingrediant_id] += ingrediant_ammount.ammount;
                } else {
                    ammount_map[ingrediant_ammount.ingrediant_id] = ingrediant_ammount.ammount;
                }
                return true;
            }
        }

        public string make_title() {
            return RecipiesArchiveIntf.get_shop(shop_id).name + ": " + start_date.ToString("MM/dd");
        }
        public string make_list() {
            string ret = "";
            foreach (ingrediantId ingred_id in ammount_map.Keys) {

                IngrediantAmmount a = new IngrediantAmmount(ingred_id, ammount_map[ingred_id]);
                ret += a.print();
            }
            return ret;
        }
    }

    class ShopCollectionAccumilators {
        Dictionary<ShopId, BuyListAccumilator> active_accumilators;
        List<BuyListAccumilator> all_accumilators;

        public ShopCollectionAccumilators() {
            active_accumilators = new Dictionary<ShopId, BuyListAccumilator>();
            all_accumilators = new List<BuyListAccumilator>();
        }

        public int get_num_accumilators_per_shop(ShopId shop_id) {
            int ret = 0;
            foreach (BuyListAccumilator accum in all_accumilators) {
                if (accum.get_shop_id() == shop_id) {
                    ret += 1;
                }
            }
            return ret;
        }

        public bool try_add_accumilator(ShopId shop_id) {
            if (RecipiesArchiveIntf.get_shop(shop_id).is_too_many_visits(get_num_accumilators_per_shop(shop_id) + 1)) {
                return false;
            }
            BuyListAccumilator new_accum = new BuyListAccumilator(shop_id);
            all_accumilators.Add(new_accum);
            if (!active_accumilators.ContainsKey(shop_id)) {
                active_accumilators.Add(shop_id, new_accum);
            } else {
                active_accumilators[shop_id] = new_accum;
            }
            return true;
        }

        public BuyListAccumilator get_current_buy_list(ShopId shop_id) {
            if (!active_accumilators.ContainsKey(shop_id)) {
                try_add_accumilator(shop_id);
            }
            return active_accumilators[shop_id];
        }

        public void add_to_best_shop_accumilator(IngrediantAmmount ingred_ammount, DateTime date_used) {
            bool success = false;
            // for each ingrediant go over all shops in order and select the best shop
            foreach (ShopId shop_id in ingred_ammount.get_ingrediant().shops_ids) {
                // try adding ingrediant to the current shop buy list
                success = this.get_current_buy_list(shop_id).try_add(ingred_ammount, date_used);
                if (success) {
                    // if successfull then no need to keep trying with other lists
                    break;
                }
            }
            if (!success) {
                // make new acumialtor
                foreach (ShopId shop_id in ingred_ammount.get_ingrediant().shops_ids) {
                    success = try_add_accumilator(shop_id);
                    if (success) {
                        // add ingrediant
                        success = this.get_current_buy_list(shop_id).try_add(ingred_ammount, date_used);
                        if (!success) {
                            throw new Exception("UNEXPECTTED ERROR: failed to add ingrediant to empty buy list");
                        }
                        break;
                    }
                }
                if (!success) {
                    //TODO
                    MessageBox.Show("ERROR all shops are full! and no more accumilators can be created.");
                }
            }
        }

        public List<BuyListAccumilator> get_all_buy_lists() {
            return all_accumilators;
        }

    }

    static class Export {
        public static (List<string>, List<string>) get_buy_lists(List<DayCell> dayCells) {
            List<BuyListAccumilator> accum_list = get_accumilator_lists(dayCells);

            List<string> titles = new List<string>();
            List<string> list = new List<string>();

            foreach (BuyListAccumilator accum in accum_list) {
                titles.Add(accum.make_title());
                list.Add(accum.make_list());
            }

            return (titles, list);

        }

        public static List<BuyListAccumilator> get_accumilator_lists(List<DayCell> dayCells) {
            /*
             for each shop need:
                active accumilator, buy date for accumilator
             when acumilator is full print it to text and title.
             */

            /* shop acumilators collection. keys are shop ids */
            ShopCollectionAccumilators shop_acumilators_collection = new ShopCollectionAccumilators();

            foreach (DayCell dayCell in dayCells) {
                foreach (RecipeId recipeId in dayCell.mRecipeIdList) {
                    Recipe cur_recipe = RecipiesArchiveIntf.get_recipe(recipeId);

                    foreach (IngrediantAmmount ingred_ammount in cur_recipe.ingrediants) {
                        // add each ingrediant to the accumilator
                        shop_acumilators_collection.add_to_best_shop_accumilator(ingred_ammount, dayCell.date);
                    }
                }
            }

            return shop_acumilators_collection.get_all_buy_lists();

        }

        static string print_dictionary(Dictionary<long, float> dict) {
            string ret = "";
            foreach (KeyValuePair<long, float> entry in dict) {
                Ingrediant cur_ingrediant = RecipiesArchiveIntf.get_Ingrediant(entry.Key);
                ret += cur_ingrediant.name + "\t" + cur_ingrediant.units + "\t" + entry.Value + "\r\n";
            }
            return ret;
        }


    }
}
