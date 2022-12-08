using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MeteorPrefab;

    private float spawnNext = 0;
    public float spawnRatePerMinute = 30;
    public float spawnRateIncrement = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext) {
            spawnNext = Time.time + (60 / spawnRatePerMinute);
            // spawnRatePerMinute += spawnRateIncrement;

            //create random number for the position in x axis
            //var random = Random.Range(-40,40);
            var random = Random.Range(-Player.xBorderLimit, Player.xBorderLimit);
            // add random range with border limit
            var spawnPosition = new Vector2(random, Player.yBorderLimit);

            // Instantiate(MeteorPrefab, transform.position, Quaternion.identity);
            Instantiate(MeteorPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
