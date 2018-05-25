using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public int select;

    public void playgame()
    {
        int select = PlayerPrefs.GetInt("select");
       
            switch (select)
            {
                case 1:
                    SceneManager.LoadScene("Memorama");
                    break;
                case 2:
                    SceneManager.LoadScene("Game");
                    break;
            }
          

    }

    public void Sentings()
    {
        SceneManager.LoadScene("Sentings");

    }

    public void Quit()
    {
        SceneManager.LoadScene("Quit");

    }
    public void Bakcs()
    {
        SceneManager.LoadScene("interfaz");

    }
    public void Minijuegos()
    {
        SceneManager.LoadScene("Minijuegos");

    }
    public void elecion()
    {
        
        PlayerPrefs.SetInt("select", 1);
        SceneManager.LoadScene("Play");
    }

    public void elecion2()
    {

        PlayerPrefs.SetInt("select", 2);
        SceneManager.LoadScene("Play");
    }

    public void elecion3()
    {

        PlayerPrefs.SetInt("select", 3);
        SceneManager.LoadScene("Play");
    }
    public void Sal()
    {
        Application.Quit();
        Debug.Log("Salir");

    }
    //hacerlo con un switch
}
