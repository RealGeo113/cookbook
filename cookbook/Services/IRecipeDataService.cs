using cookbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Services
{
    public interface IRecipeDataService
    {
        IEnumerable<Recipe> GetRecipes();
        void Save(IEnumerable<Recipe> receipts);
    }
}
