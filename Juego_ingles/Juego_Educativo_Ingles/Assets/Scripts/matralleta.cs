using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matralleta : MonoBehaviour {
	public GameObject bullet;
	bool shott = false;
	// Use this for initialization
	void Start () {
		StartCoroutine ("shootbullet");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			//Instantiate (bullet, transform.position, Quaternion.identity);
			shott=true;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			//Instantiate (bullet, transform.position, Quaternion.identity);
			shott=false;
		}

	}
	IEnumerator shootbullet(){
		while (true) {
			yield return new WaitForSeconds (0.03f);
			if (shott) {
				Instantiate (bullet, transform.position, Quaternion.identity);
			}
		}

	}
}
