using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
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
        transform.position = transform.position + new Vector3(1*Time.deltaTime, 0, 0);
    }
}
