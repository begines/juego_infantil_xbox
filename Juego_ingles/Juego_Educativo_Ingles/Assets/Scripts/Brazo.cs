using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brazo : MonoBehaviour {

	public float posy = 0.01f;

	void Start () {
		
	}

	void Update () {
		Vector3 pos = transform.position;

		if (transform.position.y < 3.5f || transform.position.y > 4.42f) {
			posy = -posy;
		}

		pos.y += posy;

		transform.position = pos;
	}
}
