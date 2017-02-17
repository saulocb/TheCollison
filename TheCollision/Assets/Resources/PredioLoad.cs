using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PredioLoad : MonoBehaviour {
    public const string path = "predios";
    public static List<Predio> Predios;


    static PredioLoad()
    {
        //PredioContainer pre = PredioContainer.Load(path);
        Predios = new List<Predio>();
        PredioContainer pre = PredioContainer.Load(path);
        Predios = pre.predios;
    }

}
