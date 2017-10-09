using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

    public Text healthText;
    public Text enemiesLeftText;
    public Text enemiesKilledText;
    public RawImage healthBar;
    public RectTransform healthtransform;

    int changeRed, changeGreen;

    string helpString;
    // Use this for initialization
    void Start () {
        healthBar.GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
        
        helpString = Player.playerHealth.ToString();
        healthText.text = "Player Health: " + Player.playerHealth;
        
        helpString = Enemy.kills.ToString();
        enemiesKilledText.text = "Enemies killed: " + helpString;

        helpString = Enemy.EnemiesNumber.ToString();
        enemiesLeftText.text = "Enemies left: " + helpString;
        //int changeWidth = 0;
        changeRed = (25 - Player.playerHealth) * 10 + 5;
        changeGreen = Player.playerHealth * 10 + 5;
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(20*Player.playerHealth,10);
        healthBar.GetComponent<RawImage>().color = new Color32((byte)changeRed, (byte)changeGreen, 0, 255);

    }
}
