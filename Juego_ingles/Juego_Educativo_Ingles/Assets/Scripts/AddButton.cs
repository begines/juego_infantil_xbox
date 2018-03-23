using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour {

	[SerializeField]
	private Transform puzzleField;
	[SerializeField]
	private GameObject bnt;	
	void Awake(){

		for (int i = 0; i < 10; i++) {
			GameObject button = Instantiate (bnt);
			button.name = "" + i;
			button.transform.SetParent (puzzleField, false);

		}
	}
}
	