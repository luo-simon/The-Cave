using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour {

    private PlayerController playerController;
    public AudioClip swordPickupSound;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            //AudioSource.PlayClipAtPoint(swordPickupSound, transform.position);
            playerController.haveSword = true;
            Destroy(gameObject);
        }
    }

}
