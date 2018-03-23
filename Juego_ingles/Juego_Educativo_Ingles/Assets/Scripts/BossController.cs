using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {

	public GameObject meteorito;
	public GameObject cubo;
	public static int BossLife = 3;
	public static int winScore = 0;

	void Start () {
		StartCoroutine ("meteor");
		StartCoroutine ("aCube");
		StartCoroutine ("tiempo");
	}


	void Update () {
		if (BossLife <= 0) {
			win ();
		}
	}

	IEnumerator tiempo(){
		yield return new WaitForSeconds (1f);
		GameControllerjump.score++;
		GameObject txtobj = GameObject.Find ("Time");
		Text txt = txtobj.GetComponent<Text> ();
		txt.text = "TIME: " + GameControllerjump.score;
		StartCoroutine ("tiempo");
	}


	IEnumerator meteor(){
		yield return new WaitForSeconds (1f);
		Instantiate (meteorito);
		StartCoroutine ("meteor");
	}
	IEnumerator aCube(){
		yield return new WaitForSeconds (10f);
		Instantiate (cubo);
		StartCoroutine ("aCube");
	}
	public void lose(){
		GameObject obj = GameObject.Find ("loseText");
		Text txt = obj.GetComponent<Text> ();
		txt.enabled = true;
		GameControllerjump.piezas = 0;

		StartCoroutine (loseProcess());

	}

	public void win(){
		GameObject obj = GameObject.Find ("winText");
		Text txt = obj.GetComponent<Text> ();
		txt.enabled = true;
		GameControllerjump.piezas = 0;

		StartCoroutine (winProcess());

	}

	IEnumerator loseProcess(){
		yield return new WaitForSeconds (3.0f);

		int highScore = PlayerPrefs.GetInt ("score");

		if (GameControllerjump.score < highScore) {

			PlayerPrefs.SetInt ("score", GameControllerjump.score);

		}
		BossController.BossLife = 3;
		GameControllerjump.score = 0;
		SceneManager.LoadScene ("Menu");
	}
	IEnumerator winProcess(){
		yield return new WaitForSeconds (3.0f);

		winScore++;

		int highScore = PlayerPrefs.GetInt ("winScore");
	
		PlayerPrefs.SetInt ("winScore", winScore + highScore);

		BossController.BossLife = 3;
		BossController.winScore = 0;
		SceneManager.LoadScene ("Menu");
	}
}
