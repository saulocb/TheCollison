using UnityEngine;
using System.Collections;

public class Inimigo : MonoBehaviour {
	public GameObject play;
	public GameObject arma;
	public NavMeshAgent Nav;
	public float Tempo = 0;
	public Animation anime;
	public bool Atack = false;
	public bool Atack2 = false;
	public Transform PosicaoBala;
	public GameObject Bala;
	public float TempoBala = 0;
	public AudioSource Audioo;
	public AudioClip Explosao;
	public AudioClip ExplosaoMetal;
	public AudioClip Missio;
	public Vector3 Posicao;
	public static Transform PosicaoInimigo;

	public GameObject Bomba;
	public GameObject ExplosaoFumasa;
	public int VidaInimigo = 20;
    public static bool NovoInimigo = false;
    public bool Moreu = false;


	
	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Nav = GetComponent<NavMeshAgent> ();
       
        play =  GameObject.Find("ArnaPlay");
        PosicaoBala = gameObject.transform.Find("PosicaoBala").transform;


       Nav.SetDestination (new Vector3( transform.position.x + Random.Range(-500f, 200f), 0,transform.position.z + Random.Range(-500f, 200f)));
	}
	
	// Update is called once per frame
	void Update () {
		PosicaoInimigo = transform;
       //Logica para ataque do inimigo 01
		if(Tempo > 10){
			Atack2 = true;
			Tempo = 0 *  Time.deltaTime;
		}
		
		if(Atack2){		
			transform.LookAt (play.gameObject.transform.position);
           
			Nav.ResetPath();
			//BayteGame/saulo candido / acada 2 segundo instancia uma bala
			if(TempoBala > 4){
				PlaySoud(Missio);
				Instantiate(Bala,PosicaoBala.position, PosicaoBala.rotation);
				TempoBala = 0;
			}
			TempoBala = TempoBala + 1 * Time.deltaTime;
			
			if(Tempo > 10){
				Atack = false;
				Atack2 = false;
				Tempo = 0 *  Time.deltaTime;
				Nav.SetDestination (new Vector3( transform.position.x + Random.Range(-1000f, 1000f), 0,transform.position.z + Random.Range(-1000f, 1000f)));
			}
		}

		Tempo = Tempo + 1 *  Time.deltaTime;

	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("BalaPlay")) {
			Destroy(col.gameObject);
			VidaInimigo --;
			if (VidaInimigo < 10) {
				Instantiate (ExplosaoFumasa, col.transform.position, col.transform.rotation);
				
			}
			if (VidaInimigo == 0) {
				PlaySoud(ExplosaoMetal);
				Instantiate (Bomba, col.transform.position, col.transform.rotation);
                Destroy(gameObject);
                NovoInimigo = true;                
                VidaInimigo = 20;
              

            }
		
		}
	}




	public IEnumerator Dalaye(int time){
		yield return new WaitForSeconds(time);
	}

	public void PlaySoud(AudioClip clipe){
		//if(Audioo.isPlaying){
			Audioo.clip = clipe;
			Audioo.Play();
		//}
	}


	

}
