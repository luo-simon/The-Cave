using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int pointsToAdd;

    public GameObject coinParticle;

    void OnTriggerEnter2D(Collider2D other) //trigger (this object, other game object that touched this)
    {
        if (other.GetComponent<PlayerController>() == null) //if the object touching coin isn't the player, then dont 
            return;

        Debug.Log("Someone touched the coin");

        ScoreManager.AddPoints(pointsToAdd);

        Instantiate(coinParticle, transform.position, transform.rotation);

        Destroy(gameObject);
        
    }

}
