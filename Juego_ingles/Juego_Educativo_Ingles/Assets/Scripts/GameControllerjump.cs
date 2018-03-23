using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerjump : MonoBehaviour {

	public GameObject meteorito;
	public GameObject vigas;
	public GameObject tuerca1;
    public GameObject tuerca2;
    public GameObject tuerca3;
    public GameObject tuerca4;
    public GameObject tuerca5;
    public static int piezas = 0;
	public static int score = 0;
    int rand;

	void Start () {
		
		StartCoroutine ("viga");
		StartCoroutine ("tuerk");
		StartCoroutine ("tiempo");
        
    }


	void Update () {
		
	}

	IEnumerator tiempo(){
		yield return new WaitForSeconds (1f);
		score++;
		GameObject txtobj = GameObject.Find ("Time");
		Text txt = txtobj.GetComponent<Text> ();
		txt.text = "TIME: " + score;
		StartCoroutine ("tiempo");
	}
	
	IEnumerator viga(){
		yield return new WaitForSeconds (2f);
		Instantiate (vigas);
		StartCoroutine ("viga");
	}
	IEnumerator tuerk(){

        yield return new WaitForSeconds(10f);
            rand = Random.Range(1, 5);

            switch (rand) {
                case 1:
                    Instantiate(tuerca1);
                    break;
                case 2:
                    Instantiate(tuerca2);
                    break;
                case 3:
                    Instantiate(tuerca3);
                    break;
                case 4:
                    Instantiate(tuerca4);
                    break;
                case 5:
                    Instantiate(tuerca5);
                    break;

            }
           
         
            StartCoroutine("tuerk");
        }

	
	public void lose(){
		GameObject obj = GameObject.Find ("loseText");
		Text txt = obj.GetComponent<Text> ();
		txt.enabled = true;
		piezas = 0;

		StartCoroutine (loseProcess());

	}

	IEnumerator loseProcess(){
		yield return new WaitForSeconds (3.0f);

		int highScore = PlayerPrefs.GetInt ("score");

		if (score > highScore) {

			PlayerPrefs.SetInt ("score", score);

		}

		score = 0;
		SceneManager.LoadScene ("Menu");
	}
}