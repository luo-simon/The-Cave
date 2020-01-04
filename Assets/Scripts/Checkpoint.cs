using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //This finds the game manager object and assigns it to the variable gameManager
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) //basically when the player touches spike
    {
        if (collision.name == "Player")
        {
            gameManager.currentCheckpoint = gameObject; //goes to gamemanager script, then changes current checkpoint to THIS game object
            Debug.Log("Activated the checkpoint " + gameObject); // tells me what checkpoint it is currently
        }
    }
}
