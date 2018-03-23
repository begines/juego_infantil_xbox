using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float fX = 10;
	public float fY = 10;
	public float mX = 4;
	public float mY = 4;
	bool onFloor = true;
	float valX = 0;
	bool piso = true;
	//float valY = 0;

	Collider2D pla;
	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		pla = GetComponent<Collider2D> ();
		piso = true;
		
	}

	void Update () {
		
		float velY = fY;
		float velX = valX*fX;

		rb.AddForce (new Vector2 (velX, 0));

		if (rb.velocity.y > 0) {
			pla.isTrigger = true;
		}else if (rb.velocity.y < 0) {
			pla.isTrigger = false;
		} 
		if (Input.GetKey (KeyCode.Space) && onFloor) {
			/*Vector2 limit = rb.velocity;
			 float valY = 1;
			limit.y = velY;
			rb.velocity = limit;*/
			rb.AddForce (new Vector2 (0, velY));
			onFloor = false;

		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			
			/*Vector2 limit = rb.velocity;
			valY = 0;
			limit.y = 0;
			rb.velocity = limit;*/
			rb.AddForce (new Vector2 (0, 0));

		}

		if (Input.GetKey (KeyCode.A)) {
			Vector2 limit = rb.velocity;
			valX = 1;
			limit.x = -velX;
			rb.velocity = limit;
			//rb.AddForce (new Vector2 (-velX, 0));

		}
		if (Input.GetKeyUp (KeyCode.A)) {
			Vector2 limit = rb.velocity;
			valX = 0;
			limit.x = 0;
			rb.velocity = limit;
			//rb.AddForce (new Vector2 (0, 0));

		}
		if (Input.GetKey (KeyCode.D)) {
			Vector2 limit = rb.velocity;
			valX = 1;
			limit.x = velX;
			rb.velocity = limit;
			//rb.AddForce (new Vector2 (velX, 0));

		}
		if (Input.GetKeyUp (KeyCode.D)) {
			Vector2 limit = rb.velocity;
			valX = 0;
			limit.x = 0;
			rb.velocity = limit;
			//rb.AddForce (new Vector2 (0, 0));

		}
		if (transform.position.y < -7) {
			GameObject gcobj = GameObject.FindGameObjectWithTag ("GameController");
			GameControllerjump gc = gcobj.GetComponent<GameControllerjump> ();
			gc.lose ();
		}
		
	}
	void OnCollisionEnter2D(Collision2D col){
		//Debug.Log ("colision");
		if (col.gameObject.tag.Equals ("Floor")) {
			//Debug.Log ("toco");
			onFloor = true;
		}
		/*if (col.gameObject.name.Equals ("Viga") && piso) {
			GameObject flor = GameObject.Find ("Piso");
			GameController floo = flor.GetComponent<GameController> ();
			Destroy (flor.gameObject);
			piso = false;
		}*/

	}
   

    
}
