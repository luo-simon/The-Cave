using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour {

    private LivesManager livesManager;
    public AudioClip heartSound;

	// Use this for initialization
	void Start () {
        livesManager = FindObjectOfType<LivesManager>();    
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            AudioSource.PlayClipAtPoint(heartSound, transform.position);
            livesManager.GiveLife();
            Destroy(gameObject);
        }
    }
}
