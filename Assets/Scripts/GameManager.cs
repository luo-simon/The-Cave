using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject currentCheckpoint;
    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    public float respawnDelay;

    private CameraController camera;

    private Animator anim;

    //private float gravityScaleStore; //placeholder for the gravity scale for later

    public HealthManager healthManager;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>(); // finds the player controller in the level and assigns to player
        camera = FindObjectOfType<CameraController>();
        healthManager = FindObjectOfType<HealthManager>();
        anim = FindObjectOfType<PlayerController>().GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (anim.GetBool("Respawning") == true)
            anim.SetBool("Respawning", false);
	}

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCoroutine");

    }

    public IEnumerator RespawnPlayerCoroutine() //runs separately so it is possible to add a time delay
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        //if things start bugging out just use the following 2 lines of code because they worked before
        //player.enabled = false; //disables the player movement
        //player.GetComponent<Renderer>().enabled = false; //gets the sprite renderer of the player then makes the player sprite invisible
        player.gameObject.SetActive(false);
        camera.isFollowing = false;
        
        //dont need these anymore since camera is not child of player:
        //gravityScaleStore = player.GetComponent<Rigidbody2D>().gravityScale;
        //player.GetComponent<Rigidbody2D>().gravityScale = 0f; //changes gravity to zero so camera doesnt continue moving down if you fall onto lvl border
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //shorthand way of a vector with (0,0)

        ScoreManager.AddPoints(-pointPenaltyOnDeath);

        player.knockbackCount = 0f;

        Debug.Log("THE PLAYER HAS RESPAWNED");

        yield return new WaitForSeconds(respawnDelay); //waits for a few seconds (only works in a co routine)

        //player.GetComponent<Rigidbody2D>().gravityScale = 5f; //gravityScaleStore; //changes gravity scale back to 5 - IF YOU CHANGE GRAVITY SCALE ORIGINALLY REMEMBER TO CHANGE THIS ONE TOO 

        player.transform.position = currentCheckpoint.transform.position;
        //player.enabled = true; 
        //player.GetComponent<Renderer>().enabled = true;


        player.transform.localScale = new Vector3(1f, 1f, 1f);
        player.gameObject.SetActive(true);


        anim.SetBool("Respawning", true);

        healthManager.FullHealth();
        healthManager.isDead = false;
        camera.isFollowing = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
