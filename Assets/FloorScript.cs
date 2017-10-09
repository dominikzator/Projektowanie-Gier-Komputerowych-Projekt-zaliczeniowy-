using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {

    public static bool jump = true;

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
            Debug.Log("Collision FLOOR with PLAYER");
            FloorScript.jump = true;
        }
    }
}
