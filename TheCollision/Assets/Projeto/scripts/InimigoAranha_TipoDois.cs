    using UnityEngine;
using System.Collections;

public class InimigoAranha_TipoDois : MonoBehaviour
{
    public NavMeshAgent Nav;
    public float Tempo = 0;
    public Animator Animacao;

    public GameObject play;
    public Transform PosicaoBala;
    public GameObject Bala;
    public bool Atack = false;
    public float TempoBala = 0;
    public AudioSource Audioo;
    public AudioClip Explosao;
    public AudioClip Missio;
    public AudioClip ExplosaoMetal;
    public AudioClip ExplosaoAtack;

    public GameObject Bomba;
    public GameObject ExplosaoFumasa;
    public int VidaInimigo = 150;

    public Transform Arma;
    public Transform PosicaBalaAranha;





    public Transform[] PosicaoAranha;
    // Use this for initialization
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        Arma = gameObject.transform.Find("hips/spine/ArmaAranha").transform;
        play = GameObject.Find("ArnaPlay");
        PosicaBalaAranha = gameObject.transform.Find("hips/spine/ArmaAranha/PosicaoBalaAranha").transform;


        
        PosicaoAranha = new Transform[7];
        PosicaoAranha[0] = GameObject.Find("DestinoAranha").transform;
        PosicaoAranha[1] = GameObject.Find("DestinoAranha01").transform;
        PosicaoAranha[2] = GameObject.Find("DestinoAranha02").transform;
        PosicaoAranha[3] = GameObject.Find("DestinoAranha03").transform;
        PosicaoAranha[4] = GameObject.Find("DestinoAranha04").transform;
        PosicaoAranha[5] = GameObject.Find("DestinoAranha05").transform;
        PosicaoAranha[6] = GameObject.Find("DestinoAranha06").transform;

    }


    void Update()
    {

        if (Tempo > 15 && Atack == false)
        {
            Nav.ResetPath();
            Animacao.SetFloat("speed", 10);
            Animacao.SetBool("Andar", true);
            int valor = Random.Range(0, 6);
             Nav.SetDestination( new Vector3( PosicaoAranha[valor].position.x,0,PosicaoAranha[valor].position.z));	
            Tempo = 0;
        }

        //BayteGame / saulo candido / se o play atirar e ouver colisao este gameObject  atack durante 10 segundos
        if (Atack)
        {
            Arma.LookAt(play.transform.position);
            //BayteGame/saulo candido acada 3 segundo instancia uma bala
            if (TempoBala > 1)
            {
                PlaySoud(ExplosaoAtack);
                Instantiate(Bala, PosicaBalaAranha.position, PosicaBalaAranha.rotation);
                TempoBala = 0;
            }
            TempoBala = TempoBala + 1 * Time.deltaTime;

            if (Tempo > 20)
            {
                Atack = false;
                Tempo = 0 * Time.deltaTime;
            }
        }
        Tempo = Tempo + 1 * Time.deltaTime;

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("BalaPlay"))
        {
            Atack = true;
            Destroy(col.gameObject);
            VidaInimigo--;
            if (VidaInimigo < 50)
            {
                Instantiate(ExplosaoFumasa, col.transform.position, col.transform.rotation);

            }
            if (VidaInimigo <= 0)
            {
                PlaySoud(ExplosaoMetal);
                Instantiate(Bomba, col.transform.position, col.transform.rotation);
                Destroy(gameObject);
            }

        }
    }
    public void PlaySoud(AudioClip clipe)
    {
        //if(Audioo.isPlaying){
        Audioo.clip = clipe;
        Audioo.Play();
        //}
    }




}
