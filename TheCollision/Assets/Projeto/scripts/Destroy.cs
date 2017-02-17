using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
    public float Tempo = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Tempo >= 5)
        {
            Destroy(gameObject);
        }
        Tempo = Tempo + 1 * Time.deltaTime;

	}
}
