using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler{
	public Image butao;
	public static bool Atirar = false;
	// Use this for initialization
	void Start () {
		butao = GetComponent<Image> ();
        butao.enabled = true;
	}

	public void OnPointerDown(PointerEventData ped){
		Atirar = true;
	}





}
