using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YumYuck.Core
{
    class Ingredient
    {
        String IngredientName { get; set; }
        String Measurment { get; set; }
        float Quantity { get; set; }

        public String getIngredientString()
        {
            return String.Format("{0}: {1} {2}", IngredientName, Quantity, Measurment);
        }
    }
}
