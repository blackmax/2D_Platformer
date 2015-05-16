using UnityEngine;
using System.Collections;

public class agroRay : MonoBehaviour {
	public LayerMask playerMask;
	private Rigidbody2D body;
	private Vector2 way;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	void Update() {
		if (body.velocity.x < 0){
			way = new Vector2(-1.0f,0.0f);
		}
		else{
			way = new Vector2(1.0f,0.0f);
		}
		RaycastHit2D hit = Physics2D.Raycast(transform.position, way, 5, playerMask);
		if (hit.collider!=null) {
			Debug.Log ("alert!!!");
		}
	}
}