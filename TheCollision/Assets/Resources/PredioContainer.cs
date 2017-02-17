using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;


[XmlRoot("ListaPredio")]
public class PredioContainer {

    [XmlArray("Predios")]
    [XmlArrayItem("predio")]
    public List<Predio> predios = new List<Predio>();

    public static PredioContainer Load(string path) {

        TextAsset _xml = Resources.Load<TextAsset>(path);
        XmlSerializer serializer = new XmlSerializer(typeof(PredioContainer));
        StringReader reader = new StringReader(_xml.text);
        PredioContainer predios = serializer.Deserialize(reader)as PredioContainer;                        
        reader.Close();
        return predios;
    }



}   
