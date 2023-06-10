global using ShopId = System.Int64;
global using ingrediantId = System.Int64;
global using RecipeId = System.Int64;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodPlanInator {

    // interface for settings archive, contains the recipies, ingrediants, and the stores
    class RecipiesArchiveIntf {
        public static string get_RecipiesArchive_file_path() {
            //This will give us the full name path of the executable file:
            //i.e. C:\Program Files\MyApplication\MyApplication.exe
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //This will strip just the working path name:
            //C:\Program Files\MyApplication
            string strWorkPath = Path.GetDirectoryName(strExeFilePath);

            string base_name = "FoodPlanInator_RecipiesArchive";

            Regex reg = new Regex(base_name + "[0-9]*.json");
            string file_name = Directory.GetFiles(strWorkPath, "*.json").Where(path => reg.IsMatch(path)).First();

            return Path.Combine(strWorkPath, file_name);
        }
        public static void init() {
            try {
                // try load local file
                string json_text = File.ReadAllText(get_RecipiesArchive_file_path());
                RecipiesArchivePriv.global_instance = JsonConvert.DeserializeObject<RecipiesArchivePriv>(json_text);
                bool was_legal = RecipiesArchivePriv.global_instance.make_legal();
                if (!was_legal) {
                    MessageBox.Show("some errors/version inconsistancies were found and fixed in the recipies archive file. for more info go to the file nammmed Log.txt");
                }
            } catch { }
            if (RecipiesArchivePriv.global_instance == null) {
                RecipiesArchivePriv.global_instance = new RecipiesArchivePriv();
            }

            //DOTO this is temperary
            RecipiesArchivePriv.global_instance.init_shops();
        }

        public static List<Recipe> get_all_recipes() {
            return RecipiesArchivePriv.global_instance.get_all_recipes();
        }

        public static List<Ingrediant> get_all_ingrediants() {
            return RecipiesArchivePriv.global_instance.get_all_ingrediants();
        }

        public static List<Shop> get_all_shops() {
            return RecipiesArchivePriv.global_instance.get_all_shops();
        }

        public static Recipe get_recipe(long Id) {
            return RecipiesArchivePriv.global_instance.get_recipe(Id);
        }

        public static Ingrediant get_Ingrediant(long Id) {
            return RecipiesArchivePriv.global_instance.get_Ingrediant(Id);
        }

        public static Shop get_shop(ShopId Id) {
            return RecipiesArchivePriv.global_instance.get_shop(Id);
        }

        public static long get_unused_id() {
            /** return a 64 bit positive integer that represents an id which is not currently used by any recipe or ingrediant. 
                also the id 0 is not used, id 0 represents the null id.
             */
            return RecipiesArchivePriv.global_instance.get_unused_id();
        }

        public static void add_recipe(Recipe recipe) {
            RecipiesArchivePriv.global_instance.add_recipe(recipe);
        }

        public static void add_Ingrediant(Ingrediant ingrediant) {
            RecipiesArchivePriv.global_instance.add_Ingrediant(ingrediant);
        }

        public static void save() {
            RecipiesArchivePriv.global_instance.save();
        }

        public static bool ingrediant_exists(long Id) {
            return RecipiesArchivePriv.global_instance.ingrediant_exists(Id);
        }

        public static bool recipe_exists(long Id) {
            return RecipiesArchivePriv.global_instance.recipe_exists(Id);
        }

        public static void delete_recipe(long Id) { RecipiesArchivePriv.global_instance.delete_recipe(Id); }

        public static void delete_Ingrediant(long Id, bool isFourceDelete) {
            // make sure ingrediant isn't in use in any recipe, unless isFourceDelete is true, in which case no check is preformed.
            RecipiesArchivePriv.global_instance.delete_Ingrediant(Id, isFourceDelete);
        }

        // internal workings for recipe and ingrediant archive
        private class RecipiesArchivePriv {
            static public RecipiesArchivePriv global_instance;

            Random random = new Random();

            [JsonProperty]
            List<Recipe> recipes_list;
            [JsonProperty]
            List<Ingrediant> Ingrediant_list;

            // currently not saved to json
            List<Shop> shop_list;

            public RecipiesArchivePriv() {
                recipes_list = new List<Recipe>();
                Ingrediant_list = new List<Ingrediant>();
                shop_list = new List<Shop>();
            }

            public bool make_legal() {
                bool was_legal = true;
                foreach (var recipe in recipes_list)
                {
                    if (recipe.make_legal() == false) {
                        was_legal = false;
                    }
                }
                foreach (var ingrediant in Ingrediant_list)
                {
                    if (ingrediant.make_legal() == false) {
                        was_legal = false;
                    }
                }
                foreach (var shop in shop_list)
                {
                    if (shop.make_legal() == false) {
                        was_legal = false;
                    }
                }
                return was_legal;
            }

            public List<Recipe> get_all_recipes() { return recipes_list; }

            public List<Ingrediant> get_all_ingrediants() { return Ingrediant_list; }

            public List<Shop> get_all_shops() {
                return shop_list;
            }
            public Shop get_shop(ShopId Id) {
                foreach (Shop shop in shop_list) {
                    if (shop.id == Id) {
                        return shop;
                    }
                }
                return null;
            }


            public Recipe get_recipe(long Id) {
                foreach (var recipe in recipes_list) {
                    if (recipe.id == Id) {
                        return recipe;
                    }
                }
                return null;
            }

            public Ingrediant get_Ingrediant(long Id) {
                foreach (var ngrediant in Ingrediant_list) {
                    if (ngrediant.id == Id) {
                        return ngrediant;
                    }
                }
                return null;
            }

            public long get_unused_id() {
                while (true) {
                    long candadit = RecipiesArchivePriv.global_instance.random.NextInt64();
                    if (candadit != 0 && !ingrediant_exists(candadit) && !recipe_exists(candadit) && !shop_exists(candadit)) {
                        return candadit;
                    }
                }

            }

            public void add_recipe(Recipe recipe) {
                recipes_list.Add(recipe);
                this.save();
            }

            public void add_Ingrediant(Ingrediant ingrediant) {
                if (ingrediant.name != null)
                    Ingrediant_list.Add(ingrediant);
                this.save();
            }
            public void save() {
                File.WriteAllText(get_RecipiesArchive_file_path(), JsonConvert.SerializeObject(global_instance, Formatting.Indented));
            }

            public void delete_recipe(long Id) {
                Recipe recipe = get_recipe(Id);
                if (recipe != null) {
                    recipes_list.Remove(recipe);
                }
            }

            public void delete_Ingrediant(long Id, bool isFourceDelete) {
                // make sure ingrediant isn't in use in any recipe, unless isFourceDelete is true, in which case no check is preformed.
                foreach (var recipe in recipes_list) {
                    foreach (var ingr in recipe.ingrediants) {
                        if (ingr.ingrediant_id == Id && !isFourceDelete) {
                            MessageBox.Show("can't delete because ingrediant exists in recipe: " + recipe.name);
                            return;
                        }
                    }
                }

                Ingrediant ingrediant = get_Ingrediant(Id);
                if (ingrediant != null) {
                    Ingrediant_list.Remove(ingrediant);
                }

                save();
            }

            public bool ingrediant_exists(long Id) {
                return get_Ingrediant(Id) != null;
            }

            public bool recipe_exists(long Id) {
                return get_recipe(Id) != null;
            }

            public bool shop_exists(ShopId id) {
                return get_shop(id) != null;
            }

            public void init_shops() {
                this.shop_list = new List<Shop>(Shop.make_Shops_array());
            }
        }
    }
}
