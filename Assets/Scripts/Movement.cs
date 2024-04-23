using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public PathCreator pathCreator;
    public float speed = 1.0f;
    float distanceTravelled;
    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        
    }
}
