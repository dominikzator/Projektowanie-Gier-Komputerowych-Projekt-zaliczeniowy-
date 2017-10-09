using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    private int life = 3;
    public Renderer render;
    public static int EnemiesNumber = 0;
    public static double spawnSeconds = 2;
    public static int kills = 0;

    System.DateTime startTime, updateTime, deltaTime;
    public System.TimeSpan delta;

    public GameObject spawningItem, generate;

    private int timeFactor;

    private Vector3 gap, randomRotation;

    private Rigidbody rg;


    // Use this for initialization
    void Start () {
        startTime = System.DateTime.Now;
        render = gameObject.GetComponent<Renderer>();
        EnemiesNumber++;
        //print("Enemies number: " + EnemiesNumber);
        timeFactor = 1;
        gap = new Vector3(0, 0, -1);
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 v = new Vector3(1, 1, 1);
        //transform.Rotate(v * Time.deltaTime);
	}

    void shoot()
    {
        generate = Instantiate(spawningItem, transform.position + gap, transform.rotation);
        Transform trans = generate.GetComponent<Transform>();
        trans.localEulerAngles = randomRotation;
        randomRotation = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
        generate.AddComponent<Rigidbody>();
        rg = generate.GetComponent<Rigidbody>();
        //BoxCollider boxCollider = generate.GetComponent<BoxCollider>();
        //boxCollider.isTrigger = false;
        rg.AddForce(new Vector3(0,0,-1000));
        
    }

    void FixedUpdate()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            kills++;
            EnemiesNumber--;
            //print("Enemies number: " + EnemiesNumber);
        }

        updateTime = System.DateTime.Now;
        delta = updateTime.Subtract(startTime);
        //print(delta.TotalSeconds);
        //print(timeFactor);
        if (delta.TotalSeconds > spawnSeconds * timeFactor)
        {
            timeFactor++;
            generate = Instantiate(spawningItem, transform.position + gap, transform.rotation);
            Transform trans = generate.GetComponent<Transform>();
            trans.localEulerAngles = randomRotation;
            randomRotation = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
            generate.AddComponent<Rigidbody>();
            rg = generate.GetComponent<Rigidbody>();
            //BoxCollider boxCollider = generate.GetComponent<BoxCollider>();
            //boxCollider.isTrigger = false;
            rg.AddForce(new Vector3(0, UnityEngine.Random.Range(0, 500), -1000));
        }

        //if (delta.TotalSeconds >= 5)
       // {
        //    Destroy(generate);
        //}

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Missile" || col.gameObject.name == "Missile(Clone)")
        {
            life--;
            if(life==2)
            {
                render.material.color = Color.yellow;
            }
            if (life == 1)
            {
                render.material.color = Color.red;
            }

        }
    }

    
}
