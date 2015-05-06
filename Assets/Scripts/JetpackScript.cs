using UnityEngine;
using System.Collections;

public class JetpackScript : MonoBehaviour {

	public bool jetpackEnabled = false; //Включение - выкючение джетпака
	public float jetpackFlyTime = 2f;	//Время полета
	public float jetpackSpeed = 8f;	//Сила джетпака
	public float jetpackFuelRecharge = 0.5f;
	public bool jetpackRecharge = false;

	private float jetpackFlyTimeStart;
	private Rigidbody2D player;
	private CharacterController2D playerControl;

	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody2D>();
		playerControl = GetComponent<CharacterController2D>();
		jetpackFlyTimeStart = jetpackFlyTime;

	}

	void FixedUpdate () {
		// Если джетпак активен
		if (jetpackEnabled) {
			if ((playerControl.counter > 0) && Input.GetKey(KeyCode.UpArrow) && (jetpackFlyTime > 0f) && !jetpackRecharge) {
				jetpackFlyTime -= Time.deltaTime;
				player.velocity = new Vector2(player.velocity.x, jetpackSpeed);
			}

			if (jetpackFlyTime < 0) {
				jetpackRecharge = true;
				jetpackFlyTime += (jetpackFuelRecharge / 2) * Time.deltaTime;
			}
			else if (jetpackFlyTime < jetpackFlyTimeStart) {
				jetpackFlyTime += jetpackFuelRecharge * Time.deltaTime;
			}
			else if (jetpackFlyTime > jetpackFlyTimeStart) {
				jetpackFlyTime = jetpackFlyTimeStart;
				jetpackRecharge = false;
			}
		};
	}
}
