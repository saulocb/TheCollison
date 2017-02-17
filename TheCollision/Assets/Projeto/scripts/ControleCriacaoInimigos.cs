using UnityEngine;
using System.Collections;

public class ControleCriacaoInimigos : MonoBehaviour {
    public GameObject InimigoNovo;
    public Transform PosicaoNovoInimigo;
    // Use this for initialization
    void Start () {
        PosicaoNovoInimigo = GameObject.Find("posicaoNovoInimigo").transform;

    }
	
	// Update is called once per frame
	void Update () {
        if (Inimigo.NovoInimigo) {
            Inimigo.NovoInimigo = false;
            StartCoroutine(Dalaye(4));
            Instantiate(InimigoNovo, PosicaoNovoInimigo.position, transform.rotation);
        }
    }

    
    public IEnumerator Dalaye(int time)
    {
        yield return new WaitForSeconds(time);
    }
}
