using UnityEngine;
using PathCreation;
using UnityEditor;

public class PropsGenerator : MonoBehaviour{

    Tunnel tunnel;
    Vector3[] pathPoints;
    Vector3[] normals;
    Vector3[] tangents;
    GameObject prop;

    
    private float distanceTravelled;
    
    void Start(){
        tunnel = transform.GetComponentInParent<Tunnel>();
    }


    void Generate(){
        
    }

    void Update(){
        
        Generate();
        }
}