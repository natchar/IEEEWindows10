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
          //  listBox1.SelectionChanged += ListBox_SelectionChanged;

            StackPanel stackPanel1 = new StackPanel();


           // if (CreateFoodPage.foodItems != null && foodNames != null) {
                //textBox.Text = "foodItems Count: " + CreateFoodPage.foodItems.Count + "\nfoodNames Count: " + foodNames.Count;

             //   nameText.Text = CreateFoodPage.foodItems[0].Name;
                  //  }
            // Add the list box to a parent container in the visual tree.
            //      stackPanel1.Children.Add(listBox1);

        }
    

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            ListBox scenarioListBox = sender as ListBox;
            string s = scenarioListBox.SelectedItem as string;

            if(s != null&& CreateFoodPage.foodItems!=null)
            foreach (Food f in CreateFoodPage.foodItems)
            {
                if (f.Name==s)
                {
                        nameText.Text = f.Name;
                        foodPic.Source = f.MainPhoto;
                        descriptionText.Text = f.Description;
                        indegredientsText.Text = "";
                        foreach (Ingredient i in f.Ingredients)
                        {
                            indegredientsText.Text+=i.getIngredientString()+"\n";
                        }
                     
                        recipeText.Text = f.Recipe;
                }
            }

            //  ListBox scenarioListBox = sender as ListBox;
            //   string f = sender as string;


            //if (s != null)
            //{
            //    nameText.Text = s;
            //}
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBlock1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
