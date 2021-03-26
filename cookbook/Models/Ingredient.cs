using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Models
{
    public class Ingredient
    {
        private int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public string AmountFormatted
        {
            get { return string.Format("{0} {1}", _amount, _unit); }
        }

        public string IndexFormatted
        {
            get { return string.Format("{0}.", _index); }
        }
    }
}
