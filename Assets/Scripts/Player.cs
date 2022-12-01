using System.Threading.Tasks;

using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.ComponentModel;
using System;
using System.Net.Mime;
using System.Collections.Specialized;
using System.Numerics;
using System.Transactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.ComponentModel;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

// use moving forward and sides for rotation

public class Player : MonoBehaviour
{

    Rigidbody2D _rigid; // why _rigid
    public float speed = 1f;

    public GameObject Bullet;

    public GameObject Gun;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Vertical");
        float forward = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.forward, -rotation);

        // add force on the ship
        _rigid.AddForce(forward * speed * transform.right);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(Bullet, Gun.transform.position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();

            bulletScript.targetVector = transform.right;
        }


    }

    // if the component has a collider can add this function

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Application.LoadLevel(Application.loadedLevel); // Load the loaded level
        }
    }
}


// learn how to add score