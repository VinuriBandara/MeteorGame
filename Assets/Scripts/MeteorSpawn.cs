using System.Linq.Expressions;
using System.Security.Cryptography;
using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
// using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;

public class MeteorSpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject MeteorPrefab;

    private float spawnNext = 0;
    public float spawnRatePerMinute = 60;
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

            var random = Random.Range(-40,40);
            var spawnPosition = new Vector2(random, 50);

            // Instantiate(MeteorPrefab, transform.position, Quaternion.identity);
            Instantiate(MeteorPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
