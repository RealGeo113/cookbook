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
    public class RecipeViewModel : ObservableObject, IPageViewModel
    {
        private string _cookbookMode;
        private object _selectedRecipe;
        public object SelectedRecipe
        {
            get { return _selectedRecipe; }
            set { OnPropertyChanged(ref _selectedRecipe, value); }
        }
        public RecipeViewModel(Recipe recipe, string cookbookMode = "All")
        {
            _cookbookMode = cookbookMode;
            _selectedRecipe = recipe;
            LoadCookbookCommand = new RelayCommand(LoadCookbook);
            EditRecipeCommand = new RelayCommand(EditRecipe);
            RemoveRecipeCommand = new RelayCommand(RemoveRecipe);
            MarkFavoriteCommand = new RelayCommand(MarkFavorite);
        }

        public ICommand LoadCookbookCommand { get; private set; }
        public ICommand EditRecipeCommand { get; private set; }

        public ICommand RemoveRecipeCommand { get; private set; }
        public ICommand MarkFavoriteCommand { get; private set; }
        private void LoadCookbook(object obj)
        {
            if(_cookbookMode == "All")
            {
                Mediator.Notify("LoadCookbookView", _cookbookMode);
            }
        }
        private void EditRecipe(object obj)
        {
            Mediator.Notify("LoadEditRecipeView", obj);
        }

        private void RemoveRecipe(object obj)
        {
            Mediator.Notify("RemoveRecipe", obj);
            LoadCookbook("");
        }

        private void MarkFavorite(object obj)
        {
            Mediator.Notify("AddRecipe", obj);
        }
    }
}
