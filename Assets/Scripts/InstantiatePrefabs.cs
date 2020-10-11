using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{

    private GameObject[] prefabs;
    public int multiplier = 60;
    private float currentIngredientsNumber;
    public float Timer = 0.5f;
    private float TimerDefault;
    

    public Transform spawnerPosition;
 
    void Start(){
         TimerDefault = Timer;
        
    }
    
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {

            prefabs = Resources.LoadAll<GameObject>("Ingredients");
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, transform.rotation);
            Timer = TimerDefault;

        }
        

        currentIngredientsNumber ++;

    }


}
