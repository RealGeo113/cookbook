using cookbook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Models
{
    public class Recipe : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        private string _category;
        public string Category
        {
            get { return _category; }
            set { OnPropertyChanged(ref _category, value); }
        }

        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }

        private int _people;
        public int People
        {
            get { return _people; }
            set { OnPropertyChanged(ref _people, value); }
        }

        public string PeopleFormatted
        {
            get { return string.Format("People: {0}", _people); }
        }

        private int _time;
        public int Time
        {
            get { return _time; }
            set { OnPropertyChanged(ref _time, value); }
        }

        public string TimeFormatted
        {
            get
            {
                if (Time == 1)
                {
                    return "Time: 1 minute";
                }
                if (Time < 120)
                {
                    return string.Format("Time: {0} minutes", _time.ToString());
                }
                else
                {
                    float hours = _time / 60;
                    return string.Format("Time: {0} hours", hours.ToString());
                };
            }

        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { OnPropertyChanged(ref _description, value); }
        }

        private Ingredient[] _ingredients;
        public Ingredient[] Ingredients
        {
            get { return _ingredients; }
            set { OnPropertyChanged(ref _ingredients, value); }
        }

        private Instruction[] _instructions;
        public Instruction[] Instructions
        {
            get { return _instructions; }
            set { OnPropertyChanged(ref _instructions, value); }
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { OnPropertyChanged(ref _isFavorite, value); }
        }

        private bool _isEditable;
        public bool IsEditable
        {
            get { return _isEditable; }
            set { OnPropertyChanged(ref _isEditable, value); }
        }
    }
}
