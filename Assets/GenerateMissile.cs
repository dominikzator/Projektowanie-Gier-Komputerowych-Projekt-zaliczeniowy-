using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMissile : MonoBehaviour {

    public GameObject prefabs,generate;
    private Vector3 gap,force;
    private Renderer rend;
    private int red, green, blue;
    Missile missileScript;

    AudioSource audio;
    public AudioClip gunSound;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
       // gunSound = gunShoot.GetComponent<AudioClip>();
        missileScript = prefabs.GetComponent<Missile>();
        gap = new Vector3(0, 0, 1);
        force = new Vector3(0, 0, 1000);
	}
	
	// Update is called once per frame
	void Update () {
        bool stream = Input.GetButton("Stream");
        if ((stream || Input.GetKeyDown(KeyCode.Joystick1Button7)) && prefabs.name == "Missile")
        {
            audio.PlayOneShot(gunSound);
            generate = Instantiate(prefabs, transform.position + gap, transform.rotation);
            Rigidbody rg = generate.GetComponent<Rigidbody>();
            rend = generate.GetComponent<Renderer>();
            if(missileScript.RandomColors)
            {
                red = UnityEngine.Random.Range(0, 255);
                green = UnityEngine.Random.Range(0, 255);
                blue = UnityEngine.Random.Range(0, 255);
                rend.material.color = new Color32((byte)red, (byte)green, (byte)blue, 1);
            }
            
            rg.AddForce(force);
            
        }
    }
}
