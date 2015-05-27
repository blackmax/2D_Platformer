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

	public int counter = 0;

	private bool facingRight = true;
	private Rigidbody2D player;

	public float move = 0f;
	public float testMove = 0f;
	public float testSpeed = 10f;
	public bool moveLeft = false;
	public bool moveRight = false;

	void Start () {
		player = GetComponent<Rigidbody2D>();
	}
	
	void Update() {
		if (counter == 0) {
			if (!jump) jump = Input.GetKeyDown(KeyCode.UpArrow);
		}
	}

	public void Left () {
		moveLeft = true;
		moveRight = false;
	}
	public void Stop () {
		moveLeft = false;
		moveRight = false;
	}
	public void Right () {
		moveRight = true;
		moveLeft = false;
	}
	
	void Movement () {
		if (moveLeft && move > -1f) move -= 4f * Time.deltaTime;
		else if (moveLeft && move < -1f) move = -1f;

		if (!moveLeft && !moveRight && move < -0.5f) move += 5f * Time.deltaTime;
		else if (!moveLeft && !moveRight && move > -0.5f) move = 0f;

		if (moveRight && move < 1f) move += 4f * Time.deltaTime;
		else if (moveRight && move > 1f) move = 1f;
		
		if (!moveRight && !moveLeft && move > 0.5f) move -= 5f * Time.deltaTime;
		else if (!moveRight && !moveLeft && move < 0.5f) move = 0f;
	}



	void FixedUpdate () {
		Movement ();



		//move = Input.GetAxis("Horizontal");

		player.velocity = new Vector2(move * playerSpeed, player.velocity.y);

		if (player.velocity.y < -15) player.velocity = new Vector2(player.velocity.x, -15);

		if (move > 0 && !facingRight) Flip();
		else if (move < 0 && facingRight) Flip();

		/*
		if (Input.GetKey(KeyCode.RightArrow)) move = 1;
		else if (Input.GetKey(KeyCode.LeftArrow)) move = -1;
		else move = 0;
		*/
		if (Input.GetKeyDown(KeyCode.UpArrow)) counter += 1;

		grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject) {
				grounded = true;
				counter = 0;
			}
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

