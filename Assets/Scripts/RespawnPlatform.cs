using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlatform : MonoBehaviour {

    public float speed = 1f;
    public Transform dropPosP1;
    public Transform dropPosP2;

    Vector3 platformStopPos1 = new Vector3(-2, 11, 0);

    private bool dropP1;
    private bool dropP2;
    private float p1CounterTimer;
    private float p2CounterTimer;
    private float p1CounterTime = 2f;
    private float p2CounterTime = 2f;

    // Update is called once per frame
    private void Awake() {
        p1CounterTimer = p1CounterTime;
        p2CounterTimer = p2CounterTime;
    }

    void Update() {
        //transform.position = Vector3.Lerp(transform.position, platformStopPos1, speed * Time.deltaTime);
        //CounterTimer -= Time.deltaTime;
        dropP1 = true;
        Debug.Log(dropP1);
        if (dropP1 == true) {
            Debug.Log("p1 platform");
            transform.position = Vector3.Lerp(transform.position, dropPosP1.position, speed * Time.deltaTime);
            p1CounterTimer -= Time.deltaTime;
            if (p1CounterTimer < 0) {
                Destroy(gameObject);
                p1CounterTimer = p1CounterTime;
                dropP1 = false;
            }
        }
        if (dropP2) {
            transform.position = Vector3.Lerp(transform.position, dropPosP2.position, speed * Time.deltaTime);
            p2CounterTimer -= Time.deltaTime;
            if (p2CounterTimer < 0) {
                Destroy(gameObject);
                p2CounterTimer = p2CounterTime;
                dropP2 = false;
            }
        }
        //if (CounterTimer < 0) {
        //    Destroy(gameObject);
        //    CounterTimer = CounterTime;
        //}
    }
}
