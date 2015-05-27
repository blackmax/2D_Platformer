using UnityEngine;
using System.Collections;

public class DeserEffect : MonoBehaviour {
	public Transform[] DesertEffect;
	// Use this for initialization
	void Start () {
		Transform cam = Camera.main.transform;
		Debug.Log (DesertEffect[0].transform.position);
		Debug.Log (DesertEffect.Length);
		float x = 5.5f;
		DesertEffect[0].position = new Vector3 (5.5f,5.5f,0);
		Debug.Log (DesertEffect[0].transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
