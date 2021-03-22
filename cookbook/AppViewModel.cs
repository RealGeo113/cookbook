using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cookbook.Models;
using cookbook.Services;
using cookbook.Utility;
using cookbook.ViewModels;
namespace cookbook
{
    public class AppViewModel : ObservableObject
    {
        private JsonRecipeDataService _dataService;

        private IPageViewModel _currentView;
        public IPageViewModel CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        public AppViewModel()
        {
            _dataService = new JsonRecipeDataService();
            CurrentView = new CookbookViewModel(_dataService);

            Mediator.Subscribe("LoadRecipeView", LoadRecipeViewModel);
            Mediator.Subscribe("LoadCookbookView", LoadCookbookViewModel);
            Mediator.Subscribe("LoadAddRecipeView", LoadAddRecipeViewModel);
            Mediator.Subscribe("LoadEditRecipeView", LoadEditRecipeViewModel);
        }

        private void LoadRecipeViewModel(object obj)
        {
            
            CurrentView = new RecipeViewModel((Recipe)obj);
        }

        private void LoadCookbookViewModel(object obj)
        {
            CurrentView = new CookbookViewModel(_dataService, (string)obj);
        }

        private void LoadAddRecipeViewModel(object obj)
        {
            CurrentView = new EditRecipeViewModel();
        }

        private void LoadEditRecipeViewModel(object obj)
        {
            CurrentView = new EditRecipeViewModel((Recipe)obj);
        }
    }
}
