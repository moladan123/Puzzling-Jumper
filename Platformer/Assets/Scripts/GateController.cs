using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

	public static int keysNeeded = 0;
    private static Vector3 scale;

    private void Start()
    {
        // save the scale of the gate
        scale = gameObject.transform.localScale;
        // make gate invisible if there is 
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    // each key has to add itself to the gate
    public static void AddKeyToGate() {
		keysNeeded++;
	}

	public static void RemoveKeyFromGate() {
		keysNeeded--;
		if (keysNeeded <= 0) {
            keysNeeded = 0;
            // make gate visible
            GameObject gate = GameObject.Find("Gate");
            gate.transform.localScale = scale;
        }
	}

	public static bool IsOpen() {
		return keysNeeded == 0;
	}
}
