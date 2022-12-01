using System.Threading;
// using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Vector3 = UnityEngine.Vector3;

public class Bullet : MonoBehaviour
{

    public Vector3 targetVector; 
    public int speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        // collision variable - contains information about the collision

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}


// OnTriggerEnter implement