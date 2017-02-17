using UnityEngine;
using System.Collections;

public class MiraMovimento : MonoBehaviour {
	public RaycastHit raioGame;
	//public Camera cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var raio = Input.mousePosition;
	//	transform.LookAt (raio);


		if (Physics.Raycast (transform.position, - transform.up, out raioGame) && raioGame.transform.gameObject.CompareTag("Inimigo") ) {
				print ("COlidio Inimigo");
		}  else

		if (Physics.Raycast (transform.position, transform.forward, out raioGame)&& raioGame.transform.gameObject.CompareTag("Inimigo") ) {
			
			print ("COlidio Inimigo");

		} else  
		if (Physics.Raycast (transform.position, - transform.forward, out raioGame)&& raioGame.transform.gameObject.CompareTag("Inimigo") ) {
			print ("COlidio Inimigo");
		} else {
			print ("Saio");
		}
		



		
		
	
	}
}
