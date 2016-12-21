namespace ISW.Model
{
    class Option
    {
        public Option(int id)
        {
            _id = id;
        }

        private int _id;                //Option ID
        private int? _catID;            //Option Category ID
        private string _description;    //Option Description
        private int? _arrangeOptionsBy; //Display Order

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public int? CatID
        {
            get { return _catID; }
            set { _catID = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int? ArrangeOptionsBy
        {
            get { return _arrangeOptionsBy; }
            set { _arrangeOptionsBy = value; }
        }
    }
}
