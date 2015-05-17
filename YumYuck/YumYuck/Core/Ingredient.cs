using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYuck.Core
{
   public class Ingredient
    {
        public Ingredient(String Name, String Measure, String Quantity)
        {
            this.IngredientName = Name;
            this.Measurment = Measure;
            this.Quantity = Quantity;
        }
        String IngredientName { get; set; }
        String Measurment { get; set; }
        String Quantity { get; set; }

        public String getIngredientString()
        {
            return String.Format("{0}: {1} {2}", IngredientName, Quantity, Measurment);
        }
    }
}
