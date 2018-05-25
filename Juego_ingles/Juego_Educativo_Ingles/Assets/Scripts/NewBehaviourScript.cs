using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	Rigidbody2D rb;
	public GameObject bala;
	float rand; 

	// Use this for initialization
	void Start () {
		rand = Random.Range (1,5 );	
		rb = GetComponent<Rigidbody2D> ();
		rb.AddForce(new Vector2 (0, 200));
		StartCoroutine ("SpawnBala");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y > 3.4) {
			Vector2 velocity = rb.velocity;
			velocity.y = -5;
			rb.velocity = velocity;
		}
		if (transform.position.y < -3.48) {
			Vector2 velocity = rb.velocity;
			velocity.y = 5;
			rb.velocity = velocity;
		}

	}

	IEnumerator SpawnBala(){
		while (true) {
			//forma de hacerlo con for
			yield return new WaitForSeconds (rand);
			Instantiate (bala,transform.position,Quaternion.identity);
			Destroy (gameObject);
		}
	}


}
