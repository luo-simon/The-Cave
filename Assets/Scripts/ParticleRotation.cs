using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour {

    //Rigidbody2D rb;

    public PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        //rb = GetComponent<Rigidbody2D>();

        if (player.transform.localScale.x < 0) //if he is facing left then the speed is negative
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
