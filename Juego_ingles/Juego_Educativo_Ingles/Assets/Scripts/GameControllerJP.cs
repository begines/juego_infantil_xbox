using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerJP : MonoBehaviour
{
    public static int score = 0;
    public static int higscore = 0;
    public static int metros = 0;
    public static int vivo = 0;
    public GameObject laser;
    public GameObject signo;
    public GameObject moneda;
    void Start()
    {

        StartCoroutine("Spawnlaser");
        StartCoroutine("Spawnmonedas");
        StartCoroutine("spawmetros");


    }


    void Update()
    {

    }



    IEnumerator Spawnlaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(laser);
        }

    }

    IEnumerator Spawnmonedas()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(moneda);
        }

    }
    IEnumerator spawmetros()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            metros++;
        }

    }
    IEnumerator Spawnsigno()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(signo);
        }

    }
    public void lose()
    {
        GameObject txtObj = GameObject.Find("Gameovertext");
        Text txt = txtObj.GetComponent<Text>();
        txt.enabled = true;


        if (metros > higscore)
        {
            PlayerPrefs.SetInt("Highscore", metros);
        }



        StartCoroutine("loserproces");
    }

    IEnumerator loserproces()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("scene2");

    }


}