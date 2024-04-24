using System.Collections.Generic;
using System.Linq;
using PathCreation;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(PathCreator))] // Requires MeshFilter and MeshRenderer components to be attached to the same GameObject
public class Tunnel : MonoBehaviour
{
    public PathCreator pathCreator;
    public PropsGenerator propsGenerator;
    public GameObject ship;

    
    [HideInInspector]
    public float distanceTravelled;
    public Vector3 currentPosition;
    [HideInInspector]
    public Quaternion currentRotation;
    public int segIndex = 0;
    Vector3[] pathPoints;
    Vector3[] normals;
    Vector3[] tangents;
    private List<GameObject> segments;
    private float speed = 10.0f;
    void Start()
    {
        segments = new List<GameObject>();
        pathCreator.transform.position = Vector3.zero;
        transform.position = Vector3.zero;

        pathPoints = pathCreator.path.localPoints;
        normals = pathCreator.path.localNormals;
        tangents = pathCreator.path.localTangents;

        InitializeTunnel();

    }

    void InitializeTunnel(){
        int nbrofseg = pathPoints.Length;
        for (int i = 0; i < nbrofseg; i++){
            CreateSegment(i);
        }
    }

    void CreateSegment(int idx=0)
    {
        if(idx == 0){
            idx = segIndex;
        }
        segments.Add(GameObject.CreatePrimitive(PrimitiveType.Cube));
        GameObject currentSegment = segments.Last();
        currentSegment.transform.position = pathPoints[idx];
        currentSegment.transform.rotation = Quaternion.LookRotation(tangents[idx], normals[idx]);
        segIndex++;
    }

    // Update is called once per frame
    void Update()
    { 
        distanceTravelled += speed * Time.deltaTime;
        currentPosition = pathCreator.path.GetPointAtDistance(distanceTravelled);
        currentRotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}