using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Hero")
        {
            Player.playerHealth++;
            Destroy(gameObject);
        }
    }
}
