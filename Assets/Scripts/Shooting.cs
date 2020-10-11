using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject character;
    public GameObject projectilePrefab;
    public GameObject projectileStart;
    public float projectileSpeed = 20f;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        Vector3 difference = target - character.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (Input.GetMouseButtonDown(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireProjectile(direction, rotationZ);
        }
    }

    void fireProjectile(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(projectilePrefab) as GameObject;
        b.transform.position = projectileStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
    }
}
