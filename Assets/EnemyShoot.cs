using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public GameObject prefab;

    public double age;
    private double time;

    System.DateTime startTime, updateTime;
    public System.TimeSpan delta;

    // Use this for initialization
    void Start () {
        startTime = System.DateTime.Now;

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        updateTime = System.DateTime.Now;
        delta = updateTime.Subtract(startTime);
        time = delta.TotalSeconds;
        if(time>=age)
        {
            Destroy(gameObject);
        }
    }
    
}
