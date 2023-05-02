using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPlanInator {
    class Recipe {
        // each Recipe has some random id
        public long id;

        public string name;

        public List<IngrediantAmmount> ingrediants;

        public Recipe(long id, string name, List<IngrediantAmmount> ingrediants) {
            this.id = id;
            this.name = name;
            this.ingrediants = new List<IngrediantAmmount>(ingrediants);
        }

        public void overwrite(Recipe new_recipe) {
            // overwrite this to be equal to the fields of new_recipe
            id = new_recipe.id;
            name = new_recipe.name;
            ingrediants = new List<IngrediantAmmount>(new_recipe.ingrediants);
        }
    }

    class IngrediantAmmount {
        public float ammount;
        public long ingrediant_id;

        public IngrediantAmmount(long ingrediant_id, float ammount) {
            this.ammount = ammount;
            this.ingrediant_id = ingrediant_id;
        }

        public Ingrediant get_ingrediant() { 
            return RecipiesArchiveIntf.get_Ingrediant(ingrediant_id);
        }
    }

    class Ingrediant {
        
        public enum Catigory {
            // always add to the end for backwards compatibility.
            Monthly = 42,
            Vegetables,
            Packaged_Dual_Weekly,
            Spices,


        }

        // each Ingrediant has some random id
        public long id;

        public string name;
        public string units;
        public float price = -1;

        public Catigory catigory;

        public Ingrediant(long id, string name, string units, float price, Catigory catigory) {
            this.id = id;
            this.name = name;
            this.units = units;
            this.price = price;
            this.catigory = catigory;
        }

    }
}
