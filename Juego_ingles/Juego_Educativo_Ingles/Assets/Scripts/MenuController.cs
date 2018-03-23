using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

	void Start () {
		int highScore = PlayerPrefs.GetInt ("score");
		int vic = PlayerPrefs.GetInt ("winScore");

		GameObject txtobj = GameObject.Find ("hScore");
		Text txt = txtobj.GetComponent<Text> ();
		txt.text = "Highest Time Alive: " + highScore;

		GameObject txtobj2 = GameObject.Find ("wScore");
		Text txt2 = txtobj2.GetComponent<Text> ();
		txt2.text = "Wins: " + vic;
	}

	void Update () {
		
	}
	public void playClick(){
		SceneManager.LoadScene ("Game");
	}
	public void exit(){
		Application.Quit ();
	}
}
