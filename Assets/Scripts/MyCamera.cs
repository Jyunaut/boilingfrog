using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 cameraTrack;
    public float curDistance;
    public float offsetDistance = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //Face camera to target
        cameraTrack = target.position - this.transform.position;
        cameraTrack.Normalize();

        Debug.DrawRay(this.transform.position, cameraTrack);

        //Calc distance between camera and target
        Vector3 dist = target.position - this.transform.position;
        curDistance = dist.sqrMagnitude;

        if(offsetDistance <= curDistance)
        {
            follow();
        }
    }
    void follow()
    {
        this.transform.position += cameraTrack*Time.deltaTime;
    }
}
