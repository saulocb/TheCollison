using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ControlePlay : MonoBehaviour {
	public GameObject Bala;
	public Transform PosicaoBala;
	public AudioSource Audioo;
	public AudioClip Explosao;
	public Transform Mira;
	public Texture2D imagem;
	public static int VidaPlay = 30;

	public Transform PosicaoFogo;
	public Transform PosicaoFumaca;
	public GameObject Fogo;
	public GameObject Fumaca;
	public bool AtivaFumaca = false;
	public bool AtivaFogo = false;
	public Canvas MenuGame;




	// Use this for initialization
	void Start () {
		Mira = GameObject.Find ("Mira").transform;

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Mira);

		//BayteGame/ saulo candido / Valida a vida do PLay 
		if(VidaPlay < 15 && AtivaFumaca == false){
			Instantiate(Fumaca, PosicaoFumaca.position,PosicaoFumaca.rotation);
			AtivaFumaca = true;
		}
		if(VidaPlay <=7 && AtivaFogo == false ){
			Instantiate(Fogo, PosicaoFogo.position,PosicaoFogo.rotation);
			AtivaFogo = true;
		
		}
		if(VidaPlay <=28){
           // VidaPlay = 30;
          //  Application.LoadLevel(0);
			
		}



		if(VirtualJoystick.Atirar){
			PlaySound(Explosao);
			Instantiate(Bala, PosicaoBala.position,PosicaoBala.rotation);
			VirtualJoystick.Atirar = false;
		}
	}

	
	public void PlaySound(AudioClip clipe){		
		Audioo.clip = clipe;
		Audioo.Play ();
	}





}
