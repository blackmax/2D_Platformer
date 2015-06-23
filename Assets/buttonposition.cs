using UnityEngine;
using System.Collections;

public class buttonposition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log(transform.position);
		Debug.Log (GetComponent<RectTransform>().sizeDelta.x);
		Debug.Log(transform.position.x - GetComponent<RectTransform>().sizeDelta.x/2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
