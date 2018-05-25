using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balita : MonoBehaviour {

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.AddForce (new Vector2 (-300, 0));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.tag.Equals ("Player")){
			Destroy (col.gameObject);
			GameObject gcObj = GameObject.FindGameObjectWithTag ("GameController");
			GameControllerJP gc = gcObj.GetComponent<GameControllerJP> ();
			gc.lose ();
		}


}
}
