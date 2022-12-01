using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//after creating the meteor, execute and disappear

public class Meteor : MonoBehaviour
{
    float maxLifeTime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime); //with a timer
    }
}
