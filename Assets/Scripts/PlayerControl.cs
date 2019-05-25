using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    // Must add new script or use 
    // master script with child scripts

    public float oriMoveSpeed = 10;
    public float airMoveSpeed = 6;
    public float jumpPower = 10;
    public Transform RightArm;
    public Transform LeftArm;
    public Transform leftHoldPos;
    public Transform rightHoldPos;
    public Vector3 direction = -Vector3.up;
    public RaycastHit hit;
    public float maxDistance = 3;
    public LayerMask layerMask;
    public Transform spawnPos1;
    public Transform spawnPos2;
    public bool canMove;
    public bool isAlive;
    public bool invincible;

    private float moveSpeed;
    private float comboTimer;
    private float ledgeTime = 0.15f;
    private float oriLedgeTime = 0.15f;
    private float jumpTimeCounter;
    private float jumpTimer;
    private bool facingRight = true;
    private bool isGrounded = false;
    private bool isJumping = false;
    private bool onLedge = false;
    private bool isAttacking;
    private Rigidbody rb;
    private Animator anim;
   

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        canMove = true;
        isAlive = true;
        isAttacking = false;
        invincible = false;
        moveSpeed = oriMoveSpeed;
    }

    private void Update() {
        StayInMap();
        if(comboTimer > 0){
            comboTimer -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {

        // Lag holding on ledge
        if (onLedge) {
            ledgeTime -= Time.deltaTime;
            rb.velocity = new Vector3(0, 0, 0);
        }
        if(ledgeTime < 0) {
            onLedge = false;
            JumpFromLedge();
        }
        // Lag between attacks
        if (isAttacking) {
            StopMovement();
        }

        if (isGrounded){
            moveSpeed = oriMoveSpeed;
        } else if (!isGrounded) {
            moveSpeed = airMoveSpeed;
        }

        // Checking if player is grounded
        CheckGrounded();

        // Changing state back to idle
        // BackToIdle();
        if (isAlive && GameManager.gameStarted) {
            Attack();
        }

        if (canMove && isAlive && GameManager.gameStarted) {
            Move();
        }
    }

    public void Move() {
        if (this.tag == "Player") {
            // Sideways movement
            float xMove = Input.GetAxisRaw("p1_h");
            float xSpeed = xMove * moveSpeed;
            Vector2 newVelocity = new Vector2(xSpeed, rb.velocity.y);
            rb.velocity = newVelocity;
            if (xMove < 0) {
                transform.eulerAngles = new Vector3(0, 180, 0);
            } else if (xMove > 0) {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            // Jump control
            if (isGrounded && Input.GetKeyDown(KeyCode.T)) {
                isJumping = true;
                jumpTimeCounter = jumpTimer;
                rb.velocity = Vector2.up * jumpPower;
            }
            if (Input.GetKey(KeyCode.T) && !isJumping) {
                if (jumpTimeCounter > 0) {
                    rb.velocity = Vector2.up * jumpPower;
                    jumpTimeCounter -= Time.deltaTime;
                } else {
                    isJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.T)) {
                isJumping = false;
            }
        }
        if(this.tag == "Player2") {
            // Sideways movement
            float xMove = Input.GetAxisRaw("p2_h");
            float xSpeed = xMove * moveSpeed;
            Vector2 newVelocity = new Vector2(xSpeed, rb.velocity.y);
            rb.velocity = newVelocity;
            if (xMove < 0) {
                transform.eulerAngles = new Vector3(0, 180, 0);
            } else if (xMove > 0) {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            // Jump control
            if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow)) {
                isJumping = true;
                jumpTimeCounter = jumpTimer;
                rb.velocity = Vector2.up * jumpPower;
            }
            if (Input.GetKey(KeyCode.UpArrow) && !isJumping) {
                if (jumpTimeCounter > 0) {
                    rb.velocity = Vector2.up * jumpPower;
                    jumpTimeCounter -= Time.deltaTime;
                } else {
                    isJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.UpArrow)) {
                isJumping = false;
            }
        }
    }

    public void Attack() {
        // Attack Controls for Player1
        if (this.tag == "Player"){
            if (Input.GetKeyDown(KeyCode.Q) && !isGrounded) {
                anim.SetTrigger("JumpAttack");
            }
            if (Input.GetKeyDown(KeyCode.W)) {
                anim.SetTrigger("SideAttack");
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                anim.SetTrigger("PunchAttack1");
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                Debug.Log("Special Attack");
            }
        }
        // Attack Controls for Player2
        if(this.tag == "Player2") {
            if (Input.GetKeyDown(KeyCode.I) && !isGrounded) {
                anim.SetTrigger("JumpAttack");
            }
            if (Input.GetKeyDown(KeyCode.O)) {
                anim.SetTrigger("SideAttack");
            }
            if (Input.GetKeyDown(KeyCode.I)) {
                anim.SetTrigger("PunchAttack1");
            }
            if (Input.GetKeyDown(KeyCode.P)) {
                Debug.Log("Special Attack");
            }
        }
    }

    public void CheckGrounded() {
        Debug.DrawRay(transform.position, direction * maxDistance, Color.green);
        if (Physics.Raycast(transform.position, direction, out hit, maxDistance, layerMask)) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }

    public void StopMovement() {
        // Stop player while attacking or other actions
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        canMove = false;
        isAttacking = true;
    }
    public void BackToIdle() {
        canMove = true;
        isAttacking = false;
    }

    public void StayInMap() {
        if(transform.position.x < -23 || transform.position.x > 23 || transform.position.y < -10 || transform.position.y > 25) {
            gameObject.SetActive(false);
            Debug.Log(transform.position);
            if (this.tag == "Player"){
                //LevelManager.p1_lives--;
            } else if(this.tag == "Player2"){
                //LevelManager.p2_lives--;
            }
            Invoke("Respawn", 2f);
        }
    }

    public void Respawn() {
        
        if (this.tag == "Player") {
            this.transform.position = spawnPos1.position;
            gameObject.SetActive(true);
            canMove = false;
            rb.velocity = Vector3.zero;
            Invoke("BackToIdle", 1f);
        }
        if(this.tag == "Player2") {
            this.transform.position = spawnPos2.position;
            gameObject.SetActive(true);
            canMove = false;
            rb.velocity = Vector3.zero;
            Invoke("BackToIdle", 1f);
        }
    }

    public void HoldOnLedge() {
        // TO DO: add immune time 
        onLedge = true;
        anim.SetTrigger("OnLedge");
        canMove = false;
        rb.useGravity = false;
    }

    public void HoldLeftLedge() {
        transform.position = leftHoldPos.position;
    }
    public void HoldRightLedge() {
        transform.position = rightHoldPos.position;
    }

    public void JumpFromLedge() {
        if (Input.GetKeyDown(KeyCode.T) && this.tag == "Player" || Input.GetKeyDown(KeyCode.UpArrow) && this.tag == "Player2") {
            rb.velocity = Vector2.up * jumpPower * 1.2f;
            ledgeTime = oriLedgeTime;
            rb.useGravity = true;
            canMove = true;
            anim.SetTrigger("LeaveLedge");
        }
    }

    private void OnTriggerEnter(Collider col) {
        if(col.tag == "Platform") {
            Physics.IgnoreCollision(col, GetComponent<Collider>(), true);
            Debug.Log("ignoring collision");
        }
    }

}
