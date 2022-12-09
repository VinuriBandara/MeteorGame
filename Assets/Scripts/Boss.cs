using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject bossy;

    public static int bossLifeTime = 10;
    public static int bossHits = 0;

    public static int timeLeft = 0;
    // public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject boss = GameObject.FindGameObjectWithTag("spawn1");
        bossy.SetActive(false);
    }

    // Update is called once per frame
  
}
