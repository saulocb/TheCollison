using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	public float Tempo =0;
	public RaycastHit Obj;
	public Rigidbody Rg;
	public AudioSource Audioo;
	public AudioClip Explosao;
	public AudioClip Missio;
	// Use this for initialization

	void Start () {
		Rg = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, 2400 * Time.deltaTime);

		if (Tempo > 5) {
			Destroy (gameObject);
			Tempo = 0;
		}
		Tempo = Tempo + 1 * Time.deltaTime;

		if (Physics.Raycast (transform.position, transform.forward, out Obj, 70)) {
			if (Obj.transform.gameObject.CompareTag ("Play")) {
				PlaySoud(Explosao);
				Destroy (gameObject);
				Handheld.Vibrate();
				ControlePlay.VidaPlay --;
			}
		} else if (Physics.Raycast (transform.position, - transform.forward, out Obj, 70)) {
			if (Obj.transform.gameObject.CompareTag ("Play")) {
				PlaySoud(Explosao);
				Destroy (gameObject);
				Handheld.Vibrate();
				ControlePlay.VidaPlay --;
			}
		} 
	}
	public void OnTriggerEnter(Collider col){

		if (col.gameObject.CompareTag ("Play")) {
			ControlePlay.VidaPlay --;
			PlaySoud(Explosao);
			Handheld.Vibrate();
		    Destroy (gameObject);
		}
	}

	public void PlaySoud(AudioClip clipe){
		//if(Audioo.isPlaying){
			Audioo.clip = clipe;
			Audioo.Play();
		//}
	}


}
