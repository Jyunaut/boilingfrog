using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        trajectory(new Vector3(0,0,0));
    }

    void rotation(Vector3 dir)
    {
        
    }

    void trajectory(Vector3 dir)
    {
        transform.position = transform.position + new Vector3(speed*Time.deltaTime, 0, 0);
    }
}
