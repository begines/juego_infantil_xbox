using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tuerca4 : MonoBehaviour
{

    float rand = 0;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rand = Random.Range(-6.8f, 6.8f);
      
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= 0.04f;
        pos.x = rand;
        transform.position = pos;
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag.Equals("Player"))
        {
            GameControllerjump.piezas++;
            GameObject txtobj = GameObject.Find("TrK");
            Text txt = txtobj.GetComponent<Text>();
            txt.text = "TrK: " + GameControllerjump.piezas;
            StartCoroutine("texto");
            

        }

    }
    IEnumerator texto()
    {
        yield return new WaitForSeconds(1f);
        GameObject obj = GameObject.Find("Orange");
        Text txte = obj.GetComponent<Text>();
        txte.enabled = true;

        StartCoroutine("texto2");
    }
    IEnumerator texto2()
    {
        yield return new WaitForSeconds(1f);
        GameObject obj = GameObject.Find("Orange");
        Text txte = obj.GetComponent<Text>();
        txte.enabled = false;
    }

}
