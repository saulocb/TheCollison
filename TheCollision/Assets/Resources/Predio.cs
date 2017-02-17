using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;


public class Predio
{

    [XmlAttribute("name")]
    public string name;

    [XmlElement("Nome")]
    public string Nome;


}
