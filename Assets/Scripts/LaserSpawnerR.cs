using System.Linq.Expressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnerR : MonoBehaviour
{
    public GameObject LaserSpawn2;

    private float spawnNext = 0;
    public float spawnRatePerMinute = 100;
    public float spawnRateIncrement = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        LaserSpawn2.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext) {
            spawnNext = Time.time + (60 / spawnRatePerMinute);
            // spawnRatePerMinute += spawnRateIncrement;

            //create random number for the position in x axis
            var random = Random.Range(6,12);
            // var random = Random.Range(-Player.xBorderLimit, Player.xBorderLimit );
            // add random range with border limit
            var spawnPosition = new Vector2(random,10);

            // Instantiate(MeteorPrefab, transform.position, Quaternion.identity);
            Instantiate(LaserSpawn2, spawnPosition, Quaternion.identity);
        }


    }
}
