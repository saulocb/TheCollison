using UnityEngine;
using System.Collections;

public class InimigoPaisana : MonoBehaviour {
	public NavMeshAgent Nav;
	public GameObject play;
	public Transform PosicaoBala;
	public GameObject Bala;
	public bool Atack = false;
	public float TempoBala = 0;
	public float Tempo = 0;
	public AudioSource Audioo;
	public AudioClip Explosao;
	public AudioClip Missio;
	public AudioClip ExplosaoMetal;

	public GameObject Bomba;
	public GameObject ExplosaoFumasa;
	public int VidaInimigo = 20;



	// Use this for initialization
	void Start () {
		Nav = GetComponent<NavMeshAgent> ();
		play =  GameObject.Find("ArnaPlay");     //PontoDeAtaqueInimigo
		Nav.SetDestination (new Vector3( Random.value,0, Random.value));
        PosicaoBala = gameObject.transform.Find("PosicaoBala").transform;




    }
	
	// Update is called once per frame
	void Update () {

		if(Tempo > 10 && Atack == false){
	        Nav.ResetPath();
            Nav.SetDestination(new Vector3(transform.position.x + Random.Range(-1000f, 1000f), 0, transform.position.z + Random.Range(-1000f, 1000f)));
            Tempo = 0;
		}

		//BayteGame / saulo candido / se o play atirar e ouver colisao este gameObject  atack durante 10 segundos
		if(Atack ){		
			transform.LookAt (play.gameObject.transform.position);	
			//BayteGame/saulo candido acada 3 segundo instancia uma bala
			if(TempoBala > 2){
				PlaySoud(Missio);
				Instantiate(Bala,PosicaoBala.position, PosicaoBala.rotation);
				TempoBala = 0;
			}
			TempoBala = TempoBala + 1 * Time.deltaTime;
			
			if(Tempo > 6){
				Atack = false;
				Tempo = 0 *  Time.deltaTime;
                Nav.SetDestination(new Vector3(transform.position.x + Random.Range(-1000f, 1000f), 0, transform.position.z + Random.Range(-1000f, 1000f)));
            }
		}
		Tempo = Tempo + 1 * Time.deltaTime;

	}

	public void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("BalaPlay")) {
			Atack = true;
			Destroy(col.gameObject);
			VidaInimigo --;
			if (VidaInimigo < 10) {
				Instantiate (ExplosaoFumasa, col.transform.position, col.transform.rotation);
				
			}
			if (VidaInimigo <= 0) {
				PlaySoud(ExplosaoMetal);
				Instantiate (Bomba, col.transform.position, col.transform.rotation);
				Destroy (gameObject);
			}
			
		}
	}


	
	public void PlaySoud(AudioClip clipe){
		//if(Audioo.isPlaying){
		Audioo.clip = clipe;
		Audioo.Play();
		//}
	}


}
