using System.Collections.Generic;
using System.Xml.Serialization;

namespace Source.Models;


//[Serializable]
public class Translator
{
    [XmlArray(elementName: "TranslatedSubjects")]
    public List<Subject>? Subjects { get; set; }

    [XmlAttribute(AttributeName = "Identification")]
    public int Id { get; set; }


    [XmlAttribute]
    public string? Name { get; set; }

    [XmlAttribute]
    public string? Surname { get; set; }


    public string Fullname => $"{Name} {Surname}";


    public Translator() { }

    public Translator(string name, string surname, int id)
    {
        Name = name;
        Surname = surname;
        Id = id;
    }


    public override string ToString() => $"{Id} {Fullname}";
}
