using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missile : MonoBehaviour
{
    public Vector3 targetVector; 
    public int speed = 30;
    
    private float bulletLifeTime = 3.0f;

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

        Player.SCORE = Player.SCORE + 2 ;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;

    }


}
