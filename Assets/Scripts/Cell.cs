using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : MonoBehaviour
{
    public float speed;
    public float width;
    public float distance;
    public GameObject ship;
    private System.Random random = new System.Random();

    void Start()
    {
        double rndnbr = random.Next();
        double rndw = random.Next((int) width);

        transform.position = new Vector3((float) (Math.Sin(rndnbr) * rndw), (float) (Math.Cos(rndnbr) * rndw), distance);
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().velocity = transform.forward * -1 * speed;
        Destroy(gameObject, distance/speed + 1);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
