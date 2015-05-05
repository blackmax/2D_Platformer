using UnityEngine;
using System.Collections;

public class JetpackScript : MonoBehaviour {

	public bool jetpackEnabled = false; //Включение - выкючение джетпака
	public float jetpackFlyTime = 2f;	//Время полета
	public float jetpackForce = 200f;	//Сила джетпака
	public float jetpackFuelRecharge = 0.5f;
	public float test;
	private float jetpackFlyTimeStart;
	private Rigidbody2D player;
	private CharacterController2D playerControl;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
		playerControl = GetComponent<CharacterController2D>();
		jetpackFlyTimeStart = jetpackFlyTime;

	}
	void Update () {
		if (jetpackEnabled) {
			if ((playerControl.counter > 0) && Input.GetKeyDown(KeyCode.UpArrow) && (jetpackFlyTime > 0f && player.velocity.y <= 0)) {
				player.velocity = new Vector2(player.velocity.x, 0f);
				test = jetpackForce - player.velocity.y;
			}
			else if ((playerControl.counter > 0) && Input.GetKeyDown(KeyCode.UpArrow) && (jetpackFlyTime > 0f && player.velocity.y > 0)) {
				test = jetpackForce - player.velocity.y;
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		// Если джетпак активен
		if (jetpackEnabled) {
			if ((playerControl.counter > 0) && Input.GetKey(KeyCode.UpArrow) &&(jetpackFlyTime > 0f)) {
				jetpackFlyTime -= Time.deltaTime;
				player.AddForce(new Vector2(0f, test));
			}

			if (jetpackFlyTime < jetpackFlyTimeStart) jetpackFlyTime += jetpackFuelRecharge * Time.deltaTime;
			else jetpackFlyTime = jetpackFlyTimeStart;
		};
	}
}
