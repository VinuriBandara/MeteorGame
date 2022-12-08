using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Vector3 targetVector; 
    public int speed = 10;
    
    private float laserLifeTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,laserLifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * -speed * Time.deltaTime);
    }
}
