using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace YumYuck.Core
{
    public class Food
    {
        public Food(String name, BitmapImage photo, List<Ingredient> ingredList, String desc, String recipe)
        {
            this.Name = name;
            this.MainPhoto = photo;
            this.Ingredients = ingredList;
            this.Description = desc;
            this.Recipe = recipe;
        }
      public String Name { get; set; }
        BitmapImage MainPhoto { get; set; }
        List<Ingredient> Ingredients { get; set; }
        String Description { get; set; }
        String Recipe { get; set; }
    }
}
