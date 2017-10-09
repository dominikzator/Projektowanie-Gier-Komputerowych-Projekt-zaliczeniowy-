using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public bool RandomColors;
    public static int shotsNumber=0;



    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Hero");
        shotsNumber++;
       // print("Shots fired: " + shotsNumber);
        //Player script = prefab.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (gameObject.transform.localPosition.y >= 30)
        {
            Destroy(gameObject);
        }


    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnCollisionEnter(Collision collid)
    {
        //print("Hit");
        if (collid.gameObject.name == "Enemy")
        {
            //collid.gameObject.SetActive(false);
            //prefab.transform.localScale *= 1.20f;
            Player.punkty++;
            //script.punkty++;
            Debug.Log("Ilosc trafien: " + Player.punkty);
            //gameObject.transform.localScale *= 1.1f;
            //rend.material.color = new Color(0,0,1);
            //punkty++;
            //Debug.Log(punkty);			
        }
    }
}
