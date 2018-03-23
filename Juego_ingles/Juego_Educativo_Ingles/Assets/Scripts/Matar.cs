using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag.Equals ("Player")) {
			Destroy (col.gameObject);
			GameObject gcobj = GameObject.FindGameObjectWithTag ("GameController");
			BossController gc = gcobj.GetComponent<BossController> ();
			gc.lose ();
			
		}



	}
}
