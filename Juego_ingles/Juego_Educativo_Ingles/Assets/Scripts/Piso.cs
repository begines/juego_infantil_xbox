using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("destruir");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator destruir(){
		yield return new WaitForSeconds (7.5f);
		Destroy(gameObject);
	}
}
