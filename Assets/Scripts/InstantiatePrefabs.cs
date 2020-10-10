using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour
{

    private GameObject[] prefabs;
    public int multiplier = 60;

    public Transform spawnerPosition;
 
    void Start(){

        prefabs = Resources.LoadAll<GameObject>("Ingredients");

        for (int i = 0; i < multiplier; i++)
        {  
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, transform.rotation);
        }
        
    }
    
    void Update()
    {
       
    }


}
