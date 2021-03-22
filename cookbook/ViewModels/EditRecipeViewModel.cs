using cookbook.Models;
using cookbook.Services;
using cookbook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cookbook.ViewModels
{
    public class EditRecipeViewModel : ObservableObject, IPageViewModel
    {
        public ICommand LoadCookbookCommand { get; private set; }
        public ICommand LoadRecipeCommand { get; private set; }

        private Recipe _recipe;
        public Recipe Recipe
        {
            get { return _recipe; }
            set { _recipe = value; }
        }

        public EditRecipeViewModel(Recipe recipe = null)
        {
            if (recipe == null)
            {
                Recipe = new Recipe();
            }
            else
            {
                Recipe = recipe;
            }

            LoadCookbookCommand = new RelayCommand(LoadCookbook);
            LoadRecipeCommand = new RelayCommand(LoadRecipe);
        }

        private void LoadCookbook(object obj)
        {
            Mediator.Notify("LoadCookbookView", "All");
        }

        private void LoadRecipe(object obj)
        {
            Mediator.Notify("AddRecipe", obj);
            Mediator.Notify("LoadRecipeView", obj);
        }
    }
}
