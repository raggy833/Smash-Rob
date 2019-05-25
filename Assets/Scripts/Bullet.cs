using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float fireTime = .2f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Fire", fireTime, fireTime);
	}

    void Fire() {
        GameObject obj = ObjectPoolerScript.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);

    }
}

