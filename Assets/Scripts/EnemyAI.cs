using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float maxVelocity  = 50f;
    private Transform target;
    public int level = 1;
    public bool isGrounded;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public bool groundedOnce = false;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        switch(level)
        {
            case 1: 
                maxHealth = 20;
                damage = 5;
                break;
            case 2: 
                maxHealth = 40;
                damage = 10;
                break;
            case 3:
                maxHealth = 60;
                damage = 15;
                break;
            case 4:
                maxHealth = 80;
                damage = 20;
                break;
            case 5:
                maxHealth = 100;
                damage = 25;
                break;
        }
           
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
        if(groundedOnce){
            move();
        }
        jumpAttack();
    }

    void FixedUpdate ()
    {
        if(rb.velocity.magnitude > maxVelocity)
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8 && !isGrounded)
            isGrounded = true;
        if (other.gameObject.tag == "Projectile")
            TakeDamage(20);
        if (other.gameObject.tag == "Player")
            InflictDamage(damage);
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Hole")
            groundedOnce = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.layer == 8 && isGrounded)
            isGrounded = false;

    }

    private void checkHealth(){
        if (currentHealth == 0)
            Destroy(gameObject);
    }

    private void move(){

        if (rb.position.x < target.position.x)
            rb.velocity = new Vector2 (speed * Time.deltaTime, rb.velocity.y);
        else if (rb.position.x > target.position.x)
            rb.velocity = new Vector2 (speed * Time.deltaTime * -1, rb.velocity.y);

        if(rb.velocity.x >= 0.01f)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x <= -0.01f)
            transform.localRotation = Quaternion.Euler(0, 0, 0);      
    }

    private void jumpAttack(){
        float distance = Vector3.Distance(transform.localPosition, target.transform.localPosition);

        if (distance < 1.5f && isGrounded == true)
            rb.AddForce (Vector2.up * 8f);
    }

    void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
    }

    void InflictDamage(int damageDealt)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHealth>().currentHealth -= damageDealt;
    }
}
