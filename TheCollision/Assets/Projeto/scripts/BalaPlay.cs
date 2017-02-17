using UnityEngine;
using System.Collections;

public class BalaPlay : MonoBehaviour {
	public float Tempo =0;
	public RaycastHit Obj;
	public Rigidbody Rg;

	
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, 1400 * Time.deltaTime);
		if (Tempo > 5) {
			Destroy (gameObject);
			Tempo = 0;
		}
		Tempo = Tempo + 1 * Time.deltaTime;
	}


}
