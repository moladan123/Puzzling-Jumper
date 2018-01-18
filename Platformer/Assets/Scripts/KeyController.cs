using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	public GameObject gate;

	void Awake () {
		// make sure that the gate knows that this key is bound to it
		gate.GetComponent<GateController> ().addKeyToGate ();

		Debug.Log("There is an awakening");
	}

	public void CollectKey() {
		gate.GetComponent<GateController> ().removeKeyFromGate ();
		Destroy (gameObject);
	}
	
	void onTriggerEnter2D(Collision2D col) {
		Debug.Log("There is a collision");
		// if the player gets the key
		if (col.gameObject.name == "Player"){
			
		}
	}

}
