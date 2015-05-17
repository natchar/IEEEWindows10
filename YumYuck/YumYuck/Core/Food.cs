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
       public BitmapImage MainPhoto { get; set; }
       public List<Ingredient> Ingredients { get; set; }
      public  String Description { get; set; }
      public  String Recipe { get; set; }
    }
}
