using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab_3
{
    [Serializable]
    public struct Toy
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Price")]
        public decimal Price { get; set; }

        [XmlElement("MinAge")]
        public decimal MinAge { get; set; }

        [XmlElement("MaxAge")]
        public decimal MaxAge { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Price} руб., возраст {MinAge}-{MaxAge} лет";
        }

    }

    [Serializable]
    [XmlRoot("Toys")]
    public class ToyList
    {
        [XmlElement("Toy")]
        public Toy[] Items { get; set; }
    }
}
