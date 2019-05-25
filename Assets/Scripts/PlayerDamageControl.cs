using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageControl : MonoBehaviour {

    public float damageAmount;

    private PlayerControl2 playerControl2;

    private Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        playerControl2 = GameObject.Find("Player3").GetComponent<PlayerControl2>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void DamageAmount(int damage) {
        damageAmount = damage;
    }

    private void OnTriggerEnter(Collider other) {

        if(other.tag == "knockBackObj") {
            Debug.Log("Hit box");
            playerControl2.state = PlayerControl2.States.KNOCKBACK;

            Vector3 moveDirection = transform.position - other.transform.position;
            // moveDirection.y = 0;
            Vector3 knockBack = moveDirection;
            rb.AddForce(moveDirection.normalized * 900f);

        }

        if (this.tag == "Player" && other.tag == "Player2Attack") {
            Vector3 moveDirection = transform.position = other.transform.position;
            Debug.Log(moveDirection);
            moveDirection.y = 0;
            Vector3 knockBack = moveDirection + new Vector3(0, 0, 5000f);
            rb.AddForce(moveDirection.normalized * 5000f);
            // Add damaged animation and change to !canMove state
            // anim.SetTrigger("damage");
            // canMove = false;
        }
        if (this.tag == "Player2" && other.tag == "PlayerAttack") {
            Vector3 moveDirection = rb.transform.position - other.transform.position;
            moveDirection.y = 0;
            Vector3 knockBack = moveDirection + new Vector3(0, 0, 5000f);
            rb.AddForce(moveDirection.normalized * 5000f);
        }
    }
}
