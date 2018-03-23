using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


	[SerializeField]
	private Sprite byImage;

	public Sprite[] puzzles;

	public List<Sprite> gamePuzzles = new List<Sprite> ();

	public List<Button> btns = new List<Button> ();

	private bool firstGuess, secondGuess;
	private int countGuesses;
	private int countCorrectGuesses;
	private int gameGuesses;

	private int firstGuessIndex, secondGuessIndex;
    private string firstGuessesPuzzle, secondGuessesPuzzle;

	void Awake(){
		puzzles = Resources.LoadAll<Sprite> ("sprite");
	}

	void Start(){
		GetButtons ();
		AddListeners ();
		AddGamePuzzle ();
		Shuffle (gamePuzzles);
		gameGuesses = gamePuzzles.Count / 2;

	}
		void GetButtons(){
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Puzzle Button");

		for (int i = 0; i < objects.Length; i++) {
			btns.Add (objects [i].GetComponent<Button> ());
			btns [i].image.sprite = byImage;
		
		}
	}


	void AddGamePuzzle(){
		int looper = btns.Count;
		int index = 0;

		for (int i = 0; i < looper; i++) {
		
			if (index == looper / 2) {
				index = 0;
			}
			gamePuzzles.Add (puzzles [index]);
			index++;
		}
	
	}


	void AddListeners(){
		foreach (Button btn in btns) {
			btn.onClick.AddListener (() => PickApuzzle ());

		}



	}


	public void PickApuzzle(){
		string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;


		if (!firstGuess) {
			firstGuess = true;

			firstGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			firstGuessesPuzzle = gamePuzzles [firstGuessIndex].name;

			btns [firstGuessIndex].image.sprite = gamePuzzles [firstGuessIndex];
		
		} else if (!secondGuess) {	
			secondGuess = true;

			secondGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			secondGuessesPuzzle = gamePuzzles [secondGuessIndex].name;

			btns [secondGuessIndex].image.sprite = gamePuzzles [secondGuessIndex];
		
			/*if (firstGuessesPuzzle == secondGuessesPuzzle) {
				Debug.Log ("bien");
			} else {
				Debug.Log ("mal");
			}*/
			countGuesses++;

			StartCoroutine (CheckIfThePuzzlesMatch ());
		}

	}
	IEnumerator CheckIfThePuzzlesMatch(){
	
		yield return new WaitForSeconds (2f);

		if (firstGuessesPuzzle == secondGuessesPuzzle) {
			yield return new WaitForSeconds (1f);
			btns [firstGuessIndex].interactable = false;
			btns [secondGuessIndex].interactable = false;

			btns [firstGuessIndex].image.color = new Color (0, 0, 0, 0);
			btns [secondGuessIndex].image.color = new Color (0, 0, 0, 0);	

			CheckIfThePuzzlesMatch ();
		} else {
			yield return new WaitForSeconds (1f);

			btns [firstGuessIndex].image.sprite = byImage;
			btns [secondGuessIndex].image.sprite = byImage;
		
		}
		yield return new WaitForSeconds (1f);
	firstGuess = secondGuess = false;
		//firstGuess = false;
		//secondGuess = false;
	}

	void CheckIfTheGameIsFinished(){
		countCorrectGuesses++;

		if(countCorrectGuesses==gameGuesses){
			Debug.Log("fin");
			Debug.Log ("it took you" + countGuesses + "many gues(es) to finish the game");

		}
	
	}

	void Shuffle(List<Sprite>list){
		for (int i = 0; i < list.Count; i++) {
		
			Sprite temp = list [i];
			int randomIndex = Random.Range (0, list.Count);
			list [i] = list [randomIndex];
			list [randomIndex] = temp;
		}
	
	}
} 	
