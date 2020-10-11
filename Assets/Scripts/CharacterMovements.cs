using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{

    Rigidbody2D rb; 
    public float speed;
    public float jumpForce;
    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius; 
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor; 
    float lastTimeGrounded;
    public bool characterRight = true;
    public int maxSpeed = 50;
    private Animator characterAnimations;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
        characterAnimations = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
        Jump();
        CheckIfGrounded();
        BetterJump();


        //Rotate 
        if(!characterRight){
            //gameObject.transform.localScale = new Vector3 (-0.5f, 0.5f, 0.5f);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else{
            //gameObject.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Move() { 
        float x = Input.GetAxisRaw("Horizontal"); 
        float moveBy = x * speed;

        Vector3 InitialPos = gameObject.transform.localScale;

        if(x == 1){
            characterRight = true;
        }   
        else if(x == -1){
            characterRight = false;
        }

        


        
        
        //Change l'état de l'animation
        if(x == 0){
            characterAnimations.SetBool("IsRunning", false);
        }
        else{
            characterAnimations.SetBool("IsRunning", true);
        }
    
        rb.velocity = new Vector2(moveBy * Time.deltaTime, rb.velocity.y); 

        if(rb.velocity.magnitude > maxSpeed * Time.deltaTime){
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
        }

    }

    void Jump() { 
         if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
    void CheckIfGrounded() { 
            Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 
            if (colliders != null) { 
                isGrounded = true; 
            } else { 
                if (isGrounded) { 
                    lastTimeGrounded = Time.time; 
                } 
                isGrounded = false; 
            } 
    }

    void BetterJump() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

}
