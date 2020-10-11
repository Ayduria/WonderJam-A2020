using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manageReceip : MonoBehaviour
{

    public GameObject peceipPaper;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        peceipPaper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if(dist < 2.5){
            if(Input.GetKeyDown(KeyCode.E)){
                peceipPaper.SetActive(true);
            }
        }
        
    }

                

}
