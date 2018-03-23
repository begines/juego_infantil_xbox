using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float posx = 0.01f;
	public float fY = 10;
	bool onfloor = false;

	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		
		Vector3 pos = transform.position;
		if (onfloor) {
			if (transform.position.x < -8.3f || transform.position.x > 8.3f) {
				posx = -posx;
			}

			pos.x += posx;
			transform.position = pos;
		}

		
	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Floor")) {
			Debug.Log ("sdfgksfgg");

			if (onfloor == false) {
				StartCoroutine ("salto");
			}
			onfloor = true;
		}
		if (col.gameObject.tag.Equals ("Player")) {
			Destroy (gameObject);

		}

	}

	IEnumerator salto(){
		yield return new WaitForSeconds (5f);
		float velY = fY;
		rb.AddForce (new Vector2 (0, velY));
		StartCoroutine ("salto");
	}

}
