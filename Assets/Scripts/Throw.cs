using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject[] obstacles;
    public float timer = 0.0f;
    public float offset = 3.0f;
    public float curOffset = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        curOffset = offset;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= curOffset)
        {
            threw(new Vector3(0, Random.Range(3f,11f), Random.Range(-12f,-2f)), Vector3.zero);
            curOffset += offset;
        }
        Debug.Log("hi");
    }

    void threw(Vector3 pos, Vector3 dir)
    {
        int randIngredient = Random.Range(0,obstacles.Length);
        GameObject r = obstacles[randIngredient];
        Instantiate(r, pos, Quaternion.identity);
    }
}
