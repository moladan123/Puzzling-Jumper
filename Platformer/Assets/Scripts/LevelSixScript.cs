using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelSixScript : MonoBehaviour {

    Text t;
	// Use this for initialization
	void Start () {
        t = GameObject.Find("InputField").GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (t.text == "it" || t.text == "It")
        {
            transform.position = new Vector3(0, 0, 0);
        }
	}
}
