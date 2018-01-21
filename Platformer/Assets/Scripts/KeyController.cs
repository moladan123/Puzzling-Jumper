using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	public GameObject gate;

	void Start () {
		// make sure that the gate knows that this key is bound to it
		GateController.AddKeyToGate ();
	}

	public void CollectKey() {
		GateController.RemoveKeyFromGate ();
		Destroy (gameObject);
	}

}
