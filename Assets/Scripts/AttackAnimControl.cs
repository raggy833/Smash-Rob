using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimControl : MonoBehaviour {

    public PlayerControl playerControl;

    private void Start(){
        playerControl = GetComponentInParent<PlayerControl>();
    }

    public void p_Stop(){
        playerControl.StopMovement();
    }
    public void p_Idle(){
        playerControl.BackToIdle();
    }
}
