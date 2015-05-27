using UnityEngine;
using System.Collections;


public class botLogic : MonoBehaviour {
	public float botSpeed;
	public float botJumpForce;
	public LayerMask playerMask;

	private Rigidbody2D body;
	private bool facingLeft = true;
	private float way = 1f;

	void Start(){
		body = GetComponent<Rigidbody2D>();
		InvokeRepeating("Patrol", 0f, Random.Range(2f, 4f));
	}

	void Update(){
		way *= -1;
		RaycastHit2D hit = Physics2D.Raycast(transform.position,new Vector2(way, 0), 5, playerMask);
		if (hit.collider!=null) {
			Debug.Log ("alert!!!");
		}
	}

	void Patrol(){
		Vector3 wayCurrent = transform.localScale;
		facingLeft = !facingLeft;
		wayCurrent.x *=-1;
		transform.localScale = wayCurrent;
		body.velocity = new Vector2(botSpeed * wayCurrent.x, body.velocity.y);

	}
}
