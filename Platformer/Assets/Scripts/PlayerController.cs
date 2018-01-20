﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public int currentlevel = 1;

	[SerializeField] public float moveSpeed = 10f;

	Rigidbody2D rb;
	CircleCollider2D jumpCheck;

	int jumpsLeft = 0;
	[SerializeField] public int maxJumps = 2;
	[SerializeField] public float jumpStrength = 100f;

	public Text keyCounterText;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpCheck = GetComponentInChildren<CircleCollider2D> ();
		updateUI ();
        Debug.Log("It begins");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		// moving right
		float moveRight = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (moveRight) > 0.01)
			rb.velocity = new Vector2 (moveRight * moveSpeed, rb.velocity.y);

		// jumping
		bool jump = (Input.GetAxisRaw("Vertical") == 1);
		if (jump && jumpsLeft > 0) {
			rb.velocity = new Vector2 (rb.velocity.x, jumpStrength);		
			jumpsLeft--;
		}

		// check if grounded
		if (jumpCheck.IsTouchingLayers()){
			jumpsLeft = maxJumps;
		} 
	}

	void OnTriggerEnter2D (Collider2D c) {
        
		if (c.gameObject.tag == "Key"){
			c.gameObject.GetComponent<KeyController> ().CollectKey();
			updateUI ();
		} else if (c.gameObject.name == "Gate")
        {
            
            if (GateController.IsOpen())
            {
                Debug.Log("got here");
                currentlevel++;
                Debug.Log("Level " + currentlevel);
                SceneManager.LoadScene("Level " + currentlevel, LoadSceneMode.Single);
            }
        }
	}

	void updateUI() {
		keyCounterText.text = "Keys needed: " + GateController.keysNeeded;
	}

}