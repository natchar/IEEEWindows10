using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using YumYuck.Core;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace YumYuck
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateFoodPage : Page
    {
        Boolean NameClicked = false;
        Boolean DescriptionClicked = false;
        Boolean IngredientClicked = false;
        Boolean IngredientFieldClicked = false;
        Boolean InstructionsClicked = false;
        BitmapImage FoodPic = null;
        Food FoodItem;
        List<Ingredient> ingredientList;

        public CreateFoodPage()
        {
            this.InitializeComponent();

            //clears fields of default text when first clicked
            NameField.GotFocus += NameField_GotFocus;
            DescriptionField.GotFocus += DescriptionField_GotFocus;
            IngredientQuantity.GotFocus += IngredientQuantity_GotFocus;
            InstructionsField.GotFocus += InstructionsField_GotFocus;
            IngredientItem.GotFocus += IngredientItem_GotFocus;

            //Set combobox
            IngredientMeasurment.Items.Add("mL");
            IngredientMeasurment.Items.Add("cups");
            IngredientMeasurment.Items.Add("");
            IngredientMeasurment.Items.Add("oz");


        }

        private void IngredientItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!IngredientFieldClicked)
                IngredientItem.Text = "";
            IngredientFieldClicked = true;
        }

        private void InstructionsField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!InstructionsClicked)
                InstructionsField.Text = "";
            InstructionsClicked = true;
        }

        private void IngredientQuantity_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!IngredientClicked)
                IngredientQuantity.Text = "";
            IngredientClicked = true;
        }

        private void DescriptionField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!DescriptionClicked)
               DescriptionField.Text = "";
            DescriptionClicked = true;
        }

        private void NameField_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!NameClicked)
                NameField.Text = "";
            NameClicked = true;
        }

        private async void PickPicture(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                BitmapImage image = new BitmapImage(new Uri(file.Path));
                using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    await image.SetSourceAsync(fileStream);
                    MainPicture.Source = image;
                    FoodPic = image;
                };
                
            }
          //    MainPicture.Source = 
        }

        private void IngredientAdd_Click(object sender, RoutedEventArgs e)
        {
            var quantity = IngredientQuantity.Text;
            String measurement = IngredientMeasurment.SelectedItem.ToString();
            var item = IngredientItem.Text;

            if (String.IsNullOrEmpty(quantity))
            {
                IngredientQuantity.Text ="??";
                return;
            }
            if (String.IsNullOrEmpty(item))
            {
                IngredientItem.Text = "??";
                return;
            }

            var ingredient = String.Format("{0} {1} {2}", quantity, measurement, item);
            IngredientsList.Items.Add(ingredient);
            if (ingredientList == null)
                ingredientList = new List<Ingredient>();
            ingredientList.Add(new Ingredient(item, measurement, quantity));
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var name = NameField.Text;
            var desc = DescriptionField.Text;
            var instructions = InstructionsField.Text;

            //check all fields have been entered
            if(String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(desc) ||
                (ingredientList == null) ||
                (FoodPic == null) ||
                String.IsNullOrEmpty(instructions))
            {
                var dialog = new MessageDialog("All fields need to be filled in");
                dialog.Title = "Food not saved";
                await dialog.ShowAsync();
                return;
            }

            FoodItem = new Food(name, FoodPic, ingredientList, desc, instructions);
            //TODO save this food item
        }
    }
}
