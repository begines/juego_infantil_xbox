using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerB : MonoBehaviour {


	public float fX = 10;
	public float fY = 10;
	public float mX = 4;
	public float mY = 4;
	bool onFloor = true;
	float valX = 0;
	bool piso = true;

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	}

	void Update () {

		float velY = fY;
		float velX = valX*fX;

		rb.AddForce (new Vector2 (velX, 0));


		if (Input.GetKey (KeyCode.Space) && onFloor) {
			rb.AddForce (new Vector2 (0, velY));
			onFloor = false;

		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			rb.AddForce (new Vector2 (0, 0));
		}

		if (Input.GetKey (KeyCode.A)) {
			Vector2 limit = rb.velocity;
			valX = 1;
			limit.x = -velX;
			rb.velocity = limit;
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			Vector2 limit = rb.velocity;
			valX = 0;
			limit.x = 0;
			rb.velocity = limit;

		}
		if (Input.GetKey (KeyCode.D)) {
			Vector2 limit = rb.velocity;
			valX = 1;
			limit.x = velX;
			rb.velocity = limit;

		}
		if (Input.GetKeyUp (KeyCode.D)) {
			Vector2 limit = rb.velocity;
			valX = 0;
			limit.x = 0;
			rb.velocity = limit;
		}

	}
	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.tag.Equals ("Floor")) {
			onFloor = true;
		}

		if (col.gameObject.tag.Equals ("Dano")) {
			rb.position = new Vector3 (0,-3.8f,0);
			BossController.BossLife--;
			onFloor = true;
		}

	}
}
