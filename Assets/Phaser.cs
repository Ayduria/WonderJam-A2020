using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phaser : MonoBehaviour
{

    public GameObject PhaserObject;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y > PhaserObject.transform.position.y){
            gameObject.layer = 9;
        }
    }

}
