using UnityEngine;
using System.Collections;

public class LeftButton : MonoBehaviour {

	public GameObject player;
	
	void OnTouchDown() {
		player.GetComponent<CharacterController2D>().Left();
		GetComponent<SpriteRenderer>().color = Color.cyan;
	}
	
	void OnTouchUp() {
		player.GetComponent<CharacterController2D>().Stop();
		GetComponent<SpriteRenderer>().color = Color.white;
	}
	
	void OnTouchStay() {
		player.GetComponent<CharacterController2D>().Left();
		GetComponent<SpriteRenderer>().color = Color.cyan;
	}
	
	void OnTouchExit() {
		player.GetComponent<CharacterController2D>().Stop();
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}
