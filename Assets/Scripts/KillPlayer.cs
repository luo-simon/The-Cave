using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public GameManager gameManager;


	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>(); //This finds the game manager object and assigns it to the variable gameManager
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //MAKE SURE THE COLLIDER HAS IS TRIGGER TICKED
    private void OnTriggerEnter2D(Collider2D collision) //basically when the player touches spike
    {
        if(collision.name == "Player")
        {
            HealthManager.HurtPlayer(HealthManager.playerHealth);
           
            //gameManager.RespawnPlayer();
        }
    }
}
