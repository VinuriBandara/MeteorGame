using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject bossy;

    public static int bossLifeTime = 10;
    public static int bossHits = 0;

    public static int timeLeft = 0;
    // Start is called before the first frame update
    void Start()
    {

        bossy.SetActive(false);
    }

  
}
