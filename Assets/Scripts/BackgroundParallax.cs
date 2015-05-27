using UnityEngine;
using System.Collections;

public class BackgroundParallax : MonoBehaviour {
	public Transform background1;
	public Transform background2;
	public Transform background3;

	private Transform cam;
	private Vector3 previousCamPos;

	public float parallax;
	float background1TargetPosX;
	float backgroundTargetPosY;
	Vector3 background1TargetPos;

	float background2TargetPosX;
	//float backgroundTargetPosY;
	Vector3 background2TargetPos;

	float background3TargetPosX;
	//float backgroundTargetPosY;
	Vector3 background3TargetPos;

	void  Awake(){
		cam = Camera.main.transform;
	}
	
	// Use this for initialization
	void Start () {
		previousCamPos = cam.position;
	}
	
	// Update is called once per frame
	void Update () {
		parallax = (previousCamPos.x - cam.position.x);

		background1TargetPosX = background1.position.x - parallax * 30;
		background1TargetPos = new Vector3 (background1TargetPosX, background1.position.y, background1.position.z);
		background1.position = Vector3.Lerp(background1.position, background1TargetPos, Time.deltaTime);

		background2TargetPosX = background2.position.x - parallax * 40;
		background2TargetPos = new Vector3 (background2TargetPosX, background2.position.y, background2.position.z);
		background2.position = Vector3.Lerp(background2.position, background2TargetPos, Time.deltaTime);

		background3TargetPosX = background3.position.x - parallax * 50;
		background3TargetPos = new Vector3 (background3TargetPosX, background3.position.y, background3.position.z);
		background3.position = Vector3.Lerp(background3.position, background3TargetPos, Time.deltaTime);



		//backgroundTargetPosY = background1.position.y + (previousCamPos.y - cam.position.y);


		previousCamPos = cam.position;
	}
}
