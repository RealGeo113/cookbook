using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Models
{
    public class Instruction
    {
        private int _index;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public string IndexFormatted
        {
            get { return string.Format("{0}.", _index); }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
