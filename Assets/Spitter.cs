using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Spitter : MonoBehaviour
{

    public GameObject prefabs;
    public float numberOfMonsters = 5;
    private float currentMonstersNumber;
    public float Timer = 0.1f;
    public float spitSpeed = 2000;
    public float spitOffset= 1000;

    public Transform spawnerPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {

                if(currentMonstersNumber <  numberOfMonsters){
                    GameObject mob = Instantiate(prefabs, spawnerPosition.transform.position + prefabs.transform.localScale , transform.rotation);
                    mob.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(spitOffset * -1, spitOffset) * Time.deltaTime, spitSpeed * Time.deltaTime);
                    Timer = 0.1f;
                }

                currentMonstersNumber ++;

            }
        
            
    }
}
