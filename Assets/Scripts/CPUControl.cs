using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUControl : MonoBehaviour {

    public float timeCounterDown = 0.3f;

    private int actionNum;
    private bool isAlive;
    private bool canMove;
    private float actionTime = 3f;
    private float actionTimer;
    private float timeCounter;
    private bool actionLag = false;
    private bool attackingState = false;
    private bool standingState = false;
    private bool movingState = false;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
        isAlive = true;
        canMove = true;
        actionTimer = actionTime;
	}
	
	void Update () {
		if(isAlive && canMove) {
            actionTimer -= Time.deltaTime;

        }
        if(actionTimer < 0) {
            ChooseAction();
        }
	}

    public void ChooseAction() {
        actionNum = Random.Range(1, 4);
        Debug.Log(actionNum);
        actionTimer = actionTime;
        if(actionNum == 1) {
            Action1();
        } else if(actionNum == 2) {
            Action2();
        } else if(actionNum == 3) {
            Action3();
        }
    }

    public void Action1() {

    }
    public void Action2() {

    }
    public void Action3() {

    }
}

