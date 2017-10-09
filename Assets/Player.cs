using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
    
    public static int playerHealth;
    private float speed=20;
    public float moc_skoku = 20;
	public Renderer rend;
    private float h;
    private float v;
    private float z=0;
    public static int punkty=0;
    public static int highestScore = 0;
    Vector3 f;
    Vector3 helpVector;

    // Use this for initialization
    void Start ()
    {
        playerHealth = 25;
        rend = GetComponent<Renderer>();
		//speed=5;
        h = 0;
        v = 0;
        helpVector = new Vector3(0, 0, 2);
        //punkty = 0;             
    }

	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(gameObject.transform.localPosition.y<=-50)
        {
            Destroy(gameObject);
        }

        if(playerHealth<=0)
        {
            if(Enemy.kills>highestScore)
            {
                highestScore = Enemy.kills;
            }
            Debug.Log("GAME FINISHED");
            Debug.Log("Your Score: " + Enemy.kills);
            Debug.Log("Highest Score: " + highestScore);
            Enemy.kills = 0;
            Enemy.EnemiesNumber = 0;
            Player.playerHealth = 10;
            Application.LoadLevel(0);
        }

        //Dla Androidów
        //float h = Input.acceleration.x;
        //float v = Input.acceleration.y;




        bool l2 = Input.GetButton("Fire1");
        bool r2 = Input.GetButtonDown("Fire2");

        //if (spacja && gameObject.name == "Hero")
        //{
        //    Instantiate(gameObject, transform.position + helpVector, transform.rotation);
        //}



        Rigidbody rg = gameObject.GetComponent<Rigidbody>();

        if (gameObject.name == "Hero")
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }

        if (l2 && FloorScript.jump)
        {
            rg.AddForce(new Vector3(0, moc_skoku, 0));
            FloorScript.jump = false;
        }
        if (r2 )
        {
           
            
        }


        f = new Vector3(h, z, v);
	
        rg.AddForce(f * speed);        
    }

    void onTriggerEnter(Collider collider)
    {

    }

    void OnCollisionEnter(Collision colli)
    {
        if(colli.gameObject.name == "EnemyShoot" || colli.gameObject.name == "EnemyShoot(Clone)")
        {
            playerHealth--;
            Debug.Log("Player Health: " + playerHealth);
        }
    }
}
