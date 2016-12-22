using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISW.Model
{
    class OptionCategory
    {
        public OptionCategory(int id)
        {
            _id = id;
        }

        // Option Category ID
        private int _id;
        public int ID
        {
            get { return _id; }
        }

        // Option Category Description
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
