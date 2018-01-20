using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

	public static int keysNeeded = 0;

	// each key has to add itself to the gate
	public static void AddKeyToGate() {
		keysNeeded++;
	}

	public static void RemoveKeyFromGate() {
		keysNeeded--;
		if (keysNeeded < 0) {
            keysNeeded = 0;
		}
	}

	public static bool IsOpen() {
		return keysNeeded == 0;
	}
}
