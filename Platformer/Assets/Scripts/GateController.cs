using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

	public static int keysNeeded = 0;

	void Awake () {
		
	}

	// each key has to add itself to the gate
	public void addKeyToGate() {
		keysNeeded++;
	}

	public void removeKeyFromGate() {
		keysNeeded--;
		if (keysNeeded == 0) {
			unlockGate ();
		}
	}

	// called when all keys are unlocked
	void unlockGate() {

	}

	public bool isOpen() {
		return keysNeeded == 0;
	}
}
