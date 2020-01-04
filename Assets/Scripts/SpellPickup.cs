using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPickup : MonoBehaviour {

    private PlayerController playerController;

    public GameObject spellPickupParticles;

    //public AudioClip swordPickupSound;

    // Use this for initialization
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            //AudioSource.PlayClipAtPoint(swordPickupSound, transform.position);
            playerController.haveSpell = true;
            Instantiate(spellPickupParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
