using cookbook.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Services
{
    public class JsonRecipeDataService : IRecipeDataService
    {
        private string _dataPath = "Resources\\RecipeData.json";

        public IEnumerable<Recipe> GetRecipes()
        {
            if (!File.Exists(_dataPath))
            {
                Directory.CreateDirectory("Resources");
                File.Create(_dataPath).Close();
            }

            var serializedRecipes = File.ReadAllText(_dataPath);
            var recipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(serializedRecipes);

            if (recipes == null)
            {
                return new List<Recipe>();
            }

            return recipes;
        }

        public void Save(IEnumerable<Recipe> recipes)
        {
            var serializedRecipes = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(_dataPath, serializedRecipes);
        }
    }
}
