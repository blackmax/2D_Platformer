using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public GameObject player;


	void OnTouchDown() {
		player.GetComponent<CharacterController2D>().Left();
	}

	void OnTouchUp() {
		player.GetComponent<CharacterController2D>().Stop();
	}

	void OnTouchStay() {
		player.GetComponent<CharacterController2D>().Left();
	}

	void OnTouchExit() {
		player.GetComponent<CharacterController2D>().Stop();
	}
}
