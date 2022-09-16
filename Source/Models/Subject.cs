using System.Xml.Serialization;

namespace Source.Models;


// [Serializable]
public struct Subject
{
    [XmlAttribute] // [XmlIgnore]
    public string Name { get; set; }

    [XmlAttribute]
    public int Degree { get; set; }

    [XmlAttribute]
    public int Lessons { get; set; }
}