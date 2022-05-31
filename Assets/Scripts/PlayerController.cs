using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public static PlayerController instance;

    [SerializeField] private float movingSpeed;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float knockBackLength, knockBackForce;

    private bool isGrounded;
    private bool dpoubleJump;
    private Animator anim;
    private SpriteRenderer sr;
    private float konckBackCounter;

    private void Awake(){
        instance = this;
    }

    void Start() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

   
    void Update() {
        if(konckBackCounter <= 0){
            RB.velocity = new Vector2(movingSpeed * Input.GetAxisRaw("Horizontal"), RB.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
            if(isGrounded){
                dpoubleJump = true;
            }
            if(Input.GetButtonDown("Jump")){
                if(isGrounded){
                    RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                } else {
                    if(dpoubleJump){
                        RB.velocity = new Vector2(RB.velocity.x, jumpForce);
                        dpoubleJump = false;
                    }
                }
            }

            if(RB.velocity.x < 0){
                sr.flipX = true;
            } else if(RB.velocity.x > 0){
                sr.flipX = false;
            }
        } else {
            konckBackCounter -= Time.deltaTime;
            if(!sr.flipX){
                RB.velocity = new Vector2(-knockBackForce, RB.velocity.y);
            } else {
                RB.velocity = new Vector2(knockBackForce, RB.velocity.y);
            }
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(RB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Moving Platform")) {          
            gameObject.transform.parent = other.gameObject.transform;
        }
    }

    // private void OnTriggerEnter2D(Collider2D col) {
    //     if(col.gameObject.CompareTag("Moving Platform")){
    //         Debug.Log("Crot aaaaaaahhh");
    //         gameObject.transform.parent = col.gameObject.transform;
    //     }
    // } 

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Moving Platform")) {          
            gameObject.transform.parent = null;
        }
    }

    public void konckBack(){
        konckBackCounter = knockBackLength;
        RB.velocity = new Vector2(0f, knockBackForce);
        // anim.Play("Player_Hit");
        anim.SetTrigger("hurt");
    }

    public void BouncePlayer(float force){
        if(isGrounded){
            // isGrounded = false;
            RB.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
