using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePhysics : MonoBehaviour
{

    public AudioSource hit;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);

        hit.Play();
        
    }
}