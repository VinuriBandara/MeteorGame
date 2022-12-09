using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missile : MonoBehaviour
{
    public Vector3 targetVector; 
    public int speed = 30;

    public int timeLeft = 0;
    
    private float bulletLifeTime = 3.0f;

    public static int playerLevel1 = 5;

    public static int maxMissiles = 10;
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
            ReduceLife();
            IncreaseScore();
       }
   }

    public void IncreaseScore()
    {

        Player.SCORE = Player.SCORE + 2 ;
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
        Boss.bossHits = Boss.bossHits+2;

        Boss.timeLeft  = Boss.bossLifeTime - Boss.bossHits;
        GameObject bsscr = GameObject.FindGameObjectWithTag("bossHealth");
        bsscr.GetComponent<Text>().text = "Boss Health : "+ Boss.timeLeft;

    }


}
