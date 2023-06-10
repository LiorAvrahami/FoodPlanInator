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

        public bool make_legal() {
            bool is_legal = true;
            if (id == 0) {
                is_legal = false;
                throw new Exception("Recipe has id 0");
            }
            if (name == null) {
                is_legal = false;
                name = "EMPTY NAME";
                Log.print("Recipe with Id " + id.ToString() + " has empty name, name was reset to be " + name);
            }
            if (ingrediants == null) {
                is_legal = false;
                ingrediants = new List<IngrediantAmmount>();
                Log.print("Recipe with name " + name + " has no null ingrediants. resetting to empty list");
            }
            return is_legal;
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

        public string print() {
            Ingrediant ingred = RecipiesArchiveIntf.get_Ingrediant(ingrediant_id);
            return ingred.name + "\t" + ingred.units + "\t" + ammount.ToString("0.00") + "\r\n";
        }
    }
}
