using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

    public int damageToGive;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //MAKE SURE THE COLLIDER HAS IS TRIGGER TICKED
    private void OnTriggerEnter2D(Collider2D other) //basically when the player touches spike
    {
        if (other.name == "Player")
        {
            HealthManager.HurtPlayer(damageToGive);
            Debug.Log("The player touched the enemy");
            other.GetComponent<AudioSource>().Play();

            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackTime;

            if (other.transform.position.x < transform.position.x) // if the x value of player is less than x value of enemy then its on the left
            {
                player.knockFromRight = true;
            }
            else
            {
                player.knockFromRight = false;
            }
        }
    }
}
