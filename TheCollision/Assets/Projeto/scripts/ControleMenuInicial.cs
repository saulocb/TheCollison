using UnityEngine;
using System.Collections;

public class ControleMenuInicial : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	public void Jogar(){

		Application.LoadLevel("Cena01");
	}

	public void Sair(){
		Application.Quit ();

	}







}
