using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nav : MonoBehaviour {

    public void playgame()
    {
        SceneManager.LoadScene("Game");
        
    }

    public void Sentings()
    {
        SceneManager.LoadScene("Sentings");

    }

    public void Quit()
    {
       Application.Quit();

    }
}
