namespace DataBank
{
    public class ColorData
    {

        public string _id;
        public string _type;
        public string _color;
        public string _dateCreated;

        public ColorData(string id, string type, string color)
        {
            _id = id;
            _type = type;
            _color = color;
            _dateCreated = "";
        }

        public ColorData(string id, string type, string color, string dateCreated)
        {
            _id = id;
            _type = type;
            _color = color;
            _dateCreated = dateCreated;
        }
    }
}
