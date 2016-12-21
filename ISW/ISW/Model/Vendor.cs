namespace ISW.Model
{
    class Vendor
    {
        private int _id;            //Vendor ID
        private string _title;      //Name of vendor
        private string _poTemplate; //po template

        // all vendors must contain an id, which cannot change.
        public Vendor(int id)
        {
            _id = id;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string PoTemplate
        {
            get
            {
                return _poTemplate;
            }
            set
            {
                _poTemplate = value;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }
    }
}
