using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Velocity : MonoBehaviour {

	public Rigidbody2D player;
	public bool checkX = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (checkX) GetComponent<Text>().text = "" + player.velocity.x;
		else GetComponent<Text>().text = "" + player.velocity.y;
	}
}
