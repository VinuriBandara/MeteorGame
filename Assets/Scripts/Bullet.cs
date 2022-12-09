using System.Dynamic;
using System.Net;
using System.Globalization;
using System.Runtime;
using System.Buffers;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI; 
using Debug = UnityEngine.Debug;


public class Bullet : MonoBehaviour
{


    public Vector3 targetVector; 
    public int speed = 10;

    public int timeLeft = 0;
    
    private float bulletLifeTime = 1.0f;

    public static int playerLevel1 = 4;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,bulletLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject.tag == "Enemy")
       {
           Destroy(other.gameObject);
           
		   IncreaseScore();
       }


       if (other.gameObject.tag == "boss")
       {
            // other.gameObject.SetActive(false);
            ReduceLife();
            // GameObject go = GameObject.FindGameObjectWithTag("UI");
            // go.GetComponent<Text>().text = "You are done!!";
       }
   }

    public void IncreaseScore()
    {
       
        Player.SCORE = Player.SCORE + Meteor.points ;
        UpdateScoreText();
    }


    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;

    
        if (Player.SCORE == playerLevel1)
        {
            GameObject spawn = GameObject.FindGameObjectWithTag("spawn1");
            spawn.SetActive(false);
        }
    }

    public void ReduceLife()
    {
        Boss.bossHits = Boss.bossHits+1;

        Boss.timeLeft  = Boss.bossLifeTime - Boss.bossHits;
        GameObject bsscr = GameObject.FindGameObjectWithTag("bossHealth");
        bsscr.GetComponent<Text>().text = "Boss Health : "+ Boss.timeLeft;

    }



}
