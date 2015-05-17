using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using YumYuck.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YumYuck
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class ViewPage : Page
    {
        List<string> foodNames;

        public ViewPage()
        {
            
            
            this.InitializeComponent();
      

            foodNames = new List<string>();

            if (CreateFoodPage.foodItems!=null)
            foreach (Food f in CreateFoodPage.foodItems)
            {
                foodNames.Add(f.Name);            
                    }


            listBox1.ItemsSource = foodNames;
          
            listBox1.Width = 140;
            listBox1.SelectionChanged += ListBox_SelectionChanged;

            StackPanel stackPanel1 = new StackPanel();


            if (CreateFoodPage.foodItems!= null && foodNames!= null)
                textBox.Text = "foodItems Count: " + CreateFoodPage.foodItems.Count + "\nfoodNames Count: " + foodNames.Count;
            // Add the list box to a parent container in the visual tree.
            //      stackPanel1.Children.Add(listBox1);

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Add code to perform some action here.
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
