using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using cookbook.Models;
using cookbook.ViewModels;
using Microsoft.Win32;

namespace cookbook.Views
{
    /// <summary>
    /// Logika interakcji dla klasy EditRecipeView.xaml
    /// </summary>
    public partial class EditRecipeView : UserControl
    {
        private string _imagePath;
        private Recipe _newRecipe;
        public Recipe NewRecipe
        {
            get { return _newRecipe; }
            set { _newRecipe = value; }
        }
        private EditRecipeViewModel _viewModelDataContext;
        public EditRecipeViewModel ViewModelDataContext
        {
            get { return _viewModelDataContext; }
            set { _viewModelDataContext = value; }
        }
        public EditRecipeView()
        {
            InitializeComponent();

            DataContextChanged += new DependencyPropertyChangedEventHandler(UserControl1_DataContextChanged);
                         
        }

        void UserControl1_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // You can also validate the data going into the DataContext using the event args
            if(NewRecipe == null)
            {
                LoadRecipe();
            }
        }

        private void PickImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true) {
                imagePath.Content = dialog.SafeFileName;
                _imagePath = dialog.FileName;
                ImagePreview.Source = new BitmapImage(new Uri(_imagePath));
            }
        }

        private void IngredientStackPanel(string name = null, string amount = null, string unit = "g")
        {
            IEnumerable<string> units = new string[]
            {
                "g",
                "dg",
                "kg",
                "cup",
                "spoon",
                "ml",
                "dl",
                "l",
                "unit"
            };
            StackPanel IngredientStackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            ComboBox comboBox = new ComboBox
            {
                ItemsSource = units,
                SelectedItem = unit
            };

            TextBox nameTextBox = new TextBox()
            {
                Text = name
            };

            TextBox amountTextBox = new TextBox()
            {
                Text = amount
            };

            IngredientStackPanel.Children.Add(nameTextBox);
            IngredientStackPanel.Children.Add(amountTextBox);
            IngredientStackPanel.Children.Add(comboBox);

            IngredientList.Children.Add(IngredientStackPanel);
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            IngredientStackPanel();
            //IngredientList.Children.Add(new IngredientForm());
        }

        private void AddInstruction_Click(object sender, RoutedEventArgs e)
        {
            InstructionList.Children.Add(new TextBox());
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            ViewModelDataContext = (EditRecipeViewModel)this.DataContext;

            bool error = false;

            if (RecipeName.Text == "")
            {
                RecipeName.BorderBrush = Brushes.Red;
            }
            else
            {
                NewRecipe.Name = RecipeName.Text;
            }

            NewRecipe.Category = ((ComboBoxItem)Category.SelectedItem).Content.ToString();

            if (People.Text == "")
            {
                People.BorderBrush = Brushes.Red;
                error = true;
            }
            else
            {
                int people;
                if (int.TryParse(People.Text, out people))
                {
                    NewRecipe.People = people;
                }
                else
                {
                    People.BorderBrush = Brushes.Red;
                    error = true;
                }

            }

            if (Time.Text == "")
            {
                Time.BorderBrush = Brushes.Red;
            }
            else
            {
                int time;
                if (int.TryParse(Time.Text, out time))
                {
                    NewRecipe.Time = time;
                }
                else
                {
                    Time.BorderBrush = Brushes.Red;
                    error = true;
                }
            }

            if(Description.Text == "")
            {
                Description.BorderBrush = Brushes.Red;
            }
            else
            {
                NewRecipe.Description = Description.Text;
            }

            int NumOfIngredients = IngredientList.Children.Count;
            Ingredient[] ingredients = new Ingredient[NumOfIngredients];

            for (int i = 0; i < NumOfIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();

                StackPanel stackPanel = (StackPanel)IngredientList.Children[i];

                ingredient.Index = i + 1;

                if (((TextBox)stackPanel.Children[0]).Text == "")
                {
                    ((TextBox)stackPanel.Children[0]).BorderBrush = Brushes.Red;
                    error = true;
                }
                else
                {
                    ingredient.Name = ((TextBox)stackPanel.Children[0]).Text;
                }

                if (((TextBox)stackPanel.Children[1]).Text == "")
                {
                    ((TextBox)stackPanel.Children[1]).BorderBrush = Brushes.Red;
                    error = true;
                }
                else
                {
                    int amount;
                    if (int.TryParse(((TextBox)stackPanel.Children[1]).Text, out amount))
                    {
                        ingredient.Amount = amount;
                    }
                    else
                    {
                        ((TextBox)stackPanel.Children[0]).BorderBrush = Brushes.Red;
                        error = true;
                    }
                }

                ComboBox comboBox = (ComboBox)stackPanel.Children[2];
                ingredient.Unit = (string)comboBox.SelectedItem;

                ingredients[i] = ingredient;
            }

            NewRecipe.Ingredients = ingredients;

            int NumOfInstructions = InstructionList.Children.Count;
            Instruction[] instructions = new Instruction[NumOfInstructions];

            for (int i = 0; i < NumOfInstructions; i++)
            {
                if (((TextBox)InstructionList.Children[i]).Text == "")
                {
                    ((TextBox)InstructionList.Children[i]).BorderBrush = Brushes.Red;
                }
                else
                {
                    Instruction instruction = new Instruction
                    {
                        Index = i + 1,
                        Content = ((TextBox)InstructionList.Children[i]).Text
                    };
                    instructions[i] = instruction;
                }
            }

            NewRecipe.Instructions = instructions;

            NewRecipe.IsEditable = true;

            if (!error)
            {
                Directory.CreateDirectory("Images");
                string path = string.Format("Images\\{0}", imagePath.Content);
                if (!File.Exists(path))
                {
                    File.Copy(_imagePath, path);
                }
                NewRecipe.ImagePath = System.IO.Path.GetFullPath(path);

                ViewModelDataContext.LoadRecipeCommand.Execute(NewRecipe);
            }
        }

        private void LoadRecipe()
        {
            ViewModelDataContext = (EditRecipeViewModel)this.DataContext;

            NewRecipe = ViewModelDataContext.Recipe;

            if(NewRecipe.ImagePath != null)
            {            
                ImagePreview.Source = new BitmapImage(new Uri(NewRecipe.ImagePath));
            }

            if(NewRecipe.Name != null)
            {
                RecipeName.Text = NewRecipe.Name;
            }
            
            if(NewRecipe.People != 0)
            {
                People.Text = NewRecipe.People.ToString();
            }
            
            if(NewRecipe.Time != 0)
            {
                Time.Text = NewRecipe.Time.ToString();
            }
            
            if(NewRecipe.Category != null)
            {
                Category.SelectedItem = NewRecipe.Category;
            }
            
            if(NewRecipe.Description != null)
            {
                Description.Text = NewRecipe.Description;
            }
            
            if(NewRecipe.Ingredients != null)
            {
                for (int i = 0; i < NewRecipe.Ingredients.Length; i++)
                {
                    Ingredient ingredient = NewRecipe.Ingredients[i];
                    IngredientStackPanel(ingredient.Name, ingredient.Amount.ToString(), ingredient.Unit);
                }
            }
            
            if(NewRecipe.Instructions != null)
            {
                for (int i = 0; i < NewRecipe.Instructions.Length; i++)
                {
                    Instruction instruction = NewRecipe.Instructions[i];
                    TextBox textBox = new TextBox
                    {
                        Text = instruction.Content
                    };
                    InstructionList.Children.Add(textBox);
                }
            }
        }
    }
}
