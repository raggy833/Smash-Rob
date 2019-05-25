using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLedgePos : MonoBehaviour {

    public float raiusSize;
    public PlayerControl playerControl;

    private void Start() {

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, raiusSize);
    }

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "LeftLedge") {
            playerControl.HoldOnLedge();
            playerControl.HoldLeftLedge();
        } else if(col.tag == "RightLedge") {
            playerControl.HoldOnLedge();
            playerControl.HoldRightLedge();

        }
    }
}
