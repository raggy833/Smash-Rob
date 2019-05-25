using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackControl : MonoBehaviour {

    public GameObject p1_rightArm;
    public GameObject p1_leftArm;
    public GameObject p2_rightArm;
    public GameObject p2_leftArm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Punch1() {
        if (this.tag == "Player") {
            p1_rightArm.transform.gameObject.tag = "PlayerAttack";
        }
        if (this.tag == "Player2") {
            p2_rightArm.transform.gameObject.tag = "Player2Attack";
        }
    }

    public void Punch2() {
        if (this.tag == "Player") {
            p1_leftArm.transform.gameObject.tag = "PlayerAttack";
        }
        if (this.tag == "Player2") {
            p2_leftArm.transform.gameObject.tag = "Player2Attack";
        }
    }

    public void Punch3() {
        if (this.tag == "Player") {
            p1_rightArm.transform.gameObject.tag = "PlayerAttack";
            p1_leftArm.transform.gameObject.tag = "PlayerAttack";
        }
        if (this.tag == "Player2") {
            p2_rightArm.transform.gameObject.tag = "Player2Attack";
            p2_leftArm.transform.gameObject.tag = "PlayerAttack";
        }
    }

    public void IdleTag() {
        if (this.tag == "Player") {
            p1_rightArm.transform.gameObject.tag = "Player";
            p1_leftArm.transform.gameObject.tag = "Player";
        }
        if (this.tag == "Player2") {
            p2_rightArm.transform.gameObject.tag = "Player2";
            p2_leftArm.transform.gameObject.tag = "Player2";
        }
    }
}
