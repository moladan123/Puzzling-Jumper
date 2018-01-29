using System.Collections;
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
	[SerializeField] public int numAirJumps = 1;
	[SerializeField] public float jumpStrength = 100f;

	public Text keyCounterText;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		jumpCheck = GetComponentInChildren<CircleCollider2D> ();
		UpdateUI ();
        Debug.Log("It begins");
    }
	
	// Update is called once per frame
	void FixedUpdate () {

		// moving right
		float moveRight = Input.GetAxis ("Horizontal");
		if (Mathf.Abs (moveRight) > 0.01)
			rb.velocity = new Vector2 (moveRight * moveSpeed, rb.velocity.y);

		

		// check if grounded
		if (jumpCheck.IsTouchingLayers()){
			jumpsLeft = numAirJumps;
		} 
	}

    private void Update()
    {
        // jumping
        bool jump = Input.GetKeyDown("up");
        bool jumpContinue = Input.GetKey("up");
        if (jump && jumpsLeft > 0) // Oh god why does this work?
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            jumpsLeft--;
        }
        if (jumpContinue && rb.velocity.y > 0.0f) { rb.gravityScale = 0.8f; }
        else { rb.gravityScale = 2; }

    }

    void OnTriggerEnter2D (Collider2D c) {
        
		if (c.gameObject.tag == "Key"){
			c.gameObject.GetComponent<KeyController> ().CollectKey();
			UpdateUI ();
		} else if (c.gameObject.name == "Gate")
        {
            
            if (GateController.IsOpen())
            {
                LoadNextLevel();
            }
        }
	}

	void UpdateUI() {
		keyCounterText.text = "Keys needed: " + GateController.keysNeeded;
	}

    void LoadNextLevel()
    {
        int i = Application.loadedLevel;
        if (Application.levelCount > i)
        {
            Application.LoadLevel(i + 1);
            Application.UnloadLevel(i);
        }
        else
        {
            Application.LoadLevel(1);
        }
        
    }

}