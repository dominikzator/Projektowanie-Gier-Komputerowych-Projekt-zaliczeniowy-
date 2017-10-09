using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Table : MonoBehaviour {
	
    public double spawnSeconds=3;
    private int timeFactor;

    public double spawnSecondsHealth = 5;
    private int timeFactorHealth;

    System.DateTime startTime, updateTime, deltaTime;
    System.TimeSpan delta;

    public GameObject spawningItem, generate;

    public GameObject spawningHealth, generateHealth;

    private Vector3 upLeft,upRight,downRight,downLeft, randomPosition, randomRotation;
    private Rigidbody rg;

    //public static bool jump = true;

    // Use this for initialization
    void Start () {
        startTime = System.DateTime.Now;
        timeFactor = 1;
        timeFactorHealth = 1;
        upLeft = new Vector3(-3, 10, 12.3f);
        upRight = new Vector3(8.60f, 10, 12.3f);
        downRight = new Vector3(8.60f, 10, -16);
        downLeft = new Vector3(-3, 10, -16);
    }
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        updateTime = System.DateTime.Now;
        delta = updateTime.Subtract(startTime);
        //print(delta.TotalSeconds);
        //print(timeFactor);
        if (delta.TotalSeconds>spawnSeconds*timeFactor)
        {
            timeFactor++;
            //print("Time Factor: " + timeFactor);
            randomPosition = new Vector3(UnityEngine.Random.Range(-3, 8.60f),10, UnityEngine.Random.Range(0, 12.30f));
            randomRotation = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
            generate = Instantiate(spawningItem, randomPosition, transform.rotation);
            generate.AddComponent<Rigidbody>();
            rg = generate.GetComponent<Rigidbody>();
            BoxCollider boxCollider = generate.GetComponent<BoxCollider>();
            boxCollider.isTrigger = false;
            generate.transform.Rotate(randomRotation);
        }
        if(delta.TotalSeconds>spawnSecondsHealth*timeFactorHealth)
        {
            timeFactorHealth++;
            randomPosition = new Vector3(UnityEngine.Random.Range(-3, 8.60f), 10, UnityEngine.Random.Range(0, 12.30f));
            randomRotation = new Vector3(UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360), UnityEngine.Random.Range(0, 360));
            generateHealth = Instantiate(spawningHealth, randomPosition, transform.rotation);
            generateHealth.AddComponent<Rigidbody>();
            //rg = generate.GetComponent<Rigidbody>();
            BoxCollider boxCollider = generate.GetComponent<BoxCollider>();
            boxCollider.isTrigger = false;
            generateHealth.transform.Rotate(randomRotation);
        }

    }
}
