using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viga : MonoBehaviour {

	float rand = 0;

	void Start () {
		rand = Random.Range(-6.8f,6.8f);
	}
	

	void Update () {
		Vector3 pos = transform.position;
		pos.y -= 0.02f;
		pos.x = rand;
		transform.position = pos;
		if(transform.position.y <= -6){
			Destroy (gameObject);
		}
	}
}
