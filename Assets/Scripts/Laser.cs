using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float maxLifeTime = 10.0f;

    public static int points = 1;

    private float speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime); //with a timer
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -speed * 120, 0));

    }
}
