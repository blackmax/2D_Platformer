using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {
	public bool canAttack = true;
	public float attackCD = 1f;
	public float timeCD = 0.5f;

	public int boom = 0;

	// Use this for initialization
	void Start () {
		attackCD = timeCD;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Space) && canAttack) {
			// Выстрел
			boom += 1;
			// -------
			canAttack = false;
		}

		if (!canAttack && (attackCD > 0)) attackCD -= Time.deltaTime;
		else {
			canAttack = true;
			attackCD = timeCD;
		}
	}
}
