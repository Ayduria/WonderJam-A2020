using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float maxVelocity  = 50f;
    private Transform target;
    public float level = 0;
    public bool isGrounded;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public bool groundedOnce = false;
    public int[] finalQuantities;
    public int finalQuantitiesSetter;
    public AudioSource Hit;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();


        if(level == 0){
            level = GameObject.FindGameObjectWithTag("substance").GetComponent<getIngredients>().malus;

            finalQuantities = GameObject.FindGameObjectWithTag("substance").GetComponent<getIngredients>().ingredientsQuantity;

            for (int i = 0; i < finalQuantities.Length; i++)
            {
                finalQuantitiesSetter += finalQuantities[i];
            }

            level += finalQuantitiesSetter;
        }

        if(level > 10){
            level = 10;
        }

        switch(level)
        {
            case 1: 
                maxHealth = 20;
                damage = 0;
                break;
            case 2: 
                maxHealth = 40;
                damage = 10;
                break;
            case 3: 
                maxHealth = 40;
                damage = 10;
                break;
            case 4: 
                maxHealth = 40;
                damage = 10;
                break;
            case 5:
                maxHealth = 60;
                damage = 15;
                break;
            case 6:
                maxHealth = 60;
                damage = 15;
                break;
            case 7:
                maxHealth = 80;
                damage = 20;
                break;
            case 8:
                maxHealth = 80;
                damage = 20;
                break;
            case 9:
                maxHealth = 100;
                damage = 25;
                break;
            case 10:
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
        if (currentHealth == 0){
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Spitter").GetComponent<Spitter>().monsterToKill -= 1;
        }
    }

    private void move(){

        if (rb.position.x < target.position.x)
            rb.velocity = new Vector2 (speed * Time.fixedDeltaTime, rb.velocity.y);
        else if (rb.position.x > target.position.x)
            rb.velocity = new Vector2 (speed * Time.fixedDeltaTime * -1, rb.velocity.y);

        if(rb.velocity.x >= 0.01f)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (rb.velocity.x <= -0.01f)
            transform.localRotation = Quaternion.Euler(0, 0, 0);      
    }

    private void jumpAttack(){
        float distance = Vector3.Distance(transform.localPosition, target.transform.localPosition);

        if (distance < 1.5f && isGrounded == true){
            rb.velocity = new Vector2(rb.velocity.x, 4);
        }

    }

    void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

    }

    void InflictDamage(int damageDealt)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerHealth>().currentHealth -= damageDealt;
        var damageSound = GetComponent<CharacterMovements>().takeDamage;

        damageSound.Play();
    }
}
