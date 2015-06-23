using UnityEngine;
using System.Collections;

public class JumpButton : MonoBehaviour {
	public GameObject player;

	void OnTouchDown() {
		GetComponent<SpriteRenderer>().color = Color.cyan;
		player.GetComponent<CharacterController2D>().Jump();
	}

	void OnTouchUp() {
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	void OnTouchStay() {
		GetComponent<SpriteRenderer>().color = Color.cyan;
	}

	void OnTouchExit() {
		GetComponent<SpriteRenderer>().color = Color.white;
	}
}
