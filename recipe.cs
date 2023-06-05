﻿using System;
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

        public string print() {
            Ingrediant ingred = RecipiesArchiveIntf.get_Ingrediant(ingrediant_id);
            return ingred.name + "\t" + ingred.units + "\t" + string.Format("0:0.00", ammount);
        }
    }
}
