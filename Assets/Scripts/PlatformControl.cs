using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour {

    public Collider platform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            platform.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider col) {
        if(col.tag == "Player") {
            platform.isTrigger = false;
        }
    }
}
