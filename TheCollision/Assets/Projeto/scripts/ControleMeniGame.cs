using UnityEngine;
using System.Collections;

public class ControleMeniGame : MonoBehaviour {
	public Canvas MenuGame;
	// Use this for initialization
	void Start () {
		MenuGame.enabled = false;
	}
	
	public void Jogar(){
		
		Application.LoadLevel("Cena01");
	}
}
