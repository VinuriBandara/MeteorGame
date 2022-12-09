using System;
using UnityEngine;

//after creating the meteor, execute and disappear

public class Meteor : MonoBehaviour
{
    float maxLifeTime = 6.0f;

    public static int points = 1;

    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime); //with a timer
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -speed * 100, 0));

    }
}
