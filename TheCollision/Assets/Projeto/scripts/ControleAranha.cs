using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControleAranha : MonoBehaviour {
    public NavMeshAgent Nav;
    public const string path = "predios";
    public static List<Predio> Predios;
    public static bool Atack = false;
    public Animator Animacao;
    public string NomePredio;
    public Transform destinoAtaque;
    public AudioSource Audioo;
    public Transform Arma;
    public GameObject Bomba;
    public AudioClip SomBomba;

    public static int IndiceCompartilhado;
    public float TempoBoma = 0;
    public float pathEndThreshold = 0.1f;
    private bool TemDestino = false;  



    // Use this for initialization
    void Start () {
        // BayteGame/ saulo candido / inicializa componetes
        Nav = GetComponent<NavMeshAgent>();
        Audioo = GetComponent<AudioSource>();
        Arma = gameObject.transform.Find("hips/spine/ArmaAranha02/posicaoBala").transform;

        // BayteGame/ saulo candido / inicializa objetos
        PredioContainer pre = PredioContainer.Load(path);
        Predios = pre.predios;
    }
	
	// Update is called once per frame
	void Update () {


        if (!Atack)
        {
            Animacao.SetFloat("speed", 10);
            Animacao.SetBool("Andar", true);
            var indice = Random.RandomRange(0, 2);
            NomePredio = PredioLoad.Predios[0].Nome; //deve ir o indice para cá
            IndiceCompartilhado = indice;
            destinoAtaque = GameObject.Find(NomePredio).transform;
            Nav.SetDestination(destinoAtaque.position);
            Predio predio = PredioLoad.Predios[indice];
            PredioLoad.Predios.Remove(predio);
            Atack = true;   
        }

        if (ValidaChegouNoDestino())
        {
            Animacao.SetFloat("speed", 0);
            Animacao.SetBool("Andar", false);
            transform.LookAt(destinoAtaque);

            //BayteGame / saulo candido/ ataca o predio            
            Arma.transform.LookAt(destinoAtaque);

            if (TempoBoma > 2) {
                Instantiate(Bomba, Arma.position, Arma.rotation);
                PlaySoud(SomBomba);
                TempoBoma = 0;
            }

            TempoBoma = TempoBoma + 1 * Time.deltaTime;
        }

	}

    bool ValidaChegouNoDestino()
    {
        TemDestino |= Nav.hasPath;
        if (TemDestino && Nav.remainingDistance <= Nav.stoppingDistance + pathEndThreshold )
        {
            // Arrived         
            return true;
        }

        return false;
    }

    public void PlaySoud(AudioClip clipe)
    {
        //if(Audioo.isPlaying){
        Audioo.clip = clipe;
        Audioo.Play();
        //}
    }




}
