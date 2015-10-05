using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace DataAccess.BackEnd
{
    public class Artists
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string style { get; set; }
        public string year { get; set; }

        public Artists(string Id, string name, string style, string year)
        {
            this._id = Id;
            this.name = name;
            this.style = style;
            this.year = year;
        }
    }
}
