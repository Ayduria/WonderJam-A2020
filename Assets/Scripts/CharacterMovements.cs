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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(); 
        Jump();
        CheckIfGrounded();
        BetterJump();
    }

    void Move() { 
        float x = Input.GetAxisRaw("Horizontal"); 
        float moveBy = x * speed; 

        Vector3 InitialPos = gameObject.transform.localScale;

        if(x == -1)
            gameObject.transform.localScale = new Vector3 (-3.5f, 3.5f, 3.5f);
        else
            gameObject.transform.localScale = new Vector3 (-3.5f, 3.5f, 3.5f);
        


        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
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
