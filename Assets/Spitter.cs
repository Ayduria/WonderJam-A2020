using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spitter : MonoBehaviour
{

    public GameObject prefabs;
    public float numberOfMonsters = 5;
    private float currentMonstersNumber;
    public float Timer = 0.1f;
    public float spitSpeed = 2000;
    public float spitOffset= 1000;

    public bool timerEnded = false;

    public Transform spawnerPosition;

    private float malus = 1;

    private float FinalMalus = 0;

    public int[] finalQuantities;
    public int finalQuantitiesSetter;

    public int monsterToKill = 1;

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


                if(timerEnded){

                    if(FinalMalus == 0){
                        FinalMalus = GameObject.FindGameObjectWithTag("substance").GetComponent<getIngredients>().malus;

                        finalQuantities = GameObject.FindGameObjectWithTag("substance").GetComponent<getIngredients>().ingredientsQuantity;

                        for (int i = 0; i < finalQuantities.Length; i++)
                        {
                            finalQuantitiesSetter += finalQuantities[i];
                        }

                        FinalMalus += finalQuantitiesSetter;
                    }

                   

                    if(currentMonstersNumber <  numberOfMonsters){

                        if(FinalMalus > 10){
                            FinalMalus = 10;
                        }

                        switch(FinalMalus)
                        {
                            case 1: 
                                prefabs = Resources.Load<GameObject>("Mobs/lapin");
                                numberOfMonsters = 10;
                                monsterToKill = 10;
                                break;
                            case 2: 
                                prefabs = Resources.Load<GameObject>("Mobs/slime");
                                numberOfMonsters = 10;
                                monsterToKill = 10;
                                break;
                            case 3: 
                                prefabs = Resources.Load<GameObject>("Mobs/slime");
                                numberOfMonsters = 10;
                                monsterToKill = 10;
                                break;
                            case 4: 
                                prefabs = Resources.Load<GameObject>("Mobs/slime");
                                numberOfMonsters = 10;
                                monsterToKill = 10;
                                break;
                            case 5:
                                prefabs = Resources.Load<GameObject>("Mobs/croc");
                                 numberOfMonsters = 7;
                                 monsterToKill = 7;
                                break;
                            case 6:
                                prefabs = Resources.Load<GameObject>("Mobs/croc");
                                 numberOfMonsters = 7;
                                 monsterToKill = 7;
                                break;
                            case 7:
                                prefabs = Resources.Load<GameObject>("Mobs/zombie");
                                 numberOfMonsters = 7;
                                 monsterToKill = 7;
                                break;
                            case 8:
                                prefabs = Resources.Load<GameObject>("Mobs/zombie");
                                 numberOfMonsters = 7;
                                 monsterToKill = 7;
                                break;
                            case 9:
                                prefabs = Resources.Load<GameObject>("Mobs/edritch");
                                 numberOfMonsters = 5;
                                 monsterToKill = 5;
                                break;
                            case 10:
                                prefabs = Resources.Load<GameObject>("Mobs/edritch");
                                 numberOfMonsters = 5;
                                 monsterToKill = 5;
                                break;
                        }


                        

                        GameObject mob = Instantiate(prefabs, spawnerPosition.transform.position + prefabs.transform.localScale , transform.rotation);
                        mob.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(spitOffset * -1, spitOffset) * Time.fixedDeltaTime, spitSpeed * Time.fixedDeltaTime);
                        Timer = 0.1f;
                    }

                    currentMonstersNumber ++;
                }

            }


            if(monsterToKill <= 0){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        
            
    }
}
