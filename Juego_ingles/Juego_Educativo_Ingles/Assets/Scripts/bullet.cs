using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		float valx = Random.Range (-100, 100);
		rb.AddForce (new Vector2 (valx, -700));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.tag.Equals ("floor")){
			Destroy (gameObject);
			
		}

	
}

}
