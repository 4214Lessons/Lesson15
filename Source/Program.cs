using Newtonsoft.Json;
using Source.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;


#nullable disable


// XmlSerialize
// JsonSerialize
// BinarySerialize




void XmlWrite()
{
    List<Car> cars = new List<Car>()
    {
        new Car{ Model = "Mustang", Make = "Ford", Year = 1964 },
        new Car{ Model = "La Ferrari", Make = "Ferrari", Year = 2000 },
        new Car{ Model = "Chiron", Make = "Buggati", Year = 2018 }
    };

    using var writer = new XmlTextWriter("cars.xml", Encoding.Default);
    writer.Formatting = System.Xml.Formatting.Indented;

    writer.WriteStartDocument();
    writer.WriteStartElement("cars");

    foreach (Car car in cars)
    {
        writer.WriteStartElement("car");

        // writer.WriteElementString(nameof(car.Year), car.Year.ToString());
        // writer.WriteElementString(nameof(car.Make), car?.Make);
        // writer.WriteElementString(nameof(car.Model), car?.Model);

        writer.WriteAttributeString(nameof(car.Year), car.Year.ToString());
        writer.WriteAttributeString(nameof(car.Make), car.Make);
        writer.WriteAttributeString(nameof(car.Model), car.Model);

        writer.WriteEndElement();
    }

    writer.WriteEndElement();
    writer.WriteEndDocument();
}

void XmlRead()
{
    XmlDocument doc = new XmlDocument();
    doc.Load("cars.xml");

    var root = doc.DocumentElement;

    if (root.HasChildNodes)
    {
        foreach (XmlNode node in root.ChildNodes)
        {
            var car = new Car
            {
                Year = int.Parse(node.Attributes[0].Value),
                Make = node.Attributes[1].Value,
                Model = node.Attributes[2].Value
            };

            Console.WriteLine(car);
        }
    }
}







void XmlSerialize()
{
    var army = new TranslatorArmy
    {
        Name = "Step IT Academy",
        Location = "Koroglu Rehimov",
        Translators = new List<Translator>
        {
            new Translator("Tural", "Novruzov", 1)
            {
                Subjects = new List<Subject>
                {
                    new Subject{ Name = "C#", Degree = 42, Lessons = 18},
                    new Subject{ Name = "C++", Degree = 1, Lessons = 100},
                    new Subject{ Name = "java", Degree = 15, Lessons = -15},
                }
            },
            new Translator("Aga", "Akbarzade", 2)
            {
                Subjects = new List<Subject>
                {
                    new Subject{ Name = "C", Degree = 35, Lessons = 17},
                    new Subject{ Name = "ASP.Net Core", Degree = 14, Lessons = 48},
                    new Subject{ Name = "HTML/CSS", Degree = 57, Lessons = 9},
                }
            },
            new Translator("Ferman", "Asadov", 3)
            {
                Subjects = new List<Subject>
                {
                    new Subject{ Name = "Roboto Texnika", Degree = 60, Lessons = 120},
                    new Subject{ Name = "Photoshop", Degree = 13, Lessons = 19}
                }
            }
        }
    };


    var xml = new XmlSerializer(typeof(TranslatorArmy));
    using var fs = new FileStream("TranslatorArmy.xml", FileMode.Create);
    xml.Serialize(fs, army);

    Console.WriteLine("Ready");
}

void XmlDeserialize()
{
    TranslatorArmy army = null;

    var xml = new XmlSerializer(typeof(TranslatorArmy));
    using var fs = new FileStream("TranslatorArmy.xml", FileMode.Open);
    army = xml.Deserialize(fs) as TranslatorArmy;

    Console.WriteLine("Deserialized");
    Console.WriteLine(army);
}







void JSONSerializeMethod()
{
    Car[] cars =
    {
        new Car{ Model = "Mustang", Make = "Ford", Year = 1964 },
        new Car{ Model = "La Ferrari", Make = "Ferrari", Year = 2000 },
        new Car{ Model = "Chiron", Make = "Buggati", Year = 2018 }
    };


    //// Way 1
    {
        //// JsonSerializerOptions op = new JsonSerializerOptions();
        //// op.WriteIndented = true;
        //// Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(cars, op));
        //
        //
        // var jsonString = System.Text.Json.JsonSerializer.Serialize(cars);
        // File.WriteAllText("cars.json", jsonString);
    }




    //// Way 2
    {
        // var jsonString = JsonConvert.SerializeObject(cars, Newtonsoft.Json.Formatting.Indented);
        // File.WriteAllText("carsWithNewtonsoft.json", jsonString);
    }
}

void JSONDeserializeMethod()
{
    Car[] cars = null;

    //// Way 1
    {

        using FileStream fs = new FileStream("cars.json", FileMode.Open);
        cars = System.Text.Json.JsonSerializer.Deserialize<Car[]>(fs);
    }


    //// Way 2
    {
        // var stringData = File.ReadAllText("carsWithNewtonsoft.json");
        // cars = JsonConvert.DeserializeObject<Car[]>(stringData);
    }


    foreach (var car in cars)
        Console.WriteLine(car);
}







void BinarySerializeMethod()
{
    Car[] cars =
    {
        new Car{ Model ="Mustang", Make ="Ford", Year= 1964 },
        new Car{ Model ="La Ferrari", Make ="Ferrari", Year= 2000 },
        new Car{ Model ="Chiron", Make ="Buggati", Year= 2018 }
    };

    var bf = new BinaryFormatter();
    using var fs = new FileStream("binaryCars.bin", FileMode.Create);

    bf.Serialize(fs, cars);

    Console.WriteLine("Ready");
}

void BinaryDeserializeMethod()
{
    Car[] cars = null;

    var bf = new BinaryFormatter();
    using var fs = new FileStream("binaryCars.bin", FileMode.Open);

    cars = bf.Deserialize(fs) as Car[];


    foreach (var car in cars)
        Console.WriteLine(car);
}







// -----------  Main  -----------


// XmlWrite();
// XmlRead();



// XmlSerialize();
// XmlDeserialize();



// JSONSerializeMethod();
// JSONDeserializeMethod();



// BinarySerializeMethod();
// BinaryDeserializeMethod();







Console.WriteLine($"{Environment.GetFolderPath(0)}\\Images");






switch (2)
{
    case 0:
        Console.WriteLine("A");
        break;
    case 1:
        Console.WriteLine("B");
        break;
    case 2:
        Console.WriteLine("C");
        goto case 0;
}




for (int i = 0; i < 10; i++)
{
    if (i == 5) 
        goto label;

    Console.WriteLine(i);
}


Console.WriteLine("DoSomehting");

label:

Console.WriteLine("Terminated");