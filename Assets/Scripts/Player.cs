using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using System.Linq.Expressions;
using System.ComponentModel.Design.Serialization;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    Rigidbody2D _rigid; 
    
    Vector2 forwardDirection;
    
    // use moving forward and sides for rotation
    public float forwardspeed = 2.0f;

	public float rotationspeed = 60.0f;
	
	public static int SCORE = 0;

    public static int maxMissiles = 10;

    public static int playerLevel1 = 4;
    
    public static int NoMissiles = 0;

    public static int moreAvailable = 10;

    public static float xBorderLimit, yBorderLimit;

    public GameObject Bullet;

	public GameObject Missile;

    public GameObject Gun;

    public GameObject bossy;

    public GameObject LaserSpawn;

    public GameObject LaserSpawn2;

    public GameObject LaserSpawn3;



    
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        
        yBorderLimit = Camera.main.orthographicSize+1;
        xBorderLimit = (Camera.main.orthographicSize+1) * Screen.width / Screen.height;

    }

    private void FixedUpdate()
    {
        float rotation = Input.GetAxis("Vertical") * rotationspeed * Time.deltaTime;

        float forward = Input.GetAxis("Horizontal");
        
        transform.Rotate(Vector3.forward, rotation);
        
        _rigid.AddForce(forward * forwardspeed * transform.right);

    }
    // Update is called once per frame
    void Update()
    {
		var newPos = transform.position;
        if (newPos.x > xBorderLimit)
            newPos.x = -xBorderLimit+1;
        else if (newPos.x < -xBorderLimit)
            newPos.x = xBorderLimit-1;
        else if (newPos.y > yBorderLimit)
            newPos.y = -yBorderLimit+1;
        else if (newPos.y < -yBorderLimit)
            newPos.y = yBorderLimit-1;
        transform.position = newPos;
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(Bullet, Gun.transform.position, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();

            bulletScript.targetVector = transform.right;
        }

		if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            if (NoMissiles <= maxMissiles)
            {

                GameObject warning = GameObject.FindGameObjectWithTag("warn");
                warning.GetComponent<Text>().text = "Number of Missiles Available : " + moreAvailable;


                GameObject missile = Instantiate(Missile, Gun.transform.position, Quaternion.identity);

                Missile missileScript = missile.GetComponent<Missile>();

                missileScript.targetVector = transform.right;

                NoMissiles++;

                moreAvailable = maxMissiles - NoMissiles;
                
            }
            else
            {
                GameObject warning = GameObject.FindGameObjectWithTag("warn");
                warning.GetComponent<Text>().text = "WARNING YOU HAVE RUN OUT OF MISSILES!!!";
            }
        }


        if (Player.SCORE ==  playerLevel1)
        {
            Player.SCORE = Player.SCORE + 0;
            bossy.SetActive(true);

            LaserSpawn.SetActive(true);
            LaserSpawn2.SetActive(true);
            LaserSpawn3.SetActive(true);

            
        }


        if (Boss.bossHits == Boss.bossLifeTime)
        {
            bossy.SetActive(false);
            LaserSpawn.SetActive(false);
            LaserSpawn2.SetActive(false);
            LaserSpawn3.SetActive(false);
        }
 
    }

    // if the component has a collider can add this function
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Application.LoadLevel(Application.loadedLevel); // Load the loaded level
			SCORE = 0 ;
        }
    }

}
