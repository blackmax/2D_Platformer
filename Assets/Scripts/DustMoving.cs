using UnityEngine;
using System.Collections;

public class DustMoving : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.Translate(new Vector3(-0.6f * Time.deltaTime, 0f, 0f));

		if (gameObject.transform.position.x < -20f){
			gameObject.transform.position = new Vector3(16f, 0f , -1f);
		}
	}
}
