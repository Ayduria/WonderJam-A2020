using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{


    private Vector3 mousePosition;
    public float moveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {

            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            
            if(rayHit.rigidbody){
                if(rayHit.rigidbody.tag == "Grabbable"){
                    mousePosition = Input.mousePosition;
                    mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                    rayHit.transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                }
            }

        }
        
    }


   



}
