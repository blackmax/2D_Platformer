using UnityEngine;
using System.Collections;


public class CharacterController2D : MonoBehaviour {
	public float playerSpeed = 4f;
	public float playerJumpForce = 500f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float groundCheckRadius = 0.2f;
	public bool grounded = false;
	public bool hasJumped = false;
	public bool jump = false;
	private bool facingRight = true;
	private Rigidbody2D player;

	void Start () {
		player = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		if (!jump) jump = Input.GetKeyDown(KeyCode.UpArrow);
	}
	
	
	
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		player.velocity = new Vector2(move * playerSpeed, player.velocity.y);
		
		if (move > 0 && !facingRight) Flip();
		else if (move < 0 && facingRight) Flip();


		if (Input.GetKey(KeyCode.RightArrow)) move = 1;
		else if (Input.GetKey(KeyCode.LeftArrow)) move = -1;
		else move = 0;


		grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				grounded = true;
		}
		//grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		
		if (grounded && jump) {
			grounded = false;
			player.AddForce(new Vector2(0f, playerJumpForce));
		}
		jump = false;
	}

	private void Flip() {
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
// test comment