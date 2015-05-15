using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace YumYuck.Core
{
    class Food
    {
        String Name { get; set; }
        BitmapImage MainPhoto { get; set; }
        List<Ingredient> Ingredients { get; set; }
        String Description { get; set; }
        String Recipe { get; set; }
    }
}
