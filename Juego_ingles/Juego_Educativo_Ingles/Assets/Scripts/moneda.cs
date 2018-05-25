using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moneda : MonoBehaviour {
	float rand; 

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rand = Random.Range (-3, 4);
		rb.AddForce (new Vector2 (-200, 0));
	}

	// Update is called once per frame
	void Update () {
		
		rb = GetComponent<Rigidbody2D> ();
		Vector3 pos = transform.position;
		pos.x = pos.x - 0.1f;
		pos.y = rand;
		transform.position = pos;
	}
	void OnTriggerEnter2D(Collider2D col){

		if (col.tag.Equals ("Player")) {
			GameControllerJP.score++;
			GameObject TEXTO = GameObject.Find ("Highscore");
			Text txt = TEXTO.GetComponent<Text>();
			Destroy (gameObject);
			txt.text = "" + GameControllerJP.score;
            if(GameControllerJP.score > 10)
            {
                GameControllerJP.score = 0;
            }
		}


	}

}