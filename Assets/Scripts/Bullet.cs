using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI; 


public class Bullet : MonoBehaviour
{


    public Vector3 targetVector; 
    public int speed = 15;
    
    private float bulletLifeTime = 2.0f;

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

    
        if (Player.SCORE == 1)
        {
            GameObject spawn = GameObject.FindGameObjectWithTag("spawn1");
            spawn.SetActive(false);
        }

    }
}
