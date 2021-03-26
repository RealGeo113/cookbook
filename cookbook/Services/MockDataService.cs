using cookbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Services
{
    public class MockDataService : IRecipeDataService
    {
        private IEnumerable<Recipe> _recipes;

        public MockDataService()
        {
            _recipes = new List<Recipe>()
            {
                new Recipe
                {
                    Name = "Face made of vegetables",
                    Category = "Appetizer",
                    ImagePath = "C:\\Users\\grzeg\\source\\repos\\cookbook_v2\\cookbook_v2\\Images\\1.jpg",
                    People = 1,
                    Time = 15,
                    Description = "This is a face made of vegetables, if you can't see cuz you're blind",
                    Ingredients = new Ingredient[]{
                        new Ingredient
                        {
                            Index = 1,
                            Name = "Tomatos",
                            Amount = "2",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 2,
                            Name = "Beans",
                            Amount = "150",
                            Unit = "g"
                        },
                        new Ingredient
                        {
                            Index = 3,
                            Name = "Leaves",
                            Amount = "50",
                            Unit = "g"
                        },
                        new Ingredient
                        {
                            Index = 4,
                            Name = "Olives",
                            Amount = "2",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 5,
                            Name = "Corn",
                            Amount = "50",
                            Unit = "g"
                        },
                        new Ingredient
                        {
                            Index = 6,
                            Name = "Carrots",
                            Amount = "3",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 7,
                            Name = "Pepper - Red",
                            Amount = "1",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 8,
                            Name = "Pepper - Yellow",
                            Amount = "1",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 9,
                            Name = "Potato",
                            Amount = "1",
                            Unit = ""
                        },
                    },
                    Instructions = new Instruction[]{
                        new Instruction{
                        Index = 1,
                        Content = "Wash all your vegetables."
                        },
                        new Instruction{
                        Index = 2,
                        Content = "Cut them to the size."
                        },
                        new Instruction{
                        Index = 3,
                        Content = "Make face out of them."
                        },
                        new Instruction{
                        Index = 4,
                        Content = "You're done!"
                        }

                    },
                    IsFavorite = false,
                    IsEditable = true
                },
                new Recipe
                {
                    Name = "Recipe To Test Very Long Names Because This is What I have to do.",
                    Category = "Soup",
                    ImagePath = null,
                    People = 2,
                    Time = 121,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                    Ingredients = new Ingredient[]{
                        new Ingredient
                        {
                            Index = 1,
                            Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                            Amount = "2",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 2,
                            Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                            Amount = "3",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 3,
                            Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                            Amount = "4",
                            Unit = ""
                        }
                    },
                    Instructions = new Instruction[]{
                        new Instruction
                        {
                            Index = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                        },
                        new Instruction
                        {
                            Index = 2,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                        },
                        new Instruction
                        {
                            Index = 3,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                        },
                        new Instruction
                        {
                            Index = 4,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce nec justo ut mi dictum pharetra. Aliquam luctus nisi vel libero consectetur aliquam. Suspendisse pharetra urna sed lorem ultricies consequat. Pellentesque blandit aliquet mauris, sed convallis turpis molestie ut. Maecenas tristique nec ligula ac maximus. Mauris sodales, erat ac pharetra molestie, justo libero euismod ante, in varius sem enim id augue. Phasellus a urna enimm.",
                        }
                    },
                    IsFavorite = true,
                    IsEditable = false
                },
                new Recipe
                {
                    Name = "Recipe 3",
                    Category = "Dessert",
                    ImagePath = null,
                    People = 3,
                    Time = 3,
                    Ingredients = new Ingredient[]{
                        new Ingredient
                        {
                            Index = 1,
                            Name = "3",
                            Amount = "3",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 2,
                            Name = "4",
                            Amount = "4",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 3,
                            Name = "5",
                            Amount = "5",
                            Unit = ""
                        }
                    },
                    Instructions = new Instruction[]{
                        new Instruction
                        {
                            Index = 1,
                            Content = "Instrucion 1"
                        },
                        new Instruction
                        {
                            Index = 2,
                            Content = "Instrucion 2"
                        },
                        new Instruction
                        {
                            Index = 3,
                            Content = "Instrucion 3"
                        },
                        new Instruction
                        {
                            Index = 4,
                            Content = "Instrucion 4"
                        }
                    },
                    IsFavorite = true,
                    IsEditable = false
                },
                new Recipe
                {
                    Name = "Recipe 4",
                    Category = "Lunch",
                    ImagePath = null,
                    People = 0,
                    Time = 1,
                    Ingredients = new Ingredient[]{
                        new Ingredient
                        {
                            Index = 1,
                            Name = "3",
                            Amount = "3",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 2,
                            Name = "4",
                            Amount = "4",
                            Unit = ""
                        },
                        new Ingredient
                        {
                            Index = 3,
                            Name = "5",
                            Amount = "5",
                            Unit = ""
                        }
                    },
                    Instructions = new Instruction[]{
                        new Instruction
                        {
                            Index = 1,
                            Content = "Instrucion 1"
                        },
                        new Instruction
                        {
                            Index = 2,
                            Content = "Instrucion 2"
                        },
                        new Instruction
                        {
                            Index = 3,
                            Content = "Instrucion 3"
                        },
                        new Instruction
                        {
                            Index = 4,
                            Content = "Instrucion 4"
                        }
                    },
                    IsFavorite = true,
                    IsEditable = false
                }
            };
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipes;
        }

        public void Save(IEnumerable<Recipe> recipes)
        {
            _recipes = recipes;
        }
    }
}
