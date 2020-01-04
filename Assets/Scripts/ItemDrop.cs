using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour {
    public GameObject itemDrop;
    public Transform dropPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        Instantiate(itemDrop, dropPoint.position, dropPoint.rotation);
    }
}
