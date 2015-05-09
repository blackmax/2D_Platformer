using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {
	public Rigidbody2D player;

	public Rigidbody2D background1;
	public Rigidbody2D background2;
	public Rigidbody2D background3;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		background1.velocity = new Vector2(player.velocity.x * 0.3f, player.velocity.y * 0.1f);
		background2.velocity = new Vector2(player.velocity.x * 0.5f, player.velocity.y * 0.3f);
		background3.velocity = new Vector2(player.velocity.x * 0.8f, player.velocity.y * 0.5f);
	}
}
